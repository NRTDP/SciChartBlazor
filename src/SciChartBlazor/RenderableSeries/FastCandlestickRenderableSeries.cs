using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Fast Candlestic Series.
/// </summary>
/// <typeparam name="TOpen">The type of the open.</typeparam>
/// <typeparam name="THigh">The type of the high.</typeparam>
/// <typeparam name="TLow">The type of the low.</typeparam>
/// <typeparam name="TClose">The type of the close.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class FastCandlestickRenderableSeries<TOpen, THigh, TLow, TClose> : RenderableSeriesBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "CandlestickSeries";

    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FastCandlestickRenderableSeries{TOpen, THigh, TLow, TClose}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public FastCandlestickRenderableSeries(OhlcDataSeries<TOpen, THigh, TLow, TClose> dataSeries)
    {
        DataSeries = dataSeries;
    }

    /// <summary>
    /// Gets or sets the brush up.
    /// </summary>
    /// <value>
    /// The brush up.
    /// </value>
    public string? BrushUp { get; set; }

    /// <summary>
    /// Gets or sets the brush down.
    /// </summary>
    /// <value>
    /// The brush down.
    /// </value>
    public string? BrushDown { get; set; }

    /// <summary>
    /// Gets or sets the stroke up.
    /// </summary>
    /// <value>
    /// The stroke up.
    /// </value>
    public string? StrokeUp { get; set; }

    /// <summary>
    /// Gets or sets the stroke down.
    /// </summary>
    /// <value>
    /// The stroke down.
    /// </value>
    public string? StrokeDown { get; set; }

    /// <summary>
    /// Gets or sets the width of the data point.
    /// </summary>
    /// <value>
    /// The width of the data point.
    /// </value>
    public double? DataPointWidth { get; set; }
}
