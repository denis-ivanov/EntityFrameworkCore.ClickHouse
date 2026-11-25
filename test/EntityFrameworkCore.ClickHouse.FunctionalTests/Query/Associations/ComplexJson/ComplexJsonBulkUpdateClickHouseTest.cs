using Microsoft.EntityFrameworkCore.Query.Associations.ComplexJson;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexJson;

public class ComplexJsonBulkUpdateClickHouseTest : ComplexJsonBulkUpdateRelationalTestBase<ComplexJsonClickHouseFixture>
{
    public ComplexJsonBulkUpdateClickHouseTest(ComplexJsonClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Delete_entity_with_associations()
    {
        await base.Delete_entity_with_associations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_another_associate()
    {
        await base.Update_associate_to_another_associate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_inline()
    {
        await base.Update_associate_to_inline();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_inline_with_lambda()
    {
        await base.Update_associate_to_inline_with_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_null()
    {
        await base.Update_associate_to_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_null_parameter()
    {
        await base.Update_associate_to_null_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_null_with_lambda()
    {
        await base.Update_associate_to_null_with_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_to_parameter()
    {
        await base.Update_associate_to_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_associate_with_null_required_property()
    {
        await base.Update_associate_with_null_required_property();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_collection_to_parameter()
    {
        await base.Update_collection_to_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_inside_primitive_collection()
    {
        await base.Update_inside_primitive_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_multiple_projected_associates_via_anonymous_type()
    {
        await base.Update_multiple_projected_associates_via_anonymous_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_multiple_properties_inside_associates_and_on_entity_type()
    {
        await base.Update_multiple_properties_inside_associates_and_on_entity_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_multiple_properties_inside_same_associate()
    {
        await base.Update_multiple_properties_inside_same_associate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_nested_associate_to_another_nested_associate()
    {
        await base.Update_nested_associate_to_another_nested_associate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_nested_associate_to_inline_with_lambda()
    {
        await base.Update_nested_associate_to_inline_with_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_nested_associate_to_parameter()
    {
        await base.Update_nested_associate_to_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_nested_collection_to_another_nested_collection()
    {
        await base.Update_nested_collection_to_another_nested_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_nested_collection_to_inline_with_lambda()
    {
        await base.Update_nested_collection_to_inline_with_lambda();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_nested_collection_to_parameter()
    {
        await base.Update_nested_collection_to_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_primitive_collection_to_another_collection()
    {
        await base.Update_primitive_collection_to_another_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_primitive_collection_to_parameter()
    {
        await base.Update_primitive_collection_to_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_primitive_collection_to_constant()
    {
        await base.Update_primitive_collection_to_constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_property_inside_associate()
    {
        await base.Update_property_inside_associate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_property_inside_associate_with_special_chars()
    {
        await base.Update_property_inside_associate_with_special_chars();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_property_inside_nested_associate()
    {
        await base.Update_property_inside_nested_associate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_property_on_projected_associate()
    {
        await base.Update_property_on_projected_associate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_required_nested_associate_to_null()
    {
        await base.Update_required_nested_associate_to_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Delete_optional_associate()
    {
        await base.Delete_optional_associate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Delete_required_associate()
    {
        await base.Delete_required_associate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_collection_referencing_the_original_collection()
    {
        await base.Update_collection_referencing_the_original_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_inside_structural_collection()
    {
        await base.Update_inside_structural_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Update_property_on_projected_associate_with_OrderBy_Skip()
    {
        await base.Update_property_on_projected_associate_with_OrderBy_Skip();
    }
}
