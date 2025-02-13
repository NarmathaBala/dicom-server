﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

namespace Microsoft.Health.Dicom.Core.Features.Query
{
    public class QueryParameters : BaseQueryParameters
    {
        public QueryResource QueryResourceType { get; set; }

        public string StudyInstanceUid { get; set; }

        public string SeriesInstanceUid { get; set; }
    }
}
