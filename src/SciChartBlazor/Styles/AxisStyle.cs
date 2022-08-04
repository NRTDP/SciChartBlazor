namespace SciChartBlazor.Styles;

/// <summary>
/// The axis style.
/// </summary>
public class AxisStyle
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public string? AxisTitle { get; set; }
    public bool? DrawMajorBands { get; set; } = true;
	public string? AxisBandsFill { get; set; }
	public AxisTitleStyle? AxisTitleStyle { get; set; }
	public MajorGridLineStyle? MajorGridLineStyle { get; set; }
	public MinorGridLineStyle? MinorGridLineStyle { get; set; }
	public MajorTickLineStyle? MajorTickLineStyle { get; set; }
	public MinorTickLineStyle? MinorTickLineStyle { get; set; }
	public LabelStyle? LabelStyle { get; set; }
	public AxisBorder? AxisBorder { get; set; }
}