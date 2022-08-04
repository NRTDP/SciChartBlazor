namespace SciChartBlazor.Styles;

/// <summary>
/// The style of a Minor grid line.
/// </summary>
public class MinorGridLineStyle
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

	public int? StrokeThickness { get; set; }
	public string? Color { get; set; } = "black";
	public int[]? StrokeDasharray { get; set; }
}