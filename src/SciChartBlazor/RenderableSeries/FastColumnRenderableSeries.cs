using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class FastColumnRenderableSeries<TX, TY> : RenderableSeriesBase
{

    [SciChartElementType]
    public override string Type => "ColumnSeries";

    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }

    public FastColumnRenderableSeries(XyDataSeries<TX, TX> dataSeries)
    {
        DataSeries = dataSeries;
    }

    public double? DataPointWidth { get; set; }
    public string? Fill { get; set; }
}
