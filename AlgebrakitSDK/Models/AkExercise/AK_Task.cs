using System.Text.Json.Serialization;

namespace AlgebrakitSDK.Models.AkExercise;

/// <summary>
/// Base class for all task types. Discriminated on the "type" property.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(AK_TaskSimplify), "SIMPLIFY")]
[JsonDerivedType(typeof(AK_TaskSolve), "SOLVE")]
[JsonDerivedType(typeof(AK_TaskSolveSystem), "SOLVE_SYSTEM")]
[JsonDerivedType(typeof(AK_TaskExpand), "EXPAND")]
[JsonDerivedType(typeof(AK_TaskFactor), "FACTOR")]
[JsonDerivedType(typeof(AK_TaskTogether), "TOGETHER")]
[JsonDerivedType(typeof(AK_TaskCompleteSquare), "COMPLETE_SQUARE")]
[JsonDerivedType(typeof(AK_TaskPolynomialStandardForm), "POLYNOMIAL_STANDARD_FORM")]
[JsonDerivedType(typeof(AK_TaskPowerStandardForm), "POWER_STANDARD_FORM")]
[JsonDerivedType(typeof(AK_TaskExponentialStandardForm), "EXPONENTIAL_STANDARD_FORM")]
[JsonDerivedType(typeof(AK_TaskCartesianToPolarForm), "CARTESIAN_TO_POLAR_FORM")]
[JsonDerivedType(typeof(AK_TaskPolarToCartesianForm), "POLAR_TO_CARTESIAN_FORM")]
public abstract class AK_Task
{
}

public class AK_TaskSimplify : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;
}

public class AK_TaskSolve : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;

    [JsonPropertyName("variable")]
    public string Variable { get; set; } = string.Empty;

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }
}

public class AK_TaskSolveSystem : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;

    [JsonPropertyName("variables")]
    public List<string> Variables { get; set; } = new();

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("restrictVariable")]
    public string? RestrictVariable { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }
}

public class AK_TaskExpand : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;
}

public class AK_TaskFactor : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;
}

public class AK_TaskTogether : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;
}

public class AK_TaskCompleteSquare : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;

    [JsonPropertyName("variable")]
    public string Variable { get; set; } = string.Empty;
}

public class AK_TaskPolynomialStandardForm : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;

    [JsonPropertyName("variable")]
    public string Variable { get; set; } = string.Empty;
}

public class AK_TaskPowerStandardForm : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;

    [JsonPropertyName("variable")]
    public string Variable { get; set; } = string.Empty;
}

public class AK_TaskExponentialStandardForm : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;

    [JsonPropertyName("variable")]
    public string Variable { get; set; } = string.Empty;
}

public class AK_TaskCartesianToPolarForm : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;
}

public class AK_TaskPolarToCartesianForm : AK_Task
{
    [JsonPropertyName("expression")]
    public string Expression { get; set; } = string.Empty;
}
