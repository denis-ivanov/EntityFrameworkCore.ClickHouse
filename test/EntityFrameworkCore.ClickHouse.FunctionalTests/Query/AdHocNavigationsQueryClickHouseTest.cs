using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class AdHocNavigationsQueryClickHouseTest : AdHocNavigationsQueryRelationalTestBase
{
    public AdHocNavigationsQueryClickHouseTest(NonSharedFixture fixture) : base(fixture)
    {
    }
    
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_enumerable_navigation_backed_by_collection(bool async, bool split)
    {
        await base.Select_enumerable_navigation_backed_by_collection(async, split);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Reference_include_on_derived_type_with_sibling_works()
    {
        await base.Reference_include_on_derived_type_with_sibling_works();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_optional_reference_collection()
    {
        await base.Include_collection_optional_reference_collection();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_without_setter_materialized_correctly()
    {
        await base.Collection_without_setter_materialized_correctly();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_OfType_base()
    {
        await base.Include_collection_with_OfType_base();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Customer_collections_materialize_properly()
    {
        await base.Customer_collections_materialize_properly();
    }

    [ConditionalTheory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_member_over_IReadOnlyCollection_works(bool async)
    {
        await base.Count_member_over_IReadOnlyCollection_works(async);
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projection_with_multiple_includes_and_subquery_with_set_operation()
    {
        await base.Projection_with_multiple_includes_and_subquery_with_set_operation();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Using_explicit_interface_implementation_as_navigation_works()
    {
        await base.Using_explicit_interface_implementation_as_navigation_works();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Let_multiple_references_with_reference_to_outer()
    {
        await base.Let_multiple_references_with_reference_to_outer();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_and_collection_in_projection_in_FirstOrDefault()
    {
        await base.SelectMany_and_collection_in_projection_in_FirstOrDefault();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_works_when_defined_on_intermediate_type()
    {
        await base.Include_collection_works_when_defined_on_intermediate_type();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ThenInclude_with_interface_navigations()
    {
        await base.ThenInclude_with_interface_navigations();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_correctly_associates_entities_with_byte_array_keys()
    {
        await base.Correlated_collection_correctly_associates_entities_with_byte_array_keys();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cycles_in_auto_include()
    {
        await base.Cycles_in_auto_include();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_order_by_on_interface_key()
    {
        await base.Include_with_order_by_on_interface_key();
    }
}