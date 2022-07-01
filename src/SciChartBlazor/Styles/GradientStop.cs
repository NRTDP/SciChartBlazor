namespace SciChartBlazor.Styles;

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