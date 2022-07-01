using System.Text.Json;

namespace SciChartBlazor.Modifiers;

public class ZoomExtentsModifier : ModifierBase
{
    public override string Type => "ZoomExtents";
    public bool? IsAnimated { get; set; }
    public double? AnimationDuration { get; set; }
    public EasingFunction? EasingFunction { get; set; }

}