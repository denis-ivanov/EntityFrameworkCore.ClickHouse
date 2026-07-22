using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingBulkUpdateClickHouseTest : ComplexTableSplittingBulkUpdateRelationalTestBase<ComplexTableSplittingClickHouseFixture>
{
    public ComplexTableSplittingBulkUpdateClickHouseTest(ComplexTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Delete_entity_with_associations()
    {
        await base.Delete_entity_with_associations();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_another_associate()
    {
        await base.Update_associate_to_another_associate();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_inline()
    {
        await base.Update_associate_to_inline();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_inline_with_lambda()
    {
        await base.Update_associate_to_inline_with_lambda();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_null()
    {
        await base.Update_associate_to_null();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_null_parameter()
    {
        await base.Update_associate_to_null_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_null_with_lambda()
    {
        await base.Update_associate_to_null_with_lambda();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_parameter()
    {
        await base.Update_associate_to_parameter();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_associate_with_null_required_property()
    {
        return base.Update_associate_with_null_required_property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Delete_required_associate() => base.Delete_required_associate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Delete_optional_associate() => base.Delete_optional_associate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_property_on_projected_associate_with_OrderBy_Skip() => base.Update_property_on_projected_associate_with_OrderBy_Skip();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_collection_to_parameter() => base.Update_collection_to_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_nested_collection_to_parameter() => base.Update_nested_collection_to_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_nested_collection_to_inline_with_lambda() => base.Update_nested_collection_to_inline_with_lambda();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_collection_referencing_the_original_collection() => base.Update_collection_referencing_the_original_collection();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_nested_collection_to_another_nested_collection() => base.Update_nested_collection_to_another_nested_collection();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_inside_structural_collection() => base.Update_inside_structural_collection();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_property_inside_associate() => base.Update_property_inside_associate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_property_inside_associate_with_special_chars() => base.Update_property_inside_associate_with_special_chars();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_property_inside_nested_associate() => base.Update_property_inside_nested_associate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_property_on_projected_associate() => base.Update_property_on_projected_associate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_nested_associate_to_parameter() => base.Update_nested_associate_to_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_nested_associate_to_another_nested_associate() => base.Update_nested_associate_to_another_nested_associate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_nested_associate_to_inline_with_lambda() => base.Update_nested_associate_to_inline_with_lambda();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_required_nested_associate_to_null() => base.Update_required_nested_associate_to_null();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_primitive_collection_to_constant() => base.Update_primitive_collection_to_constant();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_primitive_collection_to_parameter() => base.Update_primitive_collection_to_parameter();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_primitive_collection_to_another_collection() => base.Update_primitive_collection_to_another_collection();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_inside_primitive_collection() => base.Update_inside_primitive_collection();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_multiple_properties_inside_same_associate() => base.Update_multiple_properties_inside_same_associate();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_multiple_properties_inside_associates_and_on_entity_type() => base.Update_multiple_properties_inside_associates_and_on_entity_type();

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override Task Update_multiple_projected_associates_via_anonymous_type() => base.Update_multiple_projected_associates_via_anonymous_type();
}
