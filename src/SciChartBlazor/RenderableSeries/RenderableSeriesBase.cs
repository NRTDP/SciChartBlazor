using SciChartBlazor.DataSeries;
using SciChartBlazor.Styles;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// The Base class for a series.
/// </summary>
/// <seealso cref="SciChartBlazor.SciChartElementBase" />
public abstract class RenderableSeriesBase : SciChartElementBase
{
    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    public abstract DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Gets or sets the draw nan as.
    /// </summary>
    /// <value>
    /// The draw nan as.
    /// </value>
    public LineDrawMode? DrawNanAs { get; set; }

    /// <summary>
    /// Gets or sets the point marker.
    /// </summary>
    /// <value>
    /// The point marker.
    /// </value>
    [HasOptions]
    public PointMarker? PointMarker { get; set; }

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
    /// Gets or sets the opacity.
    /// </summary>
    /// <value>
    /// The opacity.
    /// </value>
    public double? Opacity { get; set; }

    /// <summary>
    /// Gets or sets the x axis identifier.
    /// </summary>
    /// <value>
    /// The x axis identifier.
    /// </value>
    public string? XAxisId { get; set; }

    /// <summary>
    /// Gets or sets the y axis identifier.
    /// </summary>
    /// <value>
    /// The y axis identifier.
    /// </value>
    public string? YAxisId { get; set; }

    /// <summary>
    /// Gets or sets the is visible.
    /// </summary>
    /// <value>
    /// The is visible.
    /// </value>
    public bool? IsVisible { get; set; }

    /// <summary>
    /// Gets or sets the effect.
    /// </summary>
    /// <value>
    /// The effect.
    /// </value>
    [HasOptions]
    public ShaderEffect? Effect { get; set; }
}