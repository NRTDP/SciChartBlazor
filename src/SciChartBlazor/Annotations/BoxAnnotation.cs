namespace SciChartBlazor.Annotations;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Annotations.AnnotationBase" />
public class BoxAnnotation : AnnotationBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
	public override string Type => "RenderContextBoxAnnotation";

    /// <summary>
    /// Gets the fill.
    /// </summary>
    /// <value>
    /// The fill.
    /// </value>
    public string? Fill { get; init; }

    /// <summary>
    /// Gets the stroke.
    /// </summary>
    /// <value>
    /// The stroke.
    /// </value>
    public string? Stroke { get; init; }

    /// <summary>
    /// Gets the stroke thickness.
    /// </summary>
    /// <value>
    /// The stroke thickness.
    /// </value>
    public double? StrokeThickness { get; init; }
}