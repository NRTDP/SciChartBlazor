using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Fast Impulse Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class FastImpulseRenderableSeries<TX, TY> : RenderableSeriesBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FastImpulseRenderableSeries{TX, TY}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public FastImpulseRenderableSeries(XyDataSeries<TX, TY> dataSeries)
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
    public override string Type => "ImpulseSeries";

    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Gets or sets the fill.
    /// </summary>
    /// <value>
    /// The fill.
    /// </value>
    public string? Fill { get; set; }

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    /// <value>
    /// The size.
    /// </value>
    public double? Size { get; set; }
}