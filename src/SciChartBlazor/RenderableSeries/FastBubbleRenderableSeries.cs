using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class FastBubbleRenderableSeries<TX, TY, TZ> : RenderableSeriesBase
{
    [SciChartElementType]
    public override string Type => "BubbleSeries";

    [SciChartDataSeries(DataSeriesType.XyzData)]
    public override DataSeriesBase DataSeries { get; }

    public FastBubbleRenderableSeries(XyzDataSeries<TX, TY, TZ> dataSeries)
    {
        DataSeries = dataSeries;
    }
}