namespace SciChartBlazor.Modifiers;

//this is a custom modifier

/// <summary>
/// A Rubber Band selection modifier (Custom).
/// </summary>
/// <seealso cref="SciChartBlazor.Modifiers.ModifierBase" />
public class RubberBandXySelectionModifier : ModifierBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "Custom";


    /// <summary>
    /// Gets the type of the custom.
    /// </summary>
    /// <value>
    /// The type of the custom.
    /// </value>
    [SciChartCustomElementType]
    public string customType => "RubberBandXYSelection";

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

    /// <summary>
    /// Gets or sets the range select.
    /// </summary>
    /// <value>
    /// The range select.
    /// </value>
    public bool? RangeSelect { get; set; }


}
