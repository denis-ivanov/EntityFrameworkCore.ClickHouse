using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class ComplexTypeQueryClickHouseTest : ComplexTypeQueryRelationalTestBase<ComplexTypeQueryClickHouseTest.ComplexTypeQueryClickHouseFixture>
{
    public ComplexTypeQueryClickHouseTest(ComplexTypeQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_on_required_property_inside_required_complex_type_on_optional_navigation(bool async)
    {
        await base.Filter_on_required_property_inside_required_complex_type_on_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_on_required_property_inside_required_complex_type_on_required_navigation(bool async)
    {
        await base.Filter_on_required_property_inside_required_complex_type_on_required_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_on_required_property_inside_required_struct_complex_type_on_optional_navigation(bool async)
    {
        await base.Filter_on_required_property_inside_required_struct_complex_type_on_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Filter_on_required_property_inside_required_struct_complex_type_on_required_navigation(bool async)
    {
        await base.Filter_on_required_property_inside_required_struct_complex_type_on_required_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_complex_type_via_optional_navigation(bool async)
    {
        await base.Project_complex_type_via_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_nullable_struct_complex_type_via_optional_navigation(bool async)
    {
        await base.Project_nullable_struct_complex_type_via_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_struct_complex_type_via_optional_navigation(bool async)
    {
        await base.Project_struct_complex_type_via_optional_navigation(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_complex_from_optional_navigation_using_conditional(bool async)
    {
        await base.Projecting_complex_from_optional_navigation_using_conditional(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projecting_property_of_complex_type_using_left_join_with_pushdown(bool async)
    {
        await base.Projecting_property_of_complex_type_using_left_join_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Same_entity_with_complex_type_projected_twice_with_pushdown_as_part_of_another_projection(bool async)
    {
        await base.Same_entity_with_complex_type_projected_twice_with_pushdown_as_part_of_another_projection(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_complex_type(bool async)
    {
        await base.Union_complex_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_entity_type_containing_complex_property(bool async)
    {
        await base.Union_entity_type_containing_complex_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_entity_type_containing_struct_complex_property(bool async)
    {
        await base.Union_entity_type_containing_struct_complex_property(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_of_same_entity_with_nested_complex_type_projected_twice_with_double_pushdown(bool async)
    {
        await base.Union_of_same_entity_with_nested_complex_type_projected_twice_with_double_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_of_same_entity_with_nested_complex_type_projected_twice_with_pushdown(bool async)
    {
        await base.Union_of_same_entity_with_nested_complex_type_projected_twice_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_of_same_nested_complex_type_projected_twice_with_double_pushdown(bool async)
    {
        await base.Union_of_same_nested_complex_type_projected_twice_with_double_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_of_same_nested_complex_type_projected_twice_with_pushdown(bool async)
    {
        await base.Union_of_same_nested_complex_type_projected_twice_with_pushdown(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_property_in_complex_type(bool async)
    {
        await base.Union_property_in_complex_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_property_in_struct_complex_type(bool async)
    {
        await base.Union_property_in_struct_complex_type(async);
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Union_struct_complex_type(bool async)
    {
        await base.Union_struct_complex_type(async);
    }

    public class ComplexTypeQueryClickHouseFixture : ComplexTypeQueryRelationalFixtureBase
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
    }
}
