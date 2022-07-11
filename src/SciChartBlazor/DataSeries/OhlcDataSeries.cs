namespace SciChartBlazor.DataSeries;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TOpen">The type of the open.</typeparam>
/// <typeparam name="THigh">The type of the high.</typeparam>
/// <typeparam name="TLow">The type of the low.</typeparam>
/// <typeparam name="TClose">The type of the close.</typeparam>
/// <seealso cref="SciChartBlazor.DataSeries.DataSeriesBase" />
public class OhlcDataSeries<TOpen, THigh, TLow, TClose> : DataSeriesBase
{
    /// <summary>
    /// Gets the open values.
    /// </summary>
    /// <value>
    /// The open values.
    /// </value>
    public TOpen[] OpenValues { get; }

    /// <summary>
    /// Gets the high values.
    /// </summary>
    /// <value>
    /// The high values.
    /// </value>
    public THigh[] HighValues { get; }

    /// <summary>
    /// Gets the low values.
    /// </summary>
    /// <value>
    /// The low values.
    /// </value>
    public TLow[] LowValues { get; }

    /// <summary>
    /// Gets the close values.
    /// </summary>
    /// <value>
    /// The close values.
    /// </value>
    public TClose[] CloseValues { get; }


    /// <summary>
    /// Initializes a new instance of the <see cref="OhlcDataSeries{TOpen, THigh, TLow, TClose}"/> class.
    /// </summary>
    /// <param name="openValues">The open values.</param>
    /// <param name="highValues">The high values.</param>
    /// <param name="lowValues">The low values.</param>
    /// <param name="closeValues">The close values.</param>
    public OhlcDataSeries(TOpen[] openValues, THigh[] highValues, TLow[] lowValues, TClose[] closeValues)
    {
        OpenValues = openValues;
        HighValues = highValues;
        LowValues = lowValues;
        CloseValues = closeValues;
    }
}
