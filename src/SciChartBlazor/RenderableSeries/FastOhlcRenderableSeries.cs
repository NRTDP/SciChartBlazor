using System.Text.Json;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;
public class FastOhlcRenderableSeries<TOpen, THigh, TLow, TClose> : RenderableSeriesBase
{

    [SciChartElementType]
    public override string Type => "OhlcSeries";

    public override DataSeriesBase DataSeries { get; }
    public string? StrokeUp { get; set; }
    public string? StrokeDown { get; set; }

    public FastOhlcRenderableSeries(OhlcDataSeries<TOpen, THigh, TLow, TClose> dataSeries)
    {
        DataSeries = dataSeries;
    }
}

