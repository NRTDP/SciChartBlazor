namespace SciChartBlazor.Annotations;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Annotations.AnnotationBase" />
public class AxisMarkerAnnotation : AnnotationBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "RenderContextAxisMarkerAnnotation";

    /// <summary>
    /// Gets or sets the size of the font.
    /// </summary>
    /// <value>
    /// The size of the font.
    /// </value>
    public double? FontSize { get; set; }

    /// <summary>
    /// Gets or sets the font style.
    /// </summary>
    /// <value>
    /// The font style.
    /// </value>
    public string? FontStyle { get; set; }

    /// <summary>
    /// Gets or sets the color of the background.
    /// </summary>
    /// <value>
    /// The color of the background.
    /// </value>
    public string? BackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    /// <value>
    /// The color.
    /// </value>
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the font family.
    /// </summary>
    /// <value>
    /// The font family.
    /// </value>
    public string? FontFamily { get; set; }
}