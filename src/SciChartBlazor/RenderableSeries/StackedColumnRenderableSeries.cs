using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Stacked Column Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class StackedColumnRenderableSeries<TX, TY> : RenderableSeriesBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "StackedColumnSeries";

    /// <summary>
    /// Gets or sets the stacked group identifier.
    /// </summary>
    /// <value>
    /// The stacked group identifier.
    /// </value>
    public string? StackedGroupId { get; set; }


    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="StackedColumnRenderableSeries{TX, TY}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public StackedColumnRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}
