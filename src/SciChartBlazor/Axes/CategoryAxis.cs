using SciChartBlazor.Styles;

namespace SciChartBlazor.Axes;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Axes.AxisBase" />
public class CategoryAxis : AxisBase
{
    //public CategoryAxis(AxisStyle? axisStyle) : base(axisStyle)
    //{
    //}    
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    public override string Type => "CategoryAxis";
}

