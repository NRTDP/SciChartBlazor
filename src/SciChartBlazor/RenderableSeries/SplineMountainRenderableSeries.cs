using System.Text.Json;
using SciChartBlazor.DataSeries;
using SciChartBlazor.Styles;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// A Spline Mountain Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class SplineMountainRenderableSeries<TX, TY> : RenderableSeriesBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "SplineMountainSeries";

    /// <summary>
    /// Gets or sets the zero line y.
    /// </summary>
    /// <value>
    /// The zero line y.
    /// </value>
    public double? ZeroLineY { get; set; }

    /// <summary>
    /// Gets or sets the interpolation points.
    /// </summary>
    /// <value>
    /// The interpolation points.
    /// </value>
    public int? InterpolationPoints { get; set; }

    /// <summary>
    /// Gets or sets the fill linear gradient.
    /// </summary>
    /// <value>
    /// The fill linear gradient.
    /// </value>
    public GradientParams? FillLinearGradient { get; set; }


    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.XyData)]
	public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SplineMountainRenderableSeries{TX, TY}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    public SplineMountainRenderableSeries(XyDataSeries<TX, TY> dataSeries)
	{
		DataSeries = dataSeries;
	}
}
