using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class StackedMountainRenderableSeries<TX, TY> : RenderableSeriesBase
{
    [SciChartElementType]
    public override string Type => "StackedMountainSeries";
    public string? Fill { get; set; }
    public bool? IsOneHundredPercent { get; set; }
    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }
    public StackedMountainRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}
