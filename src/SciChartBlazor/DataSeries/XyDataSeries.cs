namespace SciChartBlazor.DataSeries;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <seealso cref="SciChartBlazor.DataSeries.DataSeriesBase" />
[SciChartDataSeries(DataSeriesType.XyData)]
public class XyDataSeries<TX,TY> : DataSeriesBase
{
    /// <summary>
    /// Gets the x values.
    /// </summary>
    /// <value>
    /// The x values.
    /// </value>
    public ICollection<TX> XValues { get; }

    /// <summary>
    /// Gets the y values.
    /// </summary>
    /// <value>
    /// The y values.
    /// </value>
    public ICollection<TY> YValues { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="XyDataSeries{TX, TY}"/> class.
    /// </summary>
    public XyDataSeries()
    {
        XValues = new List<TX>();  
        YValues = new List<TY>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XyDataSeries{TX, TY}"/> class.
    /// </summary>
    /// <param name="xValues">The x values.</param>
    /// <param name="yValues">The y values.</param>
    public XyDataSeries(ICollection<TX> xValues, ICollection<TY> yValues)
    {
        XValues = xValues;
        YValues = yValues;
    }
    /// <summary>
    /// Appends the specified x value.
    /// </summary>
    /// <param name="xValue">The x value.</param>
    /// <param name="yValue">The y value.</param>
    public void Append(TX xValue, TY yValue)
    {
        XValues.Add(xValue);
        YValues.Add(yValue);

    }
}
