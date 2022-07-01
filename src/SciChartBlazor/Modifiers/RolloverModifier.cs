using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Modifiers;

public class RolloverModifier : ModifierBase
{
    [SciChartElementType]
    public override string Type => "Rollover";
    public string? RolloverLineStroke { get; set; }
    public double? RolloverLineStrokeThickness { get; set; }
    public bool? ShowRolloverLine { get; set; }
}
