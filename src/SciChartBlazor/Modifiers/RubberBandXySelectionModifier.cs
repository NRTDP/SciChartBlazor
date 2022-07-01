namespace SciChartBlazor.Modifiers;

//this is a custom modifier
public class RubberBandXySelectionModifier : ModifierBase
{
    [SciChartElementType]
    public override string Type => "Custom";

    [SciChartCustomElementType]
    public string customType => "RubberBandXYSelection";
 
    public string? Fill { get; set; }
    public string? Stroke { get; set; }
    public double? StrokeThickness { get; set; }
    public bool? RangeSelect { get; set; }


}
