namespace SciChartBlazor.Modifiers;

/// <summary>
/// A Legend Modifier.
/// </summary>
/// <seealso cref="SciChartBlazor.Modifiers.ModifierBase" />
public class LegendModifier : ModifierBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public override string Type => "Legend";
    
    /// <summary>
    /// Sets whether the legend has visibility checkboxes in it or not.
    /// </summary>
    public bool? ShowCheckboxes { get; set; }
    
    /// <summary>
    /// Sets whether Series markers are visible or not.
    /// </summary>
    public bool? ShowSeriesMarkers { get; set; }
    
    /// <summary>
    /// Sets the initial orientation of the legend.
    /// </summary>
    public LegendOrientation? Orientation { get; set; }
    
    /// <summary>
    /// The parent div element Id or reference, the Legend will be appended to this element.
    /// </summary>
    public string? PlacementDivId { get; set; }
}