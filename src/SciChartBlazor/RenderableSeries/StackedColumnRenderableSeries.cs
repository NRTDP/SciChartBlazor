using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class StackedColumnRenderableSeries<TX, TY> : RenderableSeriesBase
{
    [SciChartElementType]
    public override string Type => "StackedColumnSeries";

    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }

    public string? StackedGroupId { get; set; }

    public StackedColumnRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}