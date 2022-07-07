namespace SciChartBlazor.Styles;

/// <summary>
/// The axis border.
/// </summary>
public class AxisBorder
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public double? BorderLeft { get; set; }
    public double? BorderRight { get; set; }
    public double? BorderTop { get; set; }
    public double? BorderBottom { get; set; }

    public string? Color { get; set; } = "black";
}
