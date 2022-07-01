namespace SciChartBlazor.Modifiers;

public class CursorModifier : ModifierBase
{
	public override string Type => "Cursor";
	public string? CrosshairStroke { get; set; }
	public double? CrosshairStrokeThickness { get; set; }
	public string? TooltipContainerBackground { get; set; }
	public string? TooltipTextStroke { get; set; }
	public bool? ShowTooltip { get; set; }
	public string? AxisLabelsFill { get; set; }
	public string? AxisLabelsStroke { get; set; }
}
