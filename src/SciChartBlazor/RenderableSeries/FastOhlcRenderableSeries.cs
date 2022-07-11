using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Fast Ohlc Series.
/// </summary>
/// <typeparam name="TOpen">The type of the open.</typeparam>
/// <typeparam name="THigh">The type of the high.</typeparam>
/// <typeparam name="TLow">The type of the low.</typeparam>
/// <typeparam name="TClose">The type of the close.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class FastOhlcRenderableSeries<TOpen, THigh, TLow, TClose> : RenderableSeriesBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "OhlcSeries";

    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    public override DataSeriesBase DataSeries { get; }

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
    /// Initializes a new instance of the <see cref="FastOhlcRenderableSeries{TOpen, THigh, TLow, TClose}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public FastOhlcRenderableSeries(OhlcDataSeries<TOpen, THigh, TLow, TClose> dataSeries)
    {
        DataSeries = dataSeries;
    }
}

