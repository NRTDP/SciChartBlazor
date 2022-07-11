using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Modifiers;

/// <summary>
/// a Mouse Wheel Zoom Modifier.
/// </summary>
/// <seealso cref="SciChartBlazor.Modifiers.ModifierBase" />
public class MouseWheelZoomModifier : ModifierBase
{
    /// <summary>
    /// Gets or sets the grow factor.
    /// </summary>
    /// <value>
    /// The grow factor.
    /// </value>
    public double? GrowFactor { get; set; }

    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "MouseWheelZoom";
}
