namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class IncompleteMappingInheritanceQueryClickHouseFixture : TPHInheritanceQueryClickHouseFixture
{
    public override bool IsDiscriminatorMappingComplete
        => false;
}
