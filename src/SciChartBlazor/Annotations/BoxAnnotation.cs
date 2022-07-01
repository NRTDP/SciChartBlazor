namespace SciChartBlazor.Annotations;

public class BoxAnnotation : AnnotationBase
{
	[SciChartElementType]
	public override string Type => "RenderContextBoxAnnotation";
	public string? Fill { get; init; }
	public string? Stroke { get; init; }
	public double? StrokeThickness { get; init; }
}