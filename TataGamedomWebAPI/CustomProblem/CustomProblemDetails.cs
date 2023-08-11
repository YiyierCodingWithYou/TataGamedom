using Microsoft.AspNetCore.Mvc;

namespace TataGamedomWebAPI.CustomProblem;

public class CustomProblemDetails : ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}

