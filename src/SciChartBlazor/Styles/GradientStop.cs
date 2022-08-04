namespace SciChartBlazor.Styles;

/// <summary>
/// The Stop color of a gradient. Not tested.
/// </summary>

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class GradientStop
{
    public GradientStop(string color, double offset)
    {
        Color = color;
        Offset = offset;
    }
    public string Color { get; }
    public double Offset { get; }    

}