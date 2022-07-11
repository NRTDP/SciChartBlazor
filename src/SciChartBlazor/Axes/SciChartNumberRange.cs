namespace SciChartBlazor.Axes;

/// <summary>
/// 
/// </summary>
public class SciChartNumberRange
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SciChartNumberRange"/> class.
    /// </summary>
    /// <param name="min">The minimum.</param>
    /// <param name="max">The maximum.</param>
    public SciChartNumberRange(double min, double max)
    {
        Max = max;
        Min = min;
    }
    /// <summary>
    /// Determines the minimum of the parameters.
    /// </summary>
    /// <value>
    /// The minimum.
    /// </value>
    public double Min { get; set; }

    /// <summary>
    /// Determines the maximum of the parameters.
    /// </summary>
    /// <value>
    /// The maximum.
    /// </value>
    public double Max { get; set; }
}