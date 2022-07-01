namespace SciChartBlazor.Styles;

public class HeatmapColorMap
{
	public HeatmapColorMap(double minimum, double maximum, ICollection<GradientStop> gradientStops)
	{
		Minimum = minimum;
		Maximum = maximum;
		GradientStops = gradientStops;
	}

	public double Minimum { get; }
	public double Maximum { get; }
	public ICollection<GradientStop> GradientStops { get; }
}