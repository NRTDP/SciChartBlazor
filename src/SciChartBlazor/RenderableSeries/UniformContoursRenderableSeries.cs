using System.Text.Json;
using SciChartBlazor.DataSeries;
using SciChartBlazor.Styles;

namespace SciChartBlazor.RenderableSeries;
/// <summary>
/// A Uniform Contour Series.
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <typeparam name="TZ">The type of the z.</typeparam>
/// <seealso cref="SciChartBlazor.RenderableSeries.RenderableSeriesBase" />
public class UniformContoursRenderableSeries<TX, TY, TZ> : RenderableSeriesBase
{

    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>The type.</value>
    [SciChartElementType]
    public override string Type => "UniformContoursSeries";

    /// <summary>
    /// Gets the data series.
    /// </summary>
    /// <value>
    /// The data series.
    /// </value>
    [SciChartDataSeries(DataSeriesType.XyzData)]
    public override DataSeriesBase DataSeries { get; }

    /// <summary>
    /// Gets the heatmap color map.
    /// </summary>
    /// <value>
    /// The heatmap color map.
    /// </value>
    public HeatmapColorMap HeatmapColorMap { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UniformContoursRenderableSeries{TX, TY, TZ}"/> class.
    /// </summary>
    /// <param name="dataSeries">The data series.</param>
    /// <param name="heatmapColorMap">The heatmap color map.</param>
    public UniformContoursRenderableSeries(UniformHeatmapDataSeries<TX, TY, TZ> dataSeries, HeatmapColorMap heatmapColorMap)
    {
        DataSeries = dataSeries;
        HeatmapColorMap = heatmapColorMap;
    }
}
