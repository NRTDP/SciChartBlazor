namespace SciChartBlazor.Themes;
public class SciChartColorMap
{
    public SciChartColorMap(double offset, string color)
    {
        Offset = offset;
        Color = color;
    }
    public double Offset { get; set; }
    public string Color { get; set; }
}
