
using System.Text.Json;

namespace SciChartBlazor.Modifiers;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Modifiers.ModifierBase" />
public class RubberBandXyZoomModifier : ModifierBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
	public override string Type => "RubberBandXYZoom";

    /// <summary>
    /// Gets or sets the is animated.
    /// </summary>
    /// <value>
    /// The is animated.
    /// </value>
    public bool? IsAnimated { get; set; }

    /// <summary>
    /// Gets or sets the duration of the animation.
    /// </summary>
    /// <value>
    /// The duration of the animation.
    /// </value>
    public double? AnimationDuration { get; set; }

    /// <summary>
    /// Gets or sets the easing function.
    /// </summary>
    /// <value>
    /// The easing function.
    /// </value>
    public EasingFunction? EasingFunction { get; set; }

    /// <summary>
    /// Gets or sets the fill.
    /// </summary>
    /// <value>
    /// The fill.
    /// </value>
    public string? Fill { get; set; }

    /// <summary>
    /// Gets or sets the stroke.
    /// </summary>
    /// <value>
    /// The stroke.
    /// </value>
    public string? Stroke { get; set; }

    /// <summary>
    /// Gets or sets the stroke thickness.
    /// </summary>
    /// <value>
    /// The stroke thickness.
    /// </value>
    public double? StrokeThickness { get; set; }


}
