using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.DataSeries;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TX">The type of the x.</typeparam>
/// <typeparam name="TY">The type of the y.</typeparam>
/// <typeparam name="TZ">The type of the z.</typeparam>
/// <seealso cref="SciChartBlazor.DataSeries.DataSeriesBase" />
public class XyzDataSeries<TX, TY, TZ> : DataSeriesBase
{
    /// <summary>
    /// Gets the x values.
    /// </summary>
    /// <value>
    /// The x values.
    /// </value>
    public TX[] XValues { get; }

    /// <summary>
    /// Gets the y values.
    /// </summary>
    /// <value>
    /// The y values.
    /// </value>
    public TY[] YValues { get; }

    /// <summary>
    /// Gets the z values.
    /// </summary>
    /// <value>
    /// The z values.
    /// </value>
    public TZ[] ZValues { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="XyzDataSeries{TX, TY, TZ}"/> class.
    /// </summary>
    /// <param name="xValues">The x values.</param>
    /// <param name="yValues">The y values.</param>
    /// <param name="zValues">The z values.</param>
    public XyzDataSeries(TX[] xValues, TY[] yValues, TZ[] zValues)
    {
        XValues = xValues;
        YValues = yValues;
        ZValues = zValues;
    }
}
