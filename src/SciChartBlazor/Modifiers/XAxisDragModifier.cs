using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Modifiers;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Modifiers.ModifierBase" />
public class XAxisDragModifier : ModifierBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public override string Type => "XAxisDrag";

    /// <summary>
    /// Gets or sets the drag mode.
    /// </summary>
    /// <value>
    /// The drag mode.
    /// </value>
    public DragMode? DragMode { get; set; }
}
