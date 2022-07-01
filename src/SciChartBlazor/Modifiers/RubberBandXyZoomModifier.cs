
using System.Text.Json;

namespace SciChartBlazor.Modifiers;

public class RubberBandXyZoomModifier : ModifierBase
{
	[SciChartElementType]
	public override string Type => "RubberBandXYZoom";

    public bool? IsAnimated { get; set; }
    public double? AnimationDuration { get; set; }
    public EasingFunction? EasingFunction { get; set; }
    public string? Fill { get; set; }
    public string? Stroke { get; set; }
    public double? StrokeThickness { get; set; }


}
