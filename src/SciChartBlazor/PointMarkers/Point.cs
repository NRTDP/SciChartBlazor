namespace SciChartBlazor;

/// <summary>
/// A point.
/// </summary>
public struct Point
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> struct.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public Point(double x, double y)
	{
		X = x;
		Y = y;
	}
    /// <summary>
    /// Gets x.
    /// </summary>
    /// <value>
    /// x.
    /// </value>
    public double X { get; }

    /// <summary>
    /// Gets y.
    /// </summary>
    /// <value>
    /// y.
    /// </value>
    public double Y { get; }
}
