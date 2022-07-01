namespace SciChartBlazor.Modifiers;

public class XAxisDragModifier : ModifierBase
{
    public override string Type => "XAxisDrag";
    public DragMode? DragMode { get; set; }
}