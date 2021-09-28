//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Microsoft.Health.Dicom.SqlServer.Features.Schema.Model
{
    using Microsoft.Health.SqlServer.Features.Client;
    using Microsoft.Health.SqlServer.Features.Schema.Model;

    internal class AddExtendedQueryTagsInputTableTypeV1TableValuedParameterDefinition : TableValuedParameterDefinition<AddExtendedQueryTagsInputTableTypeV1Row>
    {
        internal AddExtendedQueryTagsInputTableTypeV1TableValuedParameterDefinition(System.String parameterName) : base(parameterName, "dbo.AddExtendedQueryTagsInputTableType_1")
        {
        }

        internal readonly VarCharColumn TagPath = new VarCharColumn("TagPath", 64);
        internal readonly VarCharColumn TagVR = new VarCharColumn("TagVR", 2);
        internal readonly NVarCharColumn TagPrivateCreator = new NVarCharColumn("TagPrivateCreator", 64);
        internal readonly TinyIntColumn TagLevel = new TinyIntColumn("TagLevel");

        protected override global::System.Collections.Generic.IEnumerable<Column> Columns => new Column[] { TagPath, TagVR, TagPrivateCreator, TagLevel };

        protected override void FillSqlDataRecord(global::Microsoft.Data.SqlClient.Server.SqlDataRecord record, AddExtendedQueryTagsInputTableTypeV1Row rowData)
        {
            TagPath.Set(record, 0, rowData.TagPath);
            TagVR.Set(record, 1, rowData.TagVR);
            TagPrivateCreator.Set(record, 2, rowData.TagPrivateCreator);
            TagLevel.Set(record, 3, rowData.TagLevel);
        }
    }

    internal struct AddExtendedQueryTagsInputTableTypeV1Row
    {
        internal AddExtendedQueryTagsInputTableTypeV1Row(System.String TagPath, System.String TagVR, System.String TagPrivateCreator, System.Byte TagLevel)
        {
            this.TagPath = TagPath;
            this.TagVR = TagVR;
            this.TagPrivateCreator = TagPrivateCreator;
            this.TagLevel = TagLevel;
        }

        internal System.String TagPath { get; }
        internal System.String TagVR { get; }
        internal System.String TagPrivateCreator { get; }
        internal System.Byte TagLevel { get; }
    }

    internal class ExtendedQueryTagKeyTableTypeV1TableValuedParameterDefinition : TableValuedParameterDefinition<ExtendedQueryTagKeyTableTypeV1Row>
    {
        internal ExtendedQueryTagKeyTableTypeV1TableValuedParameterDefinition(System.String parameterName) : base(parameterName, "dbo.ExtendedQueryTagKeyTableType_1")
        {
        }

        internal readonly IntColumn TagKey = new IntColumn("TagKey");

        protected override global::System.Collections.Generic.IEnumerable<Column> Columns => new Column[] { TagKey };

        protected override void FillSqlDataRecord(global::Microsoft.Data.SqlClient.Server.SqlDataRecord record, ExtendedQueryTagKeyTableTypeV1Row rowData)
        {
            TagKey.Set(record, 0, rowData.TagKey);
        }
    }

    internal struct ExtendedQueryTagKeyTableTypeV1Row
    {
        internal ExtendedQueryTagKeyTableTypeV1Row(System.Int32 TagKey)
        {
            this.TagKey = TagKey;
        }

        internal System.Int32 TagKey { get; }
    }

    internal class InsertDateTimeExtendedQueryTagTableTypeV1TableValuedParameterDefinition : TableValuedParameterDefinition<InsertDateTimeExtendedQueryTagTableTypeV1Row>
    {
        internal InsertDateTimeExtendedQueryTagTableTypeV1TableValuedParameterDefinition(System.String parameterName) : base(parameterName, "dbo.InsertDateTimeExtendedQueryTagTableType_1")
        {
        }

        internal readonly IntColumn TagKey = new IntColumn("TagKey");
        internal readonly DateTime2Column TagValue = new DateTime2Column("TagValue", 7);
        internal readonly TinyIntColumn TagLevel = new TinyIntColumn("TagLevel");

        protected override global::System.Collections.Generic.IEnumerable<Column> Columns => new Column[] { TagKey, TagValue, TagLevel };

        protected override void FillSqlDataRecord(global::Microsoft.Data.SqlClient.Server.SqlDataRecord record, InsertDateTimeExtendedQueryTagTableTypeV1Row rowData)
        {
            TagKey.Set(record, 0, rowData.TagKey);
            TagValue.Set(record, 1, rowData.TagValue);
            TagLevel.Set(record, 2, rowData.TagLevel);
        }
    }

    internal struct InsertDateTimeExtendedQueryTagTableTypeV1Row
    {
        internal InsertDateTimeExtendedQueryTagTableTypeV1Row(System.Int32 TagKey, System.DateTime TagValue, System.Byte TagLevel)
        {
            this.TagKey = TagKey;
            this.TagValue = TagValue;
            this.TagLevel = TagLevel;
        }

        internal System.Int32 TagKey { get; }
        internal System.DateTime TagValue { get; }
        internal System.Byte TagLevel { get; }
    }

    internal class InsertDateTimeExtendedQueryTagTableTypeV2TableValuedParameterDefinition : TableValuedParameterDefinition<InsertDateTimeExtendedQueryTagTableTypeV2Row>
    {
        internal InsertDateTimeExtendedQueryTagTableTypeV2TableValuedParameterDefinition(System.String parameterName) : base(parameterName, "dbo.InsertDateTimeExtendedQueryTagTableType_2")
        {
        }

        internal readonly IntColumn TagKey = new IntColumn("TagKey");
        internal readonly DateTime2Column TagValue = new DateTime2Column("TagValue", 7);
        internal readonly NullableDateTime2Column TagValueUTC = new NullableDateTime2Column("TagValueUTC", 7);
        internal readonly TinyIntColumn TagLevel = new TinyIntColumn("TagLevel");

        protected override global::System.Collections.Generic.IEnumerable<Column> Columns => new Column[] { TagKey, TagValue, TagValueUTC, TagLevel };

        protected override void FillSqlDataRecord(global::Microsoft.Data.SqlClient.Server.SqlDataRecord record, InsertDateTimeExtendedQueryTagTableTypeV2Row rowData)
        {
            TagKey.Set(record, 0, rowData.TagKey);
            TagValue.Set(record, 1, rowData.TagValue);
            TagValueUTC.Set(record, 2, rowData.TagValueUTC);
            TagLevel.Set(record, 3, rowData.TagLevel);
        }
    }

    internal struct InsertDateTimeExtendedQueryTagTableTypeV2Row
    {
        internal InsertDateTimeExtendedQueryTagTableTypeV2Row(System.Int32 TagKey, System.DateTime TagValue, System.Nullable<System.DateTime> TagValueUTC, System.Byte TagLevel)
        {
            this.TagKey = TagKey;
            this.TagValue = TagValue;
            this.TagValueUTC = TagValueUTC;
            this.TagLevel = TagLevel;
        }

        internal System.Int32 TagKey { get; }
        internal System.DateTime TagValue { get; }
        internal System.Nullable<System.DateTime> TagValueUTC { get; }
        internal System.Byte TagLevel { get; }
    }

    internal class InsertDoubleExtendedQueryTagTableTypeV1TableValuedParameterDefinition : TableValuedParameterDefinition<InsertDoubleExtendedQueryTagTableTypeV1Row>
    {
        internal InsertDoubleExtendedQueryTagTableTypeV1TableValuedParameterDefinition(System.String parameterName) : base(parameterName, "dbo.InsertDoubleExtendedQueryTagTableType_1")
        {
        }

        internal readonly IntColumn TagKey = new IntColumn("TagKey");
        internal readonly FloatColumn TagValue = new FloatColumn("TagValue", 53);
        internal readonly TinyIntColumn TagLevel = new TinyIntColumn("TagLevel");

        protected override global::System.Collections.Generic.IEnumerable<Column> Columns => new Column[] { TagKey, TagValue, TagLevel };

        protected override void FillSqlDataRecord(global::Microsoft.Data.SqlClient.Server.SqlDataRecord record, InsertDoubleExtendedQueryTagTableTypeV1Row rowData)
        {
            TagKey.Set(record, 0, rowData.TagKey);
            TagValue.Set(record, 1, rowData.TagValue);
            TagLevel.Set(record, 2, rowData.TagLevel);
        }
    }

    internal struct InsertDoubleExtendedQueryTagTableTypeV1Row
    {
        internal InsertDoubleExtendedQueryTagTableTypeV1Row(System.Int32 TagKey, System.Double TagValue, System.Byte TagLevel)
        {
            this.TagKey = TagKey;
            this.TagValue = TagValue;
            this.TagLevel = TagLevel;
        }

        internal System.Int32 TagKey { get; }
        internal System.Double TagValue { get; }
        internal System.Byte TagLevel { get; }
    }

    internal class InsertLongExtendedQueryTagTableTypeV1TableValuedParameterDefinition : TableValuedParameterDefinition<InsertLongExtendedQueryTagTableTypeV1Row>
    {
        internal InsertLongExtendedQueryTagTableTypeV1TableValuedParameterDefinition(System.String parameterName) : base(parameterName, "dbo.InsertLongExtendedQueryTagTableType_1")
        {
        }

        internal readonly IntColumn TagKey = new IntColumn("TagKey");
        internal readonly BigIntColumn TagValue = new BigIntColumn("TagValue");
        internal readonly TinyIntColumn TagLevel = new TinyIntColumn("TagLevel");

        protected override global::System.Collections.Generic.IEnumerable<Column> Columns => new Column[] { TagKey, TagValue, TagLevel };

        protected override void FillSqlDataRecord(global::Microsoft.Data.SqlClient.Server.SqlDataRecord record, InsertLongExtendedQueryTagTableTypeV1Row rowData)
        {
            TagKey.Set(record, 0, rowData.TagKey);
            TagValue.Set(record, 1, rowData.TagValue);
            TagLevel.Set(record, 2, rowData.TagLevel);
        }
    }

    internal struct InsertLongExtendedQueryTagTableTypeV1Row
    {
        internal InsertLongExtendedQueryTagTableTypeV1Row(System.Int32 TagKey, System.Int64 TagValue, System.Byte TagLevel)
        {
            this.TagKey = TagKey;
            this.TagValue = TagValue;
            this.TagLevel = TagLevel;
        }

        internal System.Int32 TagKey { get; }
        internal System.Int64 TagValue { get; }
        internal System.Byte TagLevel { get; }
    }

    internal class InsertPersonNameExtendedQueryTagTableTypeV1TableValuedParameterDefinition : TableValuedParameterDefinition<InsertPersonNameExtendedQueryTagTableTypeV1Row>
    {
        internal InsertPersonNameExtendedQueryTagTableTypeV1TableValuedParameterDefinition(System.String parameterName) : base(parameterName, "dbo.InsertPersonNameExtendedQueryTagTableType_1")
        {
        }

        internal readonly IntColumn TagKey = new IntColumn("TagKey");
        internal readonly NVarCharColumn TagValue = new NVarCharColumn("TagValue", 200, "SQL_Latin1_General_CP1_CI_AI");
        internal readonly TinyIntColumn TagLevel = new TinyIntColumn("TagLevel");

        protected override global::System.Collections.Generic.IEnumerable<Column> Columns => new Column[] { TagKey, TagValue, TagLevel };

        protected override void FillSqlDataRecord(global::Microsoft.Data.SqlClient.Server.SqlDataRecord record, InsertPersonNameExtendedQueryTagTableTypeV1Row rowData)
        {
            TagKey.Set(record, 0, rowData.TagKey);
            TagValue.Set(record, 1, rowData.TagValue);
            TagLevel.Set(record, 2, rowData.TagLevel);
        }
    }

    internal struct InsertPersonNameExtendedQueryTagTableTypeV1Row
    {
        internal InsertPersonNameExtendedQueryTagTableTypeV1Row(System.Int32 TagKey, System.String TagValue, System.Byte TagLevel)
        {
            this.TagKey = TagKey;
            this.TagValue = TagValue;
            this.TagLevel = TagLevel;
        }

        internal System.Int32 TagKey { get; }
        internal System.String TagValue { get; }
        internal System.Byte TagLevel { get; }
    }

    internal class InsertStringExtendedQueryTagTableTypeV1TableValuedParameterDefinition : TableValuedParameterDefinition<InsertStringExtendedQueryTagTableTypeV1Row>
    {
        internal InsertStringExtendedQueryTagTableTypeV1TableValuedParameterDefinition(System.String parameterName) : base(parameterName, "dbo.InsertStringExtendedQueryTagTableType_1")
        {
        }

        internal readonly IntColumn TagKey = new IntColumn("TagKey");
        internal readonly NVarCharColumn TagValue = new NVarCharColumn("TagValue", 64);
        internal readonly TinyIntColumn TagLevel = new TinyIntColumn("TagLevel");

        protected override global::System.Collections.Generic.IEnumerable<Column> Columns => new Column[] { TagKey, TagValue, TagLevel };

        protected override void FillSqlDataRecord(global::Microsoft.Data.SqlClient.Server.SqlDataRecord record, InsertStringExtendedQueryTagTableTypeV1Row rowData)
        {
            TagKey.Set(record, 0, rowData.TagKey);
            TagValue.Set(record, 1, rowData.TagValue);
            TagLevel.Set(record, 2, rowData.TagLevel);
        }
    }

    internal struct InsertStringExtendedQueryTagTableTypeV1Row
    {
        internal InsertStringExtendedQueryTagTableTypeV1Row(System.Int32 TagKey, System.String TagValue, System.Byte TagLevel)
        {
            this.TagKey = TagKey;
            this.TagValue = TagValue;
            this.TagLevel = TagLevel;
        }

        internal System.Int32 TagKey { get; }
        internal System.String TagValue { get; }
        internal System.Byte TagLevel { get; }
    }
}