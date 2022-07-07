namespace SciChartBlazor.Styles;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member



/// <summary>
/// The color map for a heatmap. Not tested.
/// </summary>
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