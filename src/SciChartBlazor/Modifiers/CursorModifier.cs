namespace SciChartBlazor.Modifiers;

/// <summary>
/// A Cursor Modifier.
/// </summary>
/// <seealso cref="SciChartBlazor.Modifiers.ModifierBase" />
public class CursorModifier : ModifierBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public override string Type => "Cursor";

    /// <summary>
    /// Gets or sets the crosshair stroke.
    /// </summary>
    /// <value>
    /// The crosshair stroke.
    /// </value>
    public string? CrosshairStroke { get; set; }

    /// <summary>
    /// Gets or sets the crosshair stroke thickness.
    /// </summary>
    /// <value>
    /// The crosshair stroke thickness.
    /// </value>
    public double? CrosshairStrokeThickness { get; set; }

    /// <summary>
    /// Gets or sets the tooltip container background.
    /// </summary>
    /// <value>
    /// The tooltip container background.
    /// </value>
    public string? TooltipContainerBackground { get; set; }

    /// <summary>
    /// Gets or sets the tooltip text stroke.
    /// </summary>
    /// <value>
    /// The tooltip text stroke.
    /// </value>
    public string? TooltipTextStroke { get; set; }

    /// <summary>
    /// Gets or sets the show tooltip.
    /// </summary>
    /// <value>
    /// The show tooltip.
    /// </value>
    public bool? ShowTooltip { get; set; }

    /// <summary>
    /// Gets or sets the axis labels fill.
    /// </summary>
    /// <value>
    /// The axis labels fill.
    /// </value>
    public string? AxisLabelsFill { get; set; }

    /// <summary>
    /// Gets or sets the axis labels stroke.
    /// </summary>
    /// <value>
    /// The axis labels stroke.
    /// </value>
    public string? AxisLabelsStroke { get; set; }
}
