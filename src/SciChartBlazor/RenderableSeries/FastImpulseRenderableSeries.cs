using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

[Serializable]
public class FastImpulseRenderableSeries<TX, TY> : RenderableSeriesBase
{
    public FastImpulseRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }

    [SciChartElementType]
    public override string Type => "ImpulseSeries";

    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }

    public string? Fill { get; set; }
    public double? Size { get; set; }


}