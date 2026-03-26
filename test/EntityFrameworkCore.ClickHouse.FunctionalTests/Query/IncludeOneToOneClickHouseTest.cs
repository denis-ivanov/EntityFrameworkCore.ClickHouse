using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class IncludeOneToOneClickHouseTest : IncludeOneToOneTestBase<IncludeOneToOneClickHouseTest.OneToOneQueryClickHouseFixture>
{
    public IncludeOneToOneClickHouseTest(OneToOneQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_address()
    {
        base.Include_address();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_address_EF_Property()
    {
        base.Include_address_EF_Property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_address_no_tracking()
    {
        base.Include_address_no_tracking();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_address_no_tracking_EF_Property()
    {
        base.Include_address_no_tracking_EF_Property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_address_shadow()
    {
        base.Include_address_shadow();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_address_when_person_already_tracked()
    {
        base.Include_address_when_person_already_tracked();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_person()
    {
        base.Include_person();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_person_EF_Property()
    {
        base.Include_person_EF_Property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_person_no_tracking()
    {
        base.Include_person_no_tracking();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_person_no_tracking_EF_Property()
    {
        base.Include_person_no_tracking_EF_Property();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_person_shadow()
    {
        base.Include_person_shadow();
    }

    [ConditionalFact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Include_person_when_address_already_tracked()
    {
        base.Include_person_when_address_already_tracked();
    }

    public class OneToOneQueryClickHouseFixture : OneToOneQueryFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;
    }
}
