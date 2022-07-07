namespace SciChartBlazor.Styles;

/// <summary>
/// The style of a Major Grid line,
/// </summary>
public class MajorGridLineStyle
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public int? StrokeThickness { get; set; }
    public string? Color { get; set; } = "black";
    public int[]? StrokeDasharray { get; set; }
}
