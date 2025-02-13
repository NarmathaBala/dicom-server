﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using EnsureThat;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Health.Dicom.Operations.Configuration;

[assembly: FunctionsStartup(typeof(Microsoft.Health.Dicom.Functions.Startup))]
namespace Microsoft.Health.Dicom.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            EnsureArg.IsNotNull(builder, nameof(builder));

            IConfiguration config = builder.GetHostConfiguration();
            builder.Services
                .ConfigureFunctions(config)
                .AddMetadataStorageDataStore(config)
                .AddSqlServer(config);
        }
    }
}
