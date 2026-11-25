#if NET11_0_OR_GREATER
using ClickHouse.EntityFrameworkCore.Infrastructure;
#endif
using EntityFrameworkCore.ClickHouse.FunctionalTests.TestUtilities;
#if NET11_0_OR_GREATER
using Microsoft.EntityFrameworkCore;
#endif
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.TestUtilities;
using System.Threading.Tasks;
using Xunit;

namespace EntityFrameworkCore.ClickHouse.FunctionalTests.Query;

public class PrimitiveCollectionsQueryClickHouseTest : PrimitiveCollectionsQueryRelationalTestBase<PrimitiveCollectionsQueryClickHouseTest.PrimitiveCollectionsQueryClickHouseFixture>
{
#if NET11_0_OR_GREATER
    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_inside_json_owned_entity()
    {
        await base.Column_collection_inside_json_owned_entity();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_default_mode(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_default_mode(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_default_mode(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Contains_with_default_mode(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Constant(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Constant(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_default_mode_EF_Constant(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Contains_with_default_mode_EF_Constant(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Parameter(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_default_mode_EF_Parameter(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_default_mode_EF_Parameter(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Contains_with_default_mode_EF_Parameter(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_default_mode_EF_MultipleParameters(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_default_mode_EF_MultipleParameters(mode);
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_default_mode_EF_MultipleParameters(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_Contains_with_default_mode_EF_MultipleParameters(mode);
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_parameter_bucketization()
    {
        await base.Parameter_collection_Contains_parameter_bucketization();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Multidimensional_array_is_not_supported()
    {
        await base.Multidimensional_array_is_not_supported();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_with_inferred_value_converter()
    {
        await base.Parameter_with_inferred_value_converter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Constant_with_inferred_value_converter()
    {
        await base.Constant_with_inferred_value_converter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_in_query_filter()
    {
        await base.Inline_collection_in_query_filter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_from_entity_type_with_owned()
    {
        await base.Project_collection_from_entity_type_with_owned();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Subquery_over_primitive_collection_on_inheritance_derived_type()
    {
        await base.Subquery_over_primitive_collection_on_inheritance_derived_type();
    }

    [Theory(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_enum_Cast_from_different_enum_type(ParameterTranslationMode mode)
    {
        await base.Parameter_collection_of_enum_Cast_from_different_enum_type(mode);
    }

    protected override DbContextOptionsBuilder SetParameterizedCollectionMode(
        DbContextOptionsBuilder optionsBuilder,
        ParameterTranslationMode parameterizedCollectionMode)
    {
        new ClickHouseDbContextOptionsBuilder(optionsBuilder).UseParameterizedCollectionMode(parameterizedCollectionMode);

        return optionsBuilder;
    }

#endif
    public PrimitiveCollectionsQueryClickHouseTest(PrimitiveCollectionsQueryClickHouseFixture fixture) : base(fixture)
    {
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Concat_parameter_collection_equality_inline_collection()
    {
        await base.Column_collection_Concat_parameter_collection_equality_inline_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_equality_inline_collection_with_parameters()
    {
        await base.Column_collection_equality_inline_collection_with_parameters();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Where_equality_inline_collection()
    {
        await base.Column_collection_Where_equality_inline_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Count_with_zero_values()
    {
        await base.Inline_collection_Count_with_zero_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override void Parameter_collection_in_subquery_and_Convert_as_compiled_query()
    {
        base.Parameter_collection_in_subquery_and_Convert_as_compiled_query();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_in_subquery_Union_another_parameter_collection_as_compiled_query()
    {
        await base.Parameter_collection_in_subquery_Union_another_parameter_collection_as_compiled_query();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_inline_collection_with_Concat()
    {
        await base.Project_inline_collection_with_Concat();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Any()
    {
        await base.Column_collection_Any();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Contains_over_subquery()
    {
        await base.Column_collection_Contains_over_subquery();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Count_method()
    {
        await base.Column_collection_Count_method();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Count_with_predicate()
    {
        await base.Column_collection_Count_with_predicate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Distinct()
    {
        await base.Column_collection_Distinct();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_ElementAt()
    {
        await base.Column_collection_ElementAt();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_equality_inline_collection()
    {
        await base.Column_collection_equality_inline_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_First()
    {
        await base.Column_collection_First();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_FirstOrDefault()
    {
        await base.Column_collection_FirstOrDefault();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_index_beyond_end()
    {
        await base.Column_collection_index_beyond_end();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_equality_parameter_collection()
    {
        await base.Column_collection_equality_parameter_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_in_subquery_Union_parameter_collection()
    {
        await base.Column_collection_in_subquery_Union_parameter_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_index_datetime()
    {
        await base.Column_collection_index_datetime();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_index_int()
    {
        await base.Column_collection_index_int();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_index_string()
    {
        await base.Column_collection_index_string();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Length()
    {
        await base.Column_collection_Length();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Intersect_inline_collection()
    {
        await base.Column_collection_Intersect_inline_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Join_parameter_collection()
    {
        await base.Column_collection_Join_parameter_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_of_ints_Contains()
    {
        await base.Inline_collection_of_ints_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_of_nullable_ints_Contains()
    {
        await base.Inline_collection_of_nullable_ints_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_of_nullable_ints_Contains_null()
    {
        await base.Inline_collection_of_nullable_ints_Contains_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Count_with_one_value()
    {
        await base.Inline_collection_Count_with_one_value();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Count_with_two_values()
    {
        await base.Inline_collection_Count_with_two_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Count_with_three_values()
    {
        await base.Inline_collection_Count_with_three_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_zero_values()
    {
        await base.Inline_collection_Contains_with_zero_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_one_value()
    {
        await base.Inline_collection_Contains_with_one_value();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_two_values()
    {
        await base.Inline_collection_Contains_with_two_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_three_values()
    {
        await base.Inline_collection_Contains_with_three_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_all_parameters()
    {
        await base.Inline_collection_Contains_with_all_parameters();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_constant_and_parameter()
    {
        await base.Inline_collection_Contains_with_constant_and_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_mixed_value_types()
    {
        await base.Inline_collection_Contains_with_mixed_value_types();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_List_Contains_with_mixed_value_types()
    {
        await base.Inline_collection_List_Contains_with_mixed_value_types();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_as_Any_with_predicate()
    {
        await base.Inline_collection_Contains_as_Any_with_predicate();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_negated_Contains_as_All()
    {
        await base.Inline_collection_negated_Contains_as_All();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Min_with_two_values()
    {
        await base.Inline_collection_Min_with_two_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_List_Min_with_two_values()
    {
        await base.Inline_collection_List_Min_with_two_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Max_with_two_values()
    {
        await base.Inline_collection_Max_with_two_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_List_Max_with_two_values()
    {
        await base.Inline_collection_List_Max_with_two_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Min_with_three_values()
    {
        await base.Inline_collection_Min_with_three_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_List_Min_with_three_values()
    {
        await base.Inline_collection_List_Min_with_three_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Max_with_three_values()
    {
        await base.Inline_collection_Max_with_three_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_List_Max_with_three_values()
    {
        await base.Inline_collection_List_Max_with_three_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_of_nullable_value_type_Min()
    {
        await base.Inline_collection_of_nullable_value_type_Min();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_of_nullable_value_type_Max()
    {
        await base.Inline_collection_of_nullable_value_type_Max();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_of_nullable_value_type_with_null_Min()
    {
        await base.Inline_collection_of_nullable_value_type_with_null_Min();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_of_nullable_value_type_with_null_Max()
    {
        await base.Inline_collection_of_nullable_value_type_with_null_Max();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_with_single_parameter_element_Contains()
    {
        await base.Inline_collection_with_single_parameter_element_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_with_single_parameter_element_Count()
    {
        await base.Inline_collection_with_single_parameter_element_Count();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_EF_Parameter()
    {
        await base.Inline_collection_Contains_with_EF_Parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Contains_with_IEnumerable_EF_Parameter()
    {
        await base.Inline_collection_Contains_with_IEnumerable_EF_Parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Count_with_column_predicate_with_EF_Parameter()
    {
        await base.Inline_collection_Count_with_column_predicate_with_EF_Parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count()
    {
        await base.Parameter_collection_Count();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_ints_Contains_int()
    {
        await base.Parameter_collection_of_ints_Contains_int();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_HashSet_of_ints_Contains_int()
    {
        await base.Parameter_collection_HashSet_of_ints_Contains_int();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_ImmutableArray_of_ints_Contains_int()
    {
        await base.Parameter_collection_ImmutableArray_of_ints_Contains_int();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_ints_Contains_nullable_int()
    {
        await base.Parameter_collection_of_ints_Contains_nullable_int();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_nullable_ints_Contains_int()
    {
        await base.Parameter_collection_of_nullable_ints_Contains_int();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_nullable_ints_Contains_nullable_int()
    {
        await base.Parameter_collection_of_nullable_ints_Contains_nullable_int();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_structs_Contains_struct()
    {
        await base.Parameter_collection_of_structs_Contains_struct();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_structs_Contains_nullable_struct()
    {
        await base.Parameter_collection_of_structs_Contains_nullable_struct();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_structs_Contains_nullable_struct_with_nullable_comparer()
    {
        await base.Parameter_collection_of_structs_Contains_nullable_struct_with_nullable_comparer();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_nullable_structs_Contains_struct()
    {
        await base.Parameter_collection_of_nullable_structs_Contains_struct();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_nullable_structs_Contains_nullable_struct()
    {
        await base.Parameter_collection_of_nullable_structs_Contains_nullable_struct();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_nullable_structs_Contains_nullable_struct_with_nullable_comparer()
    {
        await base.Parameter_collection_of_nullable_structs_Contains_nullable_struct_with_nullable_comparer();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_strings_Contains_string()
    {
        await base.Parameter_collection_of_strings_Contains_string();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_strings_Contains_nullable_string()
    {
        await base.Parameter_collection_of_strings_Contains_nullable_string();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_nullable_strings_Contains_string()
    {
        await base.Parameter_collection_of_nullable_strings_Contains_string();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_nullable_strings_Contains_nullable_string()
    {
        await base.Parameter_collection_of_nullable_strings_Contains_nullable_string();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_DateTimes_Contains()
    {
        await base.Parameter_collection_of_DateTimes_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_bools_Contains()
    {
        await base.Parameter_collection_of_bools_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_enums_Contains()
    {
        await base.Parameter_collection_of_enums_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_null_Contains()
    {
        await base.Parameter_collection_null_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_empty_Contains()
    {
        await base.Parameter_collection_empty_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_empty_Join()
    {
        await base.Parameter_collection_empty_Join();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Contains_with_EF_Constant()
    {
        await base.Parameter_collection_Contains_with_EF_Constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Where_with_EF_Constant_Where_Any()
    {
        await base.Parameter_collection_Where_with_EF_Constant_Where_Any();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_column_predicate_with_EF_Constant()
    {
        await base.Parameter_collection_Count_with_column_predicate_with_EF_Constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_huge_number_of_values()
    {
        await base.Parameter_collection_Count_with_huge_number_of_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_huge_number_of_values_over_5_operations()
    {
        await base.Parameter_collection_Count_with_huge_number_of_values_over_5_operations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_huge_number_of_values_over_5_operations_same_parameter()
    {
        await base.Parameter_collection_Count_with_huge_number_of_values_over_5_operations_same_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#if NET10_0
    public override async Task Parameter_collection_Count_with_huge_number_of_values_over_2_operations_same_parameter_different_type_mapping()
    {
        await base.Parameter_collection_Count_with_huge_number_of_values_over_2_operations_same_parameter_different_type_mapping();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task Parameter_collection_Count_with_huge_number_of_values_over_5_operations_forced_constants()
    {
        await base.Parameter_collection_Count_with_huge_number_of_values_over_5_operations_forced_constants();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Count_with_huge_number_of_values_over_5_operations_mixed_parameters_constants()
    {
        await base.Parameter_collection_Count_with_huge_number_of_values_over_5_operations_mixed_parameters_constants();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_ints_Contains_int_with_huge_number_of_values()
    {
        await base.Parameter_collection_of_ints_Contains_int_with_huge_number_of_values();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_5_operations()
    {
        await base.Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_5_operations();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_5_operations_same_parameter()
    {
        await base.Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_5_operations_same_parameter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#if NET10_0
    public override async Task Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_2_operations_same_parameter_different_type_mapping()
    {
        await base.Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_2_operations_same_parameter_different_type_mapping();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
#endif
    public override async Task Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_5_operations_forced_constants()
    {
        await base.Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_5_operations_forced_constants();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_5_operations_mixed_parameters_constants()
    {
        await base.Parameter_collection_of_ints_Contains_int_with_huge_number_of_values_over_5_operations_mixed_parameters_constants();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_of_ints_Contains()
    {
        await base.Column_collection_of_ints_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_of_nullable_ints_Contains()
    {
        await base.Column_collection_of_nullable_ints_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_of_nullable_ints_Contains_null()
    {
        await base.Column_collection_of_nullable_ints_Contains_null();
#if NET10_0
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_of_strings_contains_null()
    {
        await base.Column_collection_of_strings_contains_null();
#endif
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_of_nullable_strings_contains_null()
    {
        await base.Column_collection_of_nullable_strings_contains_null();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_of_bools_Contains()
    {
        await base.Column_collection_of_bools_Contains();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_Enumerable()
    {
        await base.Contains_on_Enumerable();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_on_MemoryExtensions()
    {
        await base.Contains_on_MemoryExtensions();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Contains_with_MemoryExtensions_with_null_comparer()
    {
        await base.Contains_with_MemoryExtensions_with_null_comparer();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Where_Count()
    {
        await base.Column_collection_Where_Count();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nullable_reference_column_collection_index_equals_nullable_column()
    {
        await base.Nullable_reference_column_collection_index_equals_nullable_column();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Non_nullable_reference_column_collection_index_equals_nullable_column()
    {
        await base.Non_nullable_reference_column_collection_index_equals_nullable_column();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_index_Column()
    {
        await base.Inline_collection_index_Column();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_index_Column_with_EF_Constant()
    {
        await base.Inline_collection_index_Column_with_EF_Constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_value_index_Column()
    {
        await base.Inline_collection_value_index_Column();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_List_value_index_Column()
    {
        await base.Inline_collection_List_value_index_Column();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_index_Column_equal_Column()
    {
        await base.Parameter_collection_index_Column_equal_Column();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_index_Column_equal_constant()
    {
        await base.Parameter_collection_index_Column_equal_constant();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Single()
    {
        await base.Column_collection_Single();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_SingleOrDefault()
    {
        await base.Column_collection_SingleOrDefault();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Skip()
    {
        await base.Column_collection_Skip();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Take()
    {
        await base.Column_collection_Take();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Skip_Take()
    {
        await base.Column_collection_Skip_Take();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Where_Skip()
    {
        await base.Column_collection_Where_Skip();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Where_Take()
    {
        await base.Column_collection_Where_Take();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Where_Skip_Take()
    {
        await base.Column_collection_Where_Skip_Take();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_OrderByDescending_ElementAt()
    {
        await base.Column_collection_OrderByDescending_ElementAt();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Where_ElementAt()
    {
        await base.Column_collection_Where_ElementAt();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_SelectMany()
    {
        await base.Column_collection_SelectMany();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_SelectMany_with_filter()
    {
        await base.Column_collection_SelectMany_with_filter();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_SelectMany_with_Select_to_anonymous_type()
    {
        await base.Column_collection_SelectMany_with_Select_to_anonymous_type();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_projection_from_top_level()
    {
        await base.Column_collection_projection_from_top_level();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Join_ordered_column_collection()
    {
        await base.Inline_collection_Join_ordered_column_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_Concat_column_collection()
    {
        await base.Parameter_collection_Concat_column_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_with_type_inference_for_JsonScalarExpression()
    {
        await base.Parameter_collection_with_type_inference_for_JsonScalarExpression();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Union_parameter_collection()
    {
        await base.Column_collection_Union_parameter_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Inline_collection_Except_column_collection()
    {
        await base.Inline_collection_Except_column_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Column_collection_Where_Union()
    {
        await base.Column_collection_Where_Union();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_in_subquery_Count_as_compiled_query()
    {
        await base.Parameter_collection_in_subquery_Count_as_compiled_query();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_in_subquery_Union_column_collection_as_compiled_query()
    {
        await base.Parameter_collection_in_subquery_Union_column_collection_as_compiled_query();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_in_subquery_Union_column_collection()
    {
        await base.Parameter_collection_in_subquery_Union_column_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_in_subquery_Union_column_collection_nested()
    {
        await base.Parameter_collection_in_subquery_Union_column_collection_nested();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_ints_simple()
    {
        await base.Project_collection_of_ints_simple();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_ints_ordered()
    {
        await base.Project_collection_of_ints_ordered();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_datetimes_filtered()
    {
        await base.Project_collection_of_datetimes_filtered();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_nullable_ints_with_paging()
    {
        await base.Project_collection_of_nullable_ints_with_paging();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_nullable_ints_with_paging2()
    {
        await base.Project_collection_of_nullable_ints_with_paging2();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_nullable_ints_with_paging3()
    {
        await base.Project_collection_of_nullable_ints_with_paging3();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_ints_with_distinct()
    {
        await base.Project_collection_of_ints_with_distinct();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_nullable_ints_with_distinct()
    {
        await base.Project_collection_of_nullable_ints_with_distinct();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_collection_of_ints_with_ToList_and_FirstOrDefault()
    {
        await base.Project_collection_of_ints_with_ToList_and_FirstOrDefault();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_empty_collection_of_nullables_and_collection_only_containing_nulls()
    {
        await base.Project_empty_collection_of_nullables_and_collection_only_containing_nulls();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_multiple_collections()
    {
        await base.Project_multiple_collections();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_primitive_collections_element()
    {
        await base.Project_primitive_collections_element();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_inline_collection()
    {
        await base.Project_inline_collection();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Project_inline_collection_with_Union()
    {
        await base.Project_inline_collection_with_Union();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_contains_with_Lists_and_no_inferred_type_mapping()
    {
        await base.Nested_contains_with_Lists_and_no_inferred_type_mapping();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Nested_contains_with_arrays_and_no_inferred_type_mapping()
    {
        await base.Nested_contains_with_arrays_and_no_inferred_type_mapping();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Values_of_enum_casted_to_underlying_value()
    {
        await base.Values_of_enum_casted_to_underlying_value();
    }

    [Fact(Skip = ClickHouseSkipReasons.Tbd)]
    public override async Task Parameter_collection_of_nullable_ints_Contains_nullable_int_with_EF_Parameter()
    {
        await base.Parameter_collection_of_nullable_ints_Contains_nullable_int_with_EF_Parameter();
    }

    public class PrimitiveCollectionsQueryClickHouseFixture : PrimitiveCollectionsQueryFixtureBase, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory
            => ClickHouseTestStoreFactory.Instance;
#if NET11_0_OR_GREATER

        protected override void OnModelCreating(ModelBuilder modelBuilder, DbContext context)
        {
            base.OnModelCreating(modelBuilder, context);

            modelBuilder.Entity<PrimitiveCollectionsEntity>()
                .Property(entity => entity.NullableStrings)
                .HasColumnType("Array(Nullable(String))");
        }
#endif
    }
}
