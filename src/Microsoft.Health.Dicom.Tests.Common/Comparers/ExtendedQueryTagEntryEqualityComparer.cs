﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using EnsureThat;
using Microsoft.Health.Dicom.Core.Features.ExtendedQueryTag;

namespace Microsoft.Health.Dicom.Tests.Common.Comparers
{
    public class ExtendedQueryTagEntryEqualityComparer : IEqualityComparer<GetExtendedQueryTagEntry>
    {
        public static ExtendedQueryTagEntryEqualityComparer Default { get; } = new ExtendedQueryTagEntryEqualityComparer();


        public bool Equals(GetExtendedQueryTagEntry x, GetExtendedQueryTagEntry y)
        {
            if (x == null || y == null)
            {
                return x == y;
            }

            return x.Path.Equals(y.Path, StringComparison.OrdinalIgnoreCase)
                && string.Equals(x.VR, y.VR, StringComparison.OrdinalIgnoreCase)
                && x.PrivateCreator == y.PrivateCreator
                && x.Level == y.Level
                && x.Status == y.Status
                && x.Errors?.Count == y.Errors?.Count
                && x.Errors?.Href == y.Errors?.Href;
        }

        public int GetHashCode(GetExtendedQueryTagEntry entry)
        {
            EnsureArg.IsNotNull(entry, nameof(entry));
            int hashCode = HashCode.Combine(
                entry.Path,
                entry.VR,
                entry.PrivateCreator,
                entry.Level,
                entry.Status);

            return entry.Errors != null ? HashCode.Combine(hashCode, entry.Errors.Count, entry.Errors.Href) : hashCode;
        }
    }
}
