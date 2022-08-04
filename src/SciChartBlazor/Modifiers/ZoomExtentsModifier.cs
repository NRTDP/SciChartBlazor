namespace SciChartBlazor.Modifiers;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Modifiers.ModifierBase" />
public class ZoomExtentsModifier : ModifierBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public override string Type => "ZoomExtents";

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
}