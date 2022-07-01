namespace SciChartBlazor.Annotations;

public class LineAnnotation : AnnotationBase
{
    [SciChartElementType]
    public override string Type => "RenderContextLineAnnotation";
    public string? Stroke { get; set; }
    public double? StrokeThickness { get; set; }
}