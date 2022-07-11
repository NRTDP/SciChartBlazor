namespace SciChartBlazor.DataSeries;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <typeparam name="TZ">The type of the z.</typeparam>
/// <seealso cref="SciChartBlazor.DataSeries.DataSeriesBase" />
public class UniformHeatmapDataSeries<TX, TY, TZ> : DataSeriesBase
{
    /// <summary>
    /// Gets the x start.
    /// </summary>
    /// <value>
    /// The x start.
    /// </value>
    public TX XStart { get; }

    /// <summary>
    /// Gets the x step.
    /// </summary>
    /// <value>
    /// The x step.
    /// </value>
    public TX XStep { get; }

    /// <summary>
    /// Gets the y start.
    /// </summary>
    /// <value>
    /// The y start.
    /// </value>
    public TY YStart { get; }

    /// <summary>
    /// Gets the y step.
    /// </summary>
    /// <value>
    /// The y step.
    /// </value>
    public TY YStep { get; }

    /// <summary>
    /// Gets the z values.
    /// </summary>
    /// <value>
    /// The z values.
    /// </value>
    public TZ[][]? ZValues { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="UniformHeatmapDataSeries{TX, TY, TZ}"/> class.
    /// </summary>
    /// <param name="xStart">The x start.</param>
    /// <param name="xStep">The x step.</param>
    /// <param name="yStart">The y start.</param>
    /// <param name="yStep">The y step.</param>
    /// <param name="zValues">The z values.</param>
    public UniformHeatmapDataSeries(TX xStart, TX xStep, TY yStart, TY yStep, TZ[][]? zValues = null)
    {
        XStart = xStart;
        XStep = xStep;
        YStart = yStart;
        YStep = yStep;
        ZValues = zValues;
    }
}
