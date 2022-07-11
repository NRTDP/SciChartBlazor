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
public class RolloverModifier : ModifierBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "Rollover";

    /// <summary>
    /// Gets or sets the rollover line stroke.
    /// </summary>
    /// <value>
    /// The rollover line stroke.
    /// </value>
    public string? RolloverLineStroke { get; set; }

    /// <summary>
    /// Gets or sets the rollover line stroke thickness.
    /// </summary>
    /// <value>
    /// The rollover line stroke thickness.
    /// </value>
    public double? RolloverLineStrokeThickness { get; set; }

    /// <summary>
    /// Gets or sets the show rollover line.
    /// </summary>
    /// <value>
    /// The show rollover line.
    /// </value>
    public bool? ShowRolloverLine { get; set; }
}
