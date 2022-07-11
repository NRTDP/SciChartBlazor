namespace SciChartBlazor.DataSeries;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY1">The type of the y1.</typeparam>
/// <typeparam name="TY2">The type of the y2.</typeparam>
/// <seealso cref="SciChartBlazor.DataSeries.DataSeriesBase" />
public class XyyDataSeries<TX, TY1, TY2> : DataSeriesBase
{
    /// <summary>
    /// Gets the x values.
    /// </summary>
    /// <value>
    /// The x values.
    /// </value>
    public TX[] XValues { get; }

    /// <summary>
    /// Gets the y1 values.
    /// </summary>
    /// <value>
    /// The y1 values.
    /// </value>
    public TY1[] Y1Values { get; }

    /// <summary>
    /// Gets the y2 values.
    /// </summary>
    /// <value>
    /// The y2 values.
    /// </value>
    public TY2[] Y2Values { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="XyyDataSeries{TX, TY1, TY2}"/> class.
    /// </summary>
    /// <param name="xValues">The x values.</param>
    /// <param name="y1Values">The y1 values.</param>
    /// <param name="y2Values">The y2 values.</param>
    public XyyDataSeries(TX[] xValues, TY1[] y1Values, TY2[] y2Values)
    {
        XValues = xValues;
        Y1Values = y1Values;
        Y2Values = y2Values;
    }
}
