using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class XyScatterRenderableSeries<TX, TY> : RenderableSeriesBase
{
    [SciChartElementType]
    public override string Type => "ScatterSeries";

    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }
    public XyScatterRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}