using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Modifiers;

public class YAxisDragModifier : ModifierBase
{
    public override string Type => "YAxisDrag";
    public DragMode? DragMode { get; set; }
}