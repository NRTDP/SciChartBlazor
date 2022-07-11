using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Fast Bubble Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <typeparam name="TZ">The type of the z.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class FastBubbleRenderableSeries<TX, TY, TZ> : RenderableSeriesBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "BubbleSeries";

    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.XyzData)]
    public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FastBubbleRenderableSeries{TX, TY, TZ}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public FastBubbleRenderableSeries(XyzDataSeries<TX, TY, TZ> dataSeries)
    {
        DataSeries = dataSeries;
    }
}