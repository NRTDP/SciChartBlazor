using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// The Base class for a collection of series.
/// </summary>
/// <seealso cref="SeriesBase" />
public abstract class RenderableCollectionSeriesBase : SeriesBase
{
	/// <summary>
	/// Gets the collection of data series.
	/// </summary>
	/// <value>
	/// The collection data series.
	/// </value>
	[SciChartDataSeries(DataSeriesType.Stacked)]
	public abstract ICollection<StackedRenderableSeriesBase> DataSeries { get; }
}