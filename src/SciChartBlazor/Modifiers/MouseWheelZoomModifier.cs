using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Modifiers;

public class MouseWheelZoomModifier : ModifierBase
{
    public double? GrowFactor { get; set; }

    [SciChartElementType]
    public override string Type => "MouseWheelZoom";
}
