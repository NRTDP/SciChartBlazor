using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

[Serializable]
public class FastLineRenderableSeries<TX, TY> : RenderableSeriesBase
{
    public FastLineRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }

    [SciChartElementType]
    public override string Type => "LineSeries";

    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }
}
