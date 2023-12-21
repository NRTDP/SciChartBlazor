namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// The Base class for a line-based series.
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
/// </summary>
public abstract class LineRenderableSeriesBase : RenderableSeriesBase
{
    /// <summary>
    /// A StrokeDashArray is an array which defines a dot-dash pattern.
    /// </summary>
    public double[]? StrokeDashArray { get; set; }
}