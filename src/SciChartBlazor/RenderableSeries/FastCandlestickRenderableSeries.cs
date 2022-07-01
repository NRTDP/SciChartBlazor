using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;
public class FastCandlestickRenderableSeries<TOpen, THigh, TLow, TClose> : RenderableSeriesBase
{

    [SciChartElementType]
    public override string Type => "CandlestickSeries";

    public override DataSeriesBase DataSeries { get; }

    public FastCandlestickRenderableSeries(OhlcDataSeries<TOpen, THigh, TLow, TClose> dataSeries)
    {
        DataSeries = dataSeries;
    }

    public string? BrushUp { get; set; }
    public string? BrushDown { get; set; }
    public string? StrokeUp { get; set; }
    public string? StrokeDown { get; set; }
    public double? DataPointWidth { get; set; }
}
