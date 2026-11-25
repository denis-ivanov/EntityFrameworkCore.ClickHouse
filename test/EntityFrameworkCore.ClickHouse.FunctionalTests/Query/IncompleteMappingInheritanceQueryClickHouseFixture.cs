namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class IncompleteMappingInheritanceQueryClickHouseFixture : TPHInheritanceQueryClickHouseFixture
{
    protected override string StoreName => nameof(IncompleteMappingInheritanceQueryClickHouseFixture);

    public override bool IsDiscriminatorMappingComplete
        => false;
}
