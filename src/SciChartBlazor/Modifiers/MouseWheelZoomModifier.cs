namespace SciChartBlazor.Modifiers;

public class MouseWheelZoomModifier : ModifierBase
{
    [SciChartElementType]
    public override string Type => "MouseWheelZoom";
    public double? GrowFactor { get; set; }
}