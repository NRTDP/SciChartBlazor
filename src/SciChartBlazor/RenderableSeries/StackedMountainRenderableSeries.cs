using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Stacked Mountain Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.StackedRenderableSeriesBase" />
public class StackedMountainRenderableSeries<TX, TY> : StackedRenderableSeriesBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "StackedMountainSeries";

    /// <summary>
    /// Gets or sets the fill.
    /// </summary>
    /// <value>
    /// The fill.
    /// </value>
    public string? Fill { get; set; }

    /// <summary>
    /// Gets or sets the is one hundred percent.
    /// </summary>
    /// <value>
    /// The is one hundred percent.
    /// </value>
    public bool? IsOneHundredPercent { get; set; }

    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StackedMountainRenderableSeries{TX,TY}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public StackedMountainRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}
