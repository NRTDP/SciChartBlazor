namespace SciChartBlazor.Modifiers;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Modifiers.ModifierBase" />
public class YAxisDragModifier : ModifierBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public override string Type => "YAxisDrag";

    /// <summary>
    /// Gets or sets the drag mode.
    /// </summary>
    /// <value>
    /// The drag mode.
    /// </value>
    public DragMode? DragMode { get; set; }
}