using System.Text.Json;
using SciChartBlazor.DataSeries;
using SciChartBlazor.Styles;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Fast Mountain Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class FastMountainRenderableSeries<TX, TY> : LineRenderableSeriesBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "MountainSeries";

    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.Xy)]
    public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Gets or sets the fill.
    /// </summary>
    /// <value>
    /// The fill.
    /// </value>
    public string? Fill { get; set; }

    /// <summary>
    /// Gets or sets the fill linear gradient.
    /// </summary>
    /// <value>
    /// The fill linear gradient.
    /// </value>
    public GradientParams? FillLinearGradient { get; set; }

    /// <summary>
    /// Gets or sets the zero line y.
    /// </summary>
    /// <value>
    /// The zero line y.
    /// </value>
    public double? ZeroLineY { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FastMountainRenderableSeries{TX, TY}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public FastMountainRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}