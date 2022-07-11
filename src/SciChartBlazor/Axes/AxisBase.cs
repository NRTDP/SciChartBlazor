using SciChartBlazor.Styles;

namespace SciChartBlazor.Axes;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.SciChartElementBase" />
public abstract class AxisBase : SciChartElementBase
{

    //public AxisBase(AxisStyle? axisStyle)
    //{
    //    AxisStyle = axisStyle;
    //}

    //public AxisStyle? AxisStyle { get; } = null;

    /// <summary>
    /// * In multi-axis scenarios you will need to set the xAxisId/yAxisId properties of series, annotations, modifiers to match that of the axis
    /// you want them to be registered on.
    /// </summary>
    /// <value>
    /// The visible range.
    /// </value>

    public SciChartNumberRange? VisibleRange { get; set; } = null;

    /// <summary>
    /// Gets or sets the grow by.
    /// </summary>
    /// <value>
    /// The grow by.
    /// </value>
    public SciChartNumberRange? GrowBy { get; set; } = null;

    /// <summary>
    /// Gets or sets the axis title.
    /// </summary>
    /// <value>
    /// The axis title.
    /// </value>
    public string? AxisTitle { get; set; } = null;

    /// <summary>
    /// Gets or sets the label format.
    /// </summary>
    /// <value>
    /// The label format.
    /// </value>
    public NumericFormat LabelFormat { get; set; }

    /// <summary>
    /// Gets or sets the label precision.
    /// </summary>
    /// <value>
    /// The label precision.
    /// </value>
    public int LabelPrecision { get; set; }


    /// <summary>
    /// Gets or sets the axis title style.
    /// </summary>
    /// <value>
    /// The axis title style.
    /// </value>
    public AxisTitleStyle? AxisTitleStyle { get; set; } = null;

    /// <summary>
    /// Gets or sets the major grid line style.
    /// </summary>
    /// <value>
    /// The major grid line style.
    /// </value>
    public MajorGridLineStyle? MajorGridLineStyle { get; set; } = null;


    /// <summary>
    /// Gets or sets the minor grid line style.
    /// </summary>
    /// <value>
    /// The minor grid line style.
    /// </value>
    public MinorGridLineStyle? MinorGridLineStyle { get; set; } = null;


    /// <summary>
    /// Gets or sets the major tick line style.
    /// </summary>
    /// <value>
    /// The major tick line style.
    /// </value>
    public MajorTickLineStyle? MajorTickLineStyle { get; set; } = null;


    /// <summary>
    /// Gets or sets the minor tick line style.
    /// </summary>
    /// <value>
    /// The minor tick line style.
    /// </value>
    public MinorTickLineStyle? MinorTickLineStyle { get; set; } = null;


    /// <summary>
    /// Gets or sets the is visible.
    /// </summary>
    /// <value>
    /// The is visible.
    /// </value>
    public bool? IsVisible { get; set; } = null;


    /// <summary>
    /// Gets or sets the draw major bands.
    /// </summary>
    /// <value>
    /// The draw major bands.
    /// </value>
    public bool? DrawMajorBands { get; set; } = null;

    /// <summary>
    /// Gets or sets the axis band fill.
    /// </summary>
    /// <value>
    /// The axis band fill.
    /// </value>
    public string? AxisBandFill { get; set; } = null;

    /// <summary>
    /// Gets or sets the draw labels.
    /// </summary>
    /// <value>
    /// The draw labels.
    /// </value>
    public bool? DrawLabels { get; set; } = null;


    /// <summary>
    /// Gets or sets the draw major grid lines.
    /// </summary>
    /// <value>
    /// The draw major grid lines.
    /// </value>
    public bool? DrawMajorGridLines { get; set; } = null;

    /// <summary>
    /// Gets or sets the draw minor grid lines.
    /// </summary>
    /// <value>
    /// The draw minor grid lines.
    /// </value>
    public bool? DrawMinorGridLines { get; set; } = null;


    /// <summary>
    /// Gets or sets the draw major tick lines.
    /// </summary>
    /// <value>
    /// The draw major tick lines.
    /// </value>
    public bool? DrawMajorTickLines { get; set; } = null;

    /// <summary>
    /// Gets or sets the draw minor tick lines.
    /// </summary>
    /// <value>
    /// The draw minor tick lines.
    /// </value>
    public bool? DrawMinorTickLines { get; set; } = null;


    /// <summary>
    /// Gets or sets the axis alignment.
    /// </summary>
    /// <value>
    /// The axis alignment.
    /// </value>
    public AxisAlignment? AxisAlignment { get; set; } = null;

    /// <summary>
    /// Gets or sets the automatic range.
    /// </summary>
    /// <value>
    /// The automatic range.
    /// </value>
    public AutoRange? AutoRange { get; set; } = null;

    /// <summary>
    /// Gets or sets the automatic ticks.
    /// </summary>
    /// <value>
    /// The automatic ticks.
    /// </value>
    public bool? AutoTicks { get; set; } = null;

    /// <summary>
    /// Gets or sets the maximum automatic ticks.
    /// </summary>
    /// <value>
    /// The maximum automatic ticks.
    /// </value>
    public int? MaxAutoTicks { get; set; } = null;

    /// <summary>
    /// Gets or sets the minors per major.
    /// </summary>
    /// <value>
    /// The minors per major.
    /// </value>
    public int? MinorsPerMajor { get; set; } = null;

    /// <summary>
    /// Gets or sets the major delta.
    /// </summary>
    /// <value>
    /// The major delta.
    /// </value>
    public int? MajorDelta { get; set; } = null;

    /// <summary>
    /// Gets or sets the minor delta.
    /// </summary>
    /// <value>
    /// The minor delta.
    /// </value>
    public int? MinorDelta { get; set; } = null;

    /// <summary>
    /// Limits {@link AxisCore.visibleRange}, meaning the chart cannot autorange outside that range
    /// </summary>
    public SciChartNumberRange? VisibleRangeLimit { get; set; } = null;

    /// <summary>
    /// If this is set, it will be used as the range when zooming extents, rather than the data max range
    /// </summary>
    private SciChartNumberRange? zoomExtentsRange { get; set; } = null; // this errors out.

    /// <summary>
    /// Gets or sets the axis border.
    /// </summary>
    /// <value>
    /// The axis border.
    /// </value>
    public AxisBorder? AxisBorder { get; set; } = null;

    /// <summary>
    /// Gets or sets the is inner axis.
    /// </summary>
    /// <value>
    /// The is inner axis.
    /// </value>
    public bool? isInnerAxis { get; set; } = null;

    //to do: add label providers

}
/// <summary>
/// A number range used by SciChart.
/// </summary>
[Serializable]
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