using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class NorthwindFunctionsQueryClickHouseTest : NorthwindFunctionsQueryRelationalTestBase<
    NorthwindQueryClickHouseFixture<NoopModelCustomizer>>
{
    public NorthwindFunctionsQueryClickHouseTest(NorthwindQueryClickHouseFixture<NoopModelCustomizer> fixture) : base(fixture)
    {
    }
    
    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Datetime_subtraction_TotalDays(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Order_by_length_twice_followed_by_projection_of_naked_collection_navigation(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task String_Compare_nested(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task String_Compare_to_nested(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Regex_IsMatch_MethodCall_constant_input(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Trim_with_char_argument_in_predicate(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Trim_with_char_array_argument_in_predicate(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task TrimEnd_with_char_argument_in_predicate(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task TrimEnd_with_char_array_argument_in_predicate(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task TrimStart_with_char_argument_in_predicate(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task TrimStart_with_char_array_argument_in_predicate(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_math_log_new_base(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Where_mathf_log_new_base(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Indexof_with_constant_starting_position(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Indexof_with_parameter_starting_position(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Substring_with_two_args_with_Index_of(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_round_works_correctly_in_projection(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_round_works_correctly_in_projection_2(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_truncate_works_correctly_in_projection(bool async)
    {
        return Task.CompletedTask;
    }

    [ConditionalTheory(Skip = "TBD")]
    [MemberData(nameof(IsAsyncData))]
    public override Task Sum_over_truncate_works_correctly_in_projection_2(bool async)
    {
        return Task.CompletedTask;
    }
}
