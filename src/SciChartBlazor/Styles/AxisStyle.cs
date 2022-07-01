namespace SciChartBlazor.Styles;

public class AxisStyle
{
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