using Microsoft.EntityFrameworkCore.Query.Associations.ComplexTableSplitting;
using Xunit.Abstractions;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query.Associations.ComplexTableSplitting;

public class ComplexTableSplittingStructuralEqualityClickHouseTest : ComplexTableSplittingStructuralEqualityRelationalTestBase<ComplexTableSplittingClickHouseFixture>
{
    public ComplexTableSplittingStructuralEqualityClickHouseTest(ComplexTableSplittingClickHouseFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture, testOutputHelper)
    {
    }
}