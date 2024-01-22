using SciChartBlazor.RenderableSeries;

namespace SciChartBlazor.DataSeries;

/// <summary>
/// A collection of StackedSeriesBase
/// </summary>
public class StackedColumnCollection : RenderableCollectionSeriesBase
{
	/// <summary>
	/// The type of the element. Usually the name of the element in JS.
	/// </summary>
	/// <value>
	/// The type.
	/// </value>
	public override string Type => "StackedColumnCollection";

	/// <summary>
	/// Gets the data series.
	/// </summary>
	/// <value>
	/// The data series.
	/// </value>
	[SciChartDataSeries(DataSeriesType.Stacked)]
	public override ICollection<StackedRenderableSeriesBase> DataSeries { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="StackedColumnCollection"/> class.
	/// </summary>
	public StackedColumnCollection()
	{
		DataSeries = new List<StackedRenderableSeriesBase>();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="StackedColumnCollection"/> class.
	/// </summary>
	/// <param name="series">The stacked series.</param>
	public StackedColumnCollection(ICollection<StackedRenderableSeriesBase> series)
	{
		DataSeries = series;
	}
}

