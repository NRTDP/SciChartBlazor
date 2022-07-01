namespace SciChartBlazor.Modifiers;

public class YAxisDragModifier : ModifierBase
{
    public override string Type => "YAxisDrag";
    public DragMode? DragMode { get; set; }
}