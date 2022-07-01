using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

public class SplineBandRenderableSeries<TX, TY1, TY2> : RenderableSeriesBase
{

    [SciChartElementType]
    public override string Type => "SplineBandSeries";
    public string? Fill { get; set; }
    public string? FillY1 { get; set; }
    public string? StrokeY1 { get; set; }

    [SciChartDataSeries(DataSeriesType.XyyData)]
    public override DataSeriesBase DataSeries { get; }
    public int? InterpolationPoints { get; set; }

    public SplineBandRenderableSeries(XyyDataSeries<TX, TY1, TY2> dataSeries)
    {
        DataSeries = dataSeries;
    }
}