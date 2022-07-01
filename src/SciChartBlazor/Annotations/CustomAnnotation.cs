namespace SciChartBlazor.Annotations;

public class CustomAnnotation : AnnotationBase
{
	[SciChartElementType]
	public override string Type => "SVGCustomAnnotation";
	public string? SvgString { get; set; }
}