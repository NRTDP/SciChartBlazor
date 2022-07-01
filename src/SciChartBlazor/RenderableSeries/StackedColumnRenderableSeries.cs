using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class StackedColumnRenderableSeries<TX, TY> : RenderableSeriesBase
{
    [SciChartElementType]
    public override string Type => "StackedColumnSeries";
    public string? StackedGroupId { get; set; }

    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }
    public StackedColumnRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}
