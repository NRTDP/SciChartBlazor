namespace SciChartBlazor.Styles;

public partial class GradientParams
{
    public GradientParams(IList<GradientStop> gradientStops, Point startPoint, Point endPoint)
    {
        GradientStops = gradientStops;
        StartPoint = startPoint;
        EndPoint = endPoint;
    }

    public IList<GradientStop> GradientStops { get; }

    public Point StartPoint { get; }
    public Point EndPoint { get; }
}