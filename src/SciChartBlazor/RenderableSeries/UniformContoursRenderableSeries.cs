using System.Text.Json;
using SciChartBlazor.DataSeries;
using SciChartBlazor.Styles;

namespace SciChartBlazor.RenderableSeries;

public class UniformContoursRenderableSeries<TX, TY, TZ> : RenderableSeriesBase
{

    [SciChartElementType]
    public override string Type => "UniformContoursSeries";
    [SciChartDataSeries(DataSeriesType.XyzData)]
    public override DataSeriesBase DataSeries { get; }
    public HeatmapColorMap HeatmapColorMap { get; }
    public UniformContoursRenderableSeries(UniformHeatmapDataSeries<TX, TY, TZ> dataSeries, HeatmapColorMap heatmapColorMap)
    {
        DataSeries = dataSeries;
        HeatmapColorMap = heatmapColorMap;
    }
}
