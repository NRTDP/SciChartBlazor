using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class SplineLineRenderableSeries<TX, TY> : RenderableSeriesBase
{
    [SciChartElementType]
    public override string Type => "SplineLineSeries";

    [SciChartDataSeries(DataSeriesType.XyData)]
    public override DataSeriesBase DataSeries { get; }
    public int? InterpolationPoints { get; set; }

    public SplineLineRenderableSeries(XyDataSeries<TX, TY> dataSeries)
    {
        DataSeries = dataSeries;
    }
}