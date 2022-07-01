using SciChartBlazor.DataSeries;
using SciChartBlazor.Styles;

namespace SciChartBlazor.RenderableSeries;

public class SplineMountainRenderableSeries<TX, TY> : RenderableSeriesBase
{
	[SciChartElementType]
	public override string Type => "SplineMountainSeries";

	[SciChartDataSeries(DataSeriesType.XyData)]
	public override DataSeriesBase DataSeries { get; }

	public double? ZeroLineY { get; set; }
	public int? InterpolationPoints { get; set; }
	public GradientParams? FillLinearGradient { get; set; }

	public SplineMountainRenderableSeries(XyDataSeries<TX, TY> dataSeries)
	{
		DataSeries = dataSeries;
	}
}