using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Modifiers;

public class XAxisDragModifier : ModifierBase
{
    public override string Type => "XAxisDrag";
    public DragMode? DragMode { get; set; }
}
