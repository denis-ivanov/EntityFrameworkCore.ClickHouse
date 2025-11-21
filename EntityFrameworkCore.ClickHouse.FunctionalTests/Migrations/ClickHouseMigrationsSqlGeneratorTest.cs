using ClickHouse.EntityFrameworkCore;
using ClickHouse.EntityFrameworkCore.Infrastructure;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Migrations;

public class ClickHouseMigrationsSqlGeneratorTest : MigrationsSqlGeneratorTestBase
{
    public ClickHouseMigrationsSqlGeneratorTest()
        : base(
            ClickHouseTestHelpers.Instance,
            new ServiceCollection()/*.AddEntityFrameworkClickHouseNetTopologySuite()*/,
            ClickHouseTestHelpers.Instance.AddProviderOptions(
                ((IRelationalDbContextOptionsBuilderInfrastructure)
                    new ClickHouseDbContextOptionsBuilder(new DbContextOptionsBuilder())/*.UseNetTopologySuite()*/)
                .OptionsBuilder).Options)
    {
    }

    [ConditionalFact]
    public override void AddColumnOperation_with_fixed_length_no_model()
    {
        base.AddColumnOperation_with_fixed_length_no_model();
    }

    [ConditionalFact]
    public override void AddColumnOperation_without_column_type()
    {
        base.AddColumnOperation_without_column_type();
    }

    [ConditionalFact]
    public override void AddColumnOperation_with_unicode_overridden()
    {
        base.AddColumnOperation_with_unicode_overridden();
    }

    [ConditionalFact]
    public override void AddColumnOperation_with_unicode_no_model()
    {
        base.AddColumnOperation_with_unicode_no_model();
    }

    [ConditionalFact]
    public override void AddColumnOperation_with_maxLength_overridden()
    {
        base.AddColumnOperation_with_maxLength_overridden();
    }

    [ConditionalFact]
    public override void AddColumnOperation_with_maxLength_no_model()
    {
        base.AddColumnOperation_with_maxLength_no_model();
    }

    [ConditionalFact]
    public override void AddColumnOperation_with_precision_and_scale_overridden()
    {
        base.AddColumnOperation_with_precision_and_scale_overridden();
    }

    [ConditionalFact]
    public override void AddColumnOperation_with_precision_and_scale_no_model()
    {
        base.AddColumnOperation_with_precision_and_scale_no_model();
    }

    [ConditionalFact]
    public override void AddForeignKeyOperation_without_principal_columns()
    {
        var exception = Assert.Throws<NotSupportedException>(() => base.AddForeignKeyOperation_without_principal_columns());
        Assert.Equal(ClickHouseExceptions.DoesNotSupportForeignKeys, exception.Message);
    }

    [ConditionalFact]
    public override void AlterColumnOperation_without_column_type()
    {
        base.AlterColumnOperation_without_column_type();
    }

    [ConditionalFact]
    public override void RenameTableOperation_legacy()
    {
        base.RenameTableOperation_legacy();
    }

    [ConditionalFact]
    public override void RenameTableOperation()
    {
        base.RenameTableOperation();
    }

    [ConditionalFact]
    public override void SqlOperation()
    {
        base.SqlOperation();
    }

    [ConditionalFact(Skip = "TBD")]
    public override void InsertDataOperation_all_args_spatial()
    {
        base.InsertDataOperation_all_args_spatial();
    }

    [ConditionalFact]
    public override void InsertDataOperation_required_args()
    {
        base.InsertDataOperation_required_args();
    }

    [ConditionalFact]
    public override void InsertDataOperation_required_args_composite()
    {
        base.InsertDataOperation_required_args_composite();
    }

    [ConditionalFact]
    public override void InsertDataOperation_required_args_multiple_rows()
    {
        base.InsertDataOperation_required_args_multiple_rows();
    }

    [ConditionalFact(Skip = "TBD")]
    public override void InsertDataOperation_throws_for_unsupported_column_types()
    {
        base.InsertDataOperation_throws_for_unsupported_column_types();
    }

    [ConditionalFact]
    public override void DeleteDataOperation_all_args()
    {
        base.DeleteDataOperation_all_args();
    }

    [ConditionalFact]
    public override void DeleteDataOperation_all_args_composite()
    {
        base.DeleteDataOperation_all_args_composite();
    }

    [ConditionalFact]
    public override void DeleteDataOperation_required_args()
    {
        base.DeleteDataOperation_required_args();
    }

    [ConditionalFact]
    public override void DeleteDataOperation_required_args_composite()
    {
        base.DeleteDataOperation_required_args_composite();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_all_args()
    {
        base.UpdateDataOperation_all_args();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_all_args_composite()
    {
        base.UpdateDataOperation_all_args_composite();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_all_args_composite_multi()
    {
        base.UpdateDataOperation_all_args_composite_multi();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_all_args_multi()
    {
        base.UpdateDataOperation_all_args_multi();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_required_args()
    {
        base.UpdateDataOperation_required_args();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_required_args_multiple_rows()
    {
        base.UpdateDataOperation_required_args_multiple_rows();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_required_args_composite()
    {
        base.UpdateDataOperation_required_args_composite();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_required_args_composite_multi()
    {
        base.UpdateDataOperation_required_args_composite_multi();
    }

    [ConditionalFact]
    public override void UpdateDataOperation_required_args_multi()
    {
        base.UpdateDataOperation_required_args_multi();
    }

    [ConditionalTheory]
    [InlineData(false)]
    [InlineData(true)]
    public override void DefaultValue_with_line_breaks(bool isUnicode)
    {
        base.DefaultValue_with_line_breaks(isUnicode);
    }

    [ConditionalTheory]
    [InlineData(false)]
    [InlineData(true)]
    public override void DefaultValue_with_line_breaks_2(bool isUnicode)
    {
        base.DefaultValue_with_line_breaks_2(isUnicode);
    }

    public override void Sequence_restart_operation(long? startsAt)
    {
        var exception = Assert.Throws<NotSupportedException>(() => base.Sequence_restart_operation(startsAt));
        Assert.Equal(ClickHouseExceptions.DoesNotSupportSequences, exception.Message);
    }

    protected override string GetGeometryCollectionStoreType()
    {
        throw new System.NotImplementedException();
    }
}
