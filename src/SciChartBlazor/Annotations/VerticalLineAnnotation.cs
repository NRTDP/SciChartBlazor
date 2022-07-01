namespace SciChartBlazor.Annotations;

public class VerticalLineAnnotation : AnnotationBase
{
	[SciChartElementType]
	public override string Type => "RenderContextVerticalLineAnnotation";
	public LabelPlacement? LabelPlacement { get; set; }
	public bool? ShowLabel { get; set; }
	public string? Stroke { get; set; }
	public double? StrokeThickness { get; set; }
	public string? AxisLabelFill { get; set; }
}