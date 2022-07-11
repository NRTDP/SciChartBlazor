using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Styles;

/// <summary>
/// The parameters for a gradient.
/// </summary>
public partial class GradientParams
{
    /// <summary>
    /// The parameters for a gradient.
    /// </summary>
    /// <param name="gradientStops"></param>
    /// <param name="startPoint"></param>
    /// <param name="endPoint"></param>
    public GradientParams(IList<GradientStop> gradientStops, Point startPoint, Point endPoint)
    {
        GradientStops = gradientStops;
        StartPoint = startPoint;
            EndPoint = endPoint;
    }
    /// <summary>
    /// A list of gradient transitions.
    /// </summary>
    public IList<GradientStop> GradientStops { get; }

    /// <summary>
    /// The start point.
    /// </summary>
    public Point StartPoint { get; }

    /// <summary>
    /// The end point.
    /// </summary>
    public Point EndPoint { get; }

}
