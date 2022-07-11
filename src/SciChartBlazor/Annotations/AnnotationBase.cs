namespace SciChartBlazor.Annotations;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.SciChartElementBase" />
public abstract class AnnotationBase : SciChartElementBase
{
    /// <summary>
    /// Gets the annotation layer.
    /// </summary>
    /// <value>
    /// The annotation layer.
    /// </value>
    public AnnotationLayer? AnnotationLayer { get; init; }

    /// <summary>
    /// Gets the x coordinate mode.
    /// </summary>
    /// <value>
    /// The x coordinate mode.
    /// </value>
    public CoordinateMode? XCoordinateMode { get; init; }

    /// <summary>
    /// Gets the y coordinate mode.
    /// </summary>
    /// <value>
    /// The y coordinate mode.
    /// </value>
    public CoordinateMode? YCoordinateMode { get; init; }

    /// <summary>
    /// Gets the horizontal anchor point.
    /// </summary>
    /// <value>
    /// The horizontal anchor point.
    /// </value>
    public HorizontalAnchorPoint? HorizontalAnchorPoint { get; init; }

    /// <summary>
    /// Gets the vertical anchor point.
    /// </summary>
    /// <value>
    /// The vertical anchor point.
    /// </value>
    public VerticalAnchorPoint? VerticalAnchorPoint {  get; init; }

    /// <summary>
    /// Gets the is hidden.
    /// </summary>
    /// <value>
    /// The is hidden.
    /// </value>
    public bool? IsHidden { get; init; }

    /// <summary>
    /// Gets the x1.
    /// </summary>
    /// <value>
    /// The x1.
    /// </value>
    public double? X1 { get; init; }

    /// <summary>
    /// Gets the x2.
    /// </summary>
    /// <value>
    /// The x2.
    /// </value>
    public double? X2 { get; init; }

    /// <summary>
    /// Gets the y1.
    /// </summary>
    /// <value>
    /// The y1.
    /// </value>
    public double? Y1 { get; init; }

    /// <summary>
    /// Gets the y2.
    /// </summary>
    /// <value>
    /// The y2.
    /// </value>
    public double? Y2 { get; init; }

    /// <summary>
    /// Gets the x axis identifier.
    /// </summary>
    /// <value>
    /// The x axis identifier.
    /// </value>
    public string? XAxisId { get; init; }

    /// <summary>
    /// Gets the y axis identifier.
    /// </summary>
    /// <value>
    /// The y axis identifier.
    /// </value>
    public string? YAxisId { get; init; }
}

