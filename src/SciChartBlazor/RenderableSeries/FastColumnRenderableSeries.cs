using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Fast Column Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class FastColumnRenderableSeries<TX, TY> : RenderableSeriesBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "ColumnSeries";


    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.Xy)]
    public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FastColumnRenderableSeries{TX, TY}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public FastColumnRenderableSeries(XyDataSeries<TX, TX> dataSeries)
    {
        DataSeries = dataSeries;
    }

    /// <summary>
    /// Gets or sets the width of the data point.
    /// </summary>
    /// <value>
    /// The width of the data point.
    /// </value>
    public double? DataPointWidth { get; set; }

    /// <summary>
    /// Gets or sets the fill.
    /// </summary>
    /// <value>
    /// The fill.
    /// </value>
    public string? Fill { get; set; }
}
