namespace SciChartBlazor;

/// <summary>
/// A point Marker.
/// </summary>
/// <seealso cref="SciChartBlazor.SciChartElementBase" />
public class PointMarker : SciChartElementBase
{
	string _type;
    /// <summary>
    /// Initializes a new instance of the <see cref="PointMarker"/> class.
    /// </summary>
    /// <param name="shape">The shape.</param>
    public PointMarker(PointMarkerShape shape)
	{
		_type = shape.ToString();
	}
    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    /// <value>
    /// The width.
    /// </value>
    public double? Width { get; set; }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    /// <value>
    /// The height.
    /// </value>
    public double? Height { get; set; }

    /// <summary>
    /// Gets or sets the fill.
    /// </summary>
    /// <value>
    /// The fill.
    /// </value>
    public string? Fill { get; set; }

    /// <summary>
    /// Gets or sets the stroke.
    /// </summary>
    /// <value>
    /// The stroke.
    /// </value>
    public string? Stroke { get; set; }

    /// <summary>
    /// Gets or sets the stroke thickness.
    /// </summary>
    /// <value>
    /// The stroke thickness.
    /// </value>
    public double? StrokeThickness { get; set; }

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    /// <value>
    /// The size.
    /// </value>
    public double Size { get; set; }

    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
	public override string Type => _type;
}
