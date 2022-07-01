namespace SciChartBlazor.Annotations;
public abstract class AnnotationBase : SciChartElementBase
{
   
    public AnnotationLayer? AnnotationLayer { get; init; }
    public CoordinateMode? XCoordinateMode { get; init; }
    public CoordinateMode? YCoordinateMode { get; init; }
    public HorizontalAnchorPoint? HorizontalAnchorPoint { get; init; }
    public VerticalAnchorPoint? VerticalAnchorPoint {  get; init; }
    public bool? IsHidden { get; init; }
    public double? X1 { get; init; }
    public double? X2 { get; init; }
    public double? Y1 { get; init; }
    public double? Y2 { get; init; }
    public string? XAxisId { get; init; }
    public string? YAxisId { get; init; }
}

