using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Fast Line Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class FastLineRenderableSeries<TX, TY> : LineRenderableSeriesBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FastLineRenderableSeries{TX, TY}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public FastLineRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }

    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "LineSeries";


    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.Xy)]
    public override DataSeriesBase DataSeries { get; }
}