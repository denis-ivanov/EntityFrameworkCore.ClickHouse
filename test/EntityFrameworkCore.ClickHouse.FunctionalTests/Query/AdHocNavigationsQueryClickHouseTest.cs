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
    
#if NET10_0
    protected override ITestStoreFactory TestStoreFactory
        => ClickHouseTestStoreFactory.Instance;
#else
    protected override ITestStoreFactory NonSharedTestStoreFactory
        => ClickHouseTestStoreFactory.WithClientKeys;
#endif

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Select_enumerable_navigation_backed_by_collection(bool async, bool split)
    {
        await base.Select_enumerable_navigation_backed_by_collection(async, split);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Reference_include_on_derived_type_with_sibling_works()
    {
        await base.Reference_include_on_derived_type_with_sibling_works();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_optional_reference_collection()
    {
        await base.Include_collection_optional_reference_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Collection_without_setter_materialized_correctly()
    {
        await base.Collection_without_setter_materialized_correctly();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_with_OfType_base()
    {
        await base.Include_collection_with_OfType_base();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Customer_collections_materialize_properly()
    {
        await base.Customer_collections_materialize_properly();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Count_member_over_IReadOnlyCollection_works(bool async)
    {
        await base.Count_member_over_IReadOnlyCollection_works(async);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Projection_with_multiple_includes_and_subquery_with_set_operation()
    {
        await base.Projection_with_multiple_includes_and_subquery_with_set_operation();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Using_explicit_interface_implementation_as_navigation_works()
    {
        await base.Using_explicit_interface_implementation_as_navigation_works();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Let_multiple_references_with_reference_to_outer()
    {
        await base.Let_multiple_references_with_reference_to_outer();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task SelectMany_and_collection_in_projection_in_FirstOrDefault()
    {
        await base.SelectMany_and_collection_in_projection_in_FirstOrDefault();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_collection_works_when_defined_on_intermediate_type()
    {
        await base.Include_collection_works_when_defined_on_intermediate_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task ThenInclude_with_interface_navigations()
    {
        await base.ThenInclude_with_interface_navigations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Correlated_collection_correctly_associates_entities_with_byte_array_keys()
    {
        await base.Correlated_collection_correctly_associates_entities_with_byte_array_keys();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Cycles_in_auto_include()
    {
        await base.Cycles_in_auto_include();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Include_with_order_by_on_interface_key()
    {
        await base.Include_with_order_by_on_interface_key();
    }
}