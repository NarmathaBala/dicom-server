﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.Tables;
using EnsureThat;
using FellowOakDicom;
using Microsoft.Extensions.Logging;
using Microsoft.Health.Dicom.Client.Models;
using Microsoft.Health.DicomCast.Core.Features.ExceptionStorage;
using Microsoft.Health.DicomCast.TableStorage.Features.Storage.Entities;
using Microsoft.Health.DicomCast.TableStorage.Features.Storage.Models.Entities;

namespace Microsoft.Health.DicomCast.TableStorage.Features.Storage
{
    /// <inheritdoc/>
    public class TableExceptionStore : IExceptionStore
    {
        private readonly TableServiceClient _tableServiceClient;
        private readonly ILogger<TableExceptionStore> _logger;
        private readonly Dictionary<string, string> _tableList;

        public TableExceptionStore(
            TableServiceClientProvider tableServiceClientProvider,
            ILogger<TableExceptionStore> logger)
        {
            EnsureArg.IsNotNull(tableServiceClientProvider, nameof(tableServiceClientProvider));
            EnsureArg.IsNotNull(logger, nameof(logger));

            _tableServiceClient = tableServiceClientProvider.GetTableServiceClient();
            _tableList = tableServiceClientProvider.TableList;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task WriteExceptionAsync(ChangeFeedEntry changeFeedEntry, Exception exceptionToStore, ErrorType errorType, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(changeFeedEntry, nameof(changeFeedEntry));

            string tableName = errorType switch
            {
                ErrorType.FhirError => _tableList[Constants.FhirExceptionTableName],
                ErrorType.DicomError => _tableList[Constants.DicomExceptionTableName],
                ErrorType.DicomValidationError => _tableList[Constants.DicomValidationTableName],
                ErrorType.TransientFailure => _tableList[Constants.TransientFailureTableName],
                _ => null,
            };

            if (tableName == null)
            {
                return;
            }

            DicomDataset dataset = changeFeedEntry.Metadata;
            string studyInstanceUid = dataset.GetSingleValue<string>(DicomTag.StudyInstanceUID);
            string seriesInstanceUid = dataset.GetSingleValue<string>(DicomTag.SeriesInstanceUID);
            string sopInstanceUid = dataset.GetSingleValue<string>(DicomTag.SOPInstanceUID);
            long changeFeedSequence = changeFeedEntry.Sequence;

            var tableClient = _tableServiceClient.GetTableClient(tableName);
            var entity = new IntransientEntity(studyInstanceUid, seriesInstanceUid, sopInstanceUid, changeFeedSequence, exceptionToStore);

            try
            {
                await tableClient.UpsertEntityAsync(entity, cancellationToken: cancellationToken);
                _logger.LogInformation("Error when processing changefeed entry: {ChangeFeedSequence} for DICOM instance with StudyUID: {StudyInstanceUid}, SeriesUID: {SeriesInstanceUid}, InstanceUID: {SopInstanceUid}. Stored into table: {Table} in table storage.", changeFeedSequence, studyInstanceUid, seriesInstanceUid, sopInstanceUid, tableName);
            }
            catch
            {
                _logger.LogInformation("Error when processing changefeed entry: {ChangeFeedSequence} for DICOM instance with StudyUID: {StudyInstanceUid}, SeriesUID: {SeriesInstanceUid}, InstanceUID: {SopInstanceUid}. Failed to store to table storage.", changeFeedSequence, studyInstanceUid, seriesInstanceUid, sopInstanceUid);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task WriteRetryableExceptionAsync(ChangeFeedEntry changeFeedEntry, int retryNum, TimeSpan nextDelayTimeSpan, Exception exceptionToStore, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(changeFeedEntry, nameof(changeFeedEntry));

            DicomDataset dataset = changeFeedEntry.Metadata;
            string studyInstanceUid = dataset.GetSingleValue<string>(DicomTag.StudyInstanceUID);
            string seriesInstanceUid = dataset.GetSingleValue<string>(DicomTag.SeriesInstanceUID);
            string sopInstanceUid = dataset.GetSingleValue<string>(DicomTag.SOPInstanceUID);
            long changeFeedSequence = changeFeedEntry.Sequence;

            var tableClient = _tableServiceClient.GetTableClient(_tableList[Constants.TransientRetryTableName]);
            var entity = new RetryableEntity(studyInstanceUid, seriesInstanceUid, sopInstanceUid, changeFeedSequence, retryNum, exceptionToStore);

            try
            {
                await tableClient.UpsertEntityAsync(entity, cancellationToken: cancellationToken);
                _logger.LogInformation("Retryable error when processing changefeed entry: {ChangeFeedSequence} for DICOM instance with StudyUID: {StudyInstanceUid}, SeriesUID: {SeriesInstanceUid}, InstanceUID: {SopInstanceUid}. Tried {RetryNum} time(s). Waiting {Milliseconds} milliseconds . Stored into table: {Table} in table storage.", changeFeedSequence, studyInstanceUid, seriesInstanceUid, sopInstanceUid, retryNum, nextDelayTimeSpan.TotalMilliseconds, _tableList[Constants.TransientRetryTableName]);
            }
            catch
            {
                _logger.LogInformation("Retryable error when processing changefeed entry: {ChangeFeedSequence} for DICOM instance with StudyUID: {StudyInstanceUid}, SeriesUID: {SeriesInstanceUid}, InstanceUID: {SopInstanceUid}. Tried {RetryNum} time(s). Failed to store to table storage.", changeFeedSequence, studyInstanceUid, seriesInstanceUid, sopInstanceUid, retryNum);
                throw;
            }
        }
    }
}
