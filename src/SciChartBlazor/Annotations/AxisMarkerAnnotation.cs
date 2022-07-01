namespace SciChartBlazor.Annotations;

public class AxisMarkerAnnotation : AnnotationBase
{
    [SciChartElementType]
    public override string Type => "RenderContextAxisMarkerAnnotation";
    public double? FontSize { get; set; }
    public string? FontStyle { get; set; }
    public string? BackgroundColor { get; set; }
    public string? Color { get; set; }
    public string? FontFamily { get; set; }
}