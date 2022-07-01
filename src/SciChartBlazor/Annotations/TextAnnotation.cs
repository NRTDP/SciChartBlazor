namespace SciChartBlazor.Annotations;

public class TextAnnotation : AnnotationBase
{
	[SciChartElementType]
	public override string Type => "SVGTextAnnotation";
	public string? Text { get; set; }
}