namespace SciChartBlazor.Themes;
/// <summary>
/// A sciChart color map.
/// </summary>
public class SciChartColorMap
{
    /// <summary>
    /// Creates a scichart color map.
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="color"></param>
    public SciChartColorMap(double offset, string color)
    {
        Offset = offset;
        Color = color;
    }
    /// <summary>
    /// The offset.
    /// </summary>
    public double Offset { get; set; }

    /// <summary>
    /// The color.
    /// </summary>
    public string Color { get; set; }
}
