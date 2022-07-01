using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class FastBandRenderableSeries<TX, TY1, TY2> : RenderableSeriesBase
{
    [SciChartElementType]
    public override string Type => "BandSeries";

    [SciChartDataSeries(DataSeriesType.XyyData)]
    public override DataSeriesBase DataSeries { get; }

    public FastBandRenderableSeries(XyyDataSeries<TX, TY1, TY2> dataSeries)
    {
        DataSeries = dataSeries;
    }

    public string? Fill { get; set; }
    public string? FillY1 { get; set; }
    public string? StrokeY1 { get; set; }
}