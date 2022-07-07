using SciChartBlazor.DataSeries;
using SciChartBlazor.Styles;

namespace SciChartBlazor.RenderableSeries;
public abstract class RenderableSeriesBase : SciChartElementBase
{
    public abstract DataSeriesBase DataSeries { get; }
    public LineDrawMode? DrawNanAs { get; set; }

    [HasOptions]
    public PointMarker? PointMarker { get; set; }
    public string? Stroke { get; set; }
    public double? StrokeThickness { get; set; }
    public double? Opacity { get; set; }
    public string? XAxisId { get; set; }
    public string? YAxisId { get; set; }
    public bool? IsVisible { get; set; }

    [HasOptions]
    public ShaderEffect? ShaderEffect { get; set; }
}