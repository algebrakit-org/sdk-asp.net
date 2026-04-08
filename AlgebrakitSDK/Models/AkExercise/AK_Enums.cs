using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.AkExercise;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_QuestionMode
{
    ONE_BY_ONE,
    ALL_AT_ONCE
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_SymbolType
{
    VARIABLE,
    CONSTANT,
    FUNCTION,
    FREEVARIABLE
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_ElementBlockType
{
    CONTENT,
    INTERACTION
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_InteractionType
{
    MULTISTEP,
    CHOICE,
    FILL_IN_THE_BLANKS,
    MATH_TABLE
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_TaskType
{
    SIMPLIFY,
    SOLVE,
    SOLVE_SYSTEM,
    EXPAND,
    FACTOR,
    TOGETHER,
    COMPLETE_SQUARE,
    POLYNOMIAL_STANDARD_FORM,
    POWER_STANDARD_FORM,
    EXPONENTIAL_STANDARD_FORM,
    CARTESIAN_TO_POLAR_FORM,
    POLAR_TO_CARTESIAN_FORM
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_FieldSize
{
    SMALL,
    MEDIUM,
    LARGE
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_BlankType
{
    EXPRESSION,
    SELECTION
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_CellType
{
    text,
    math,
    input
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_AccuracyType
{
    ROUND,
    ROUND_UP,
    ROUND_DOWN,
    ACCURATE,
    PRECISION
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_NumberForm
{
    DECIMAL_REQUIRED,
    DECIMAL_PREFERRED,
    FRACTION_REQUIRED,
    FRACTION_PREFERRED,
    SCIENTIFIC_NOTATION_REQUIRED,
    SCIENTIFIC_NOTATION_PREFERRED
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_RadicalForm
{
    STANDARD_FORM_REQUIRED
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_FractionForm
{
    MIXED_FRACTION_REQUIRED,
    IMPROPER_FRACTION_REQUIRED
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_InitialExpressionType
{
    NONE,
    CUSTOM,
    AUTOMATIC
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AK_StudentFeedbackType
{
    ALL,
    ICONS_ONLY,
    ERRORS_ONLY,
    NONE
}
