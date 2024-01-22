using SciChartBlazor.DataSeries;

namespace SciChartBlazor.RenderableSeries;

/// <summary>
/// The Base class for a series.
/// </summary>
/// <seealso cref="SciChartBlazor.RenderableSeries.SeriesBase" />
public abstract class RenderableSeriesBase : SeriesBase
{
	/// <summary>
	/// Gets the data series.
	/// </summary>
	/// <value>
	/// The data series.
	/// </value>
	public abstract DataSeriesBase DataSeries { get; }
}

