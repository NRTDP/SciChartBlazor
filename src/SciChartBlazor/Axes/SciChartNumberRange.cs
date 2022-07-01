namespace SciChartBlazor.Axes;

[Serializable]
public class SciChartNumberRange
{
    public SciChartNumberRange(double min, double max)
    {
        Max = max;
        Min = min;
    }

    public double Min { get; set; }
    public double Max { get; set; }
}