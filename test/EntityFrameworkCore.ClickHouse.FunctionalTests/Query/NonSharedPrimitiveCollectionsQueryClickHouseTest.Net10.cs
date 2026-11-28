using ClickHouse.EntityFrameworkCore.Infrastructure;
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NonSharedPrimitiveCollectionsQueryClickHouseTest : NonSharedPrimitiveCollectionsQueryRelationalTestBase
{
    public NonSharedPrimitiveCollectionsQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_byte()
    {
        await base.Array_of_byte();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_inside_json_owned_entity()
    {
        await base.Column_collection_inside_json_owned_entity();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_default_mode(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_default_mode(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_default_mode(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Contains_with_default_mode(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Constant(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Constant(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_default_mode_EF_Constant(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Contains_with_default_mode_EF_Constant(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Parameter(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Parameter(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_default_mode_EF_Parameter(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Contains_with_default_mode_EF_Parameter(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_default_mode_EF_MultipleParameters(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_default_mode_EF_MultipleParameters(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_default_mode_EF_MultipleParameters(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Contains_with_default_mode_EF_MultipleParameters(mode);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_parameter_bucketization()
    {
        await base.Parameter_collection_Contains_parameter_bucketization();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_string()
    {
        await base.Array_of_string();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_int()
    {
        await base.Array_of_int();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_long()
    {
        await base.Array_of_long();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_short()
    {
        await base.Array_of_short();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_double()
    {
        await base.Array_of_double();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_float()
    {
        await base.Array_of_float();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_decimal()
    {
        await base.Array_of_decimal();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_DateTime()
    {
        await base.Array_of_DateTime();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_DateTime_with_milliseconds()
    {
        await base.Array_of_DateTime_with_milliseconds();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_DateTime_with_microseconds()
    {
        await base.Array_of_DateTime_with_microseconds();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_DateOnly()
    {
        await base.Array_of_DateOnly();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_TimeOnly()
    {
        await base.Array_of_TimeOnly();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_TimeOnly_with_milliseconds()
    {
        await base.Array_of_TimeOnly_with_milliseconds();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_TimeOnly_with_microseconds()
    {
        await base.Array_of_TimeOnly_with_microseconds();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_DateTimeOffset()
    {
        await base.Array_of_DateTimeOffset();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_bool()
    {
        await base.Array_of_bool();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_Guid()
    {
        await base.Array_of_Guid();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_byte_array()
    {
        await base.Array_of_byte_array();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Array_of_enum()
    {
        await base.Array_of_enum();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multidimensional_array_is_not_supported()
    {
        await base.Multidimensional_array_is_not_supported();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_with_inferred_value_converter()
    {
        await base.Parameter_with_inferred_value_converter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Constant_with_inferred_value_converter()
    {
        await base.Constant_with_inferred_value_converter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_in_query_filter()
    {
        await base.Inline_collection_in_query_filter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_from_entity_type_with_owned()
    {
        await base.Project_collection_from_entity_type_with_owned();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_over_primitive_collection_on_inheritance_derived_type()
    {
        await base.Subquery_over_primitive_collection_on_inheritance_derived_type();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_enum_Cast_from_different_enum_type(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_of_enum_Cast_from_different_enum_type(mode);
    }

    protected override DbContextOptionsBuilder SetParameterizedCollectionMode(
        DbContextOptionsBuilder optionsBuilder,
        ParameterTranslationMode parameterizedCollectionMode)
    {
        new ClickHouseDbContextOptionsBuilder(optionsBuilder).UseParameterizedCollectionMode(parameterizedCollectionMode);

        return optionsBuilder;
    }

    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
}
