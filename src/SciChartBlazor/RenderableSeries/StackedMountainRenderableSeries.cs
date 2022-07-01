using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class StackedMountainRenderableSeries<TX, TY> : RenderableSeriesBase
{
    [SciChartElementType]
    public override string Type => "StackedMountainSeries";

    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }

    public string? Fill { get; set; }
    public bool? IsOneHundredPercent { get; set; }

    public StackedMountainRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}