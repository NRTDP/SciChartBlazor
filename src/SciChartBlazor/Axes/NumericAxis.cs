using SciChartBlazor.Styles;

namespace SciChartBlazor.Axes;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Axes.AxisBase" />
public class NumericAxis : AxisBase
{
    //public NumericAxis(AxisStyle? axisStyle = null) : base(axisStyle)
    //{
    //}	
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public override string Type => "NumericAxis";
}
