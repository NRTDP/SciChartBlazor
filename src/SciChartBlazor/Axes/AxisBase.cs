using SciChartBlazor.Styles;

namespace SciChartBlazor.Axes;

public abstract class AxisBase : SciChartElementBase
{

    //public AxisBase(AxisStyle? axisStyle)
    //{
    //    AxisStyle = axisStyle;
    //}

    //public AxisStyle? AxisStyle { get; } = null;

    /// <summary>
    ///  * In multi-axis scenarios you will need to set the xAxisId/yAxisId properties of series, annotations, modifiers to match that of the axis
    ///     you want them to be registered on.
    /// </summary>


    public SciChartNumberRange? VisibleRange { get; set; } = null;

    public SciChartNumberRange? GrowBy { get; set; } = null;

    public string? AxisTitle { get; set; } = null;
    public NumericFormat LabelFormat { get; set; }
    public int LabelPrecision { get; set; }

    public AxisTitleStyle? AxisTitleStyle { get; set; } = null;
    public MajorGridLineStyle? MajorGridLineStyle { get; set; } = null;

    public MinorGridLineStyle? MinorGridLineStyle { get; set; } = null;

    public MajorTickLineStyle? MajorTickLineStyle { get; set; } = null;

    public MinorTickLineStyle? MinorTickLineStyle { get; set; } = null;

    public bool? IsVisible { get; set; } = null;

    public bool? DrawMajorBands { get; set; } = null;
    public string? AxisBandFill { get; set; } = null;
    public bool? DrawLabels { get; set; } = null;

    public bool? DrawMajorGridLines { get; set; } = null;
    public bool? DrawMinorGridLines { get; set; } = null;

    public bool? DrawMajorTickLines { get; set; } = null;
    public bool? DrawMinorTickLines { get; set; } = null;

    public AxisAlignment? AxisAlignment { get; set; } = null;
    public AutoRange? AutoRange { get; set; } = null;
    public bool? AutoTicks { get; set; } = null;
    public int? MaxAutoTicks { get; set; } = null;
    public int? MinorsPerMajor { get; set; } = null;
    public int? MajorDelta { get; set; } = null;
    public int? MinorDelta { get; set; } = null;
    /// <summary>
    /// Limits {@link AxisCore.visibleRange}, meaning the chart cannot autorange outside that range
    /// </summary>
    public SciChartNumberRange? VisibleRangeLimit { get; set; } = null;
    /// <summary>
    /// If this is set, it will be used as the range when zooming extents, rather than the data max range
    /// </summary>
    public SciChartNumberRange? zoomExtentsRange { get; set; } = null;

    public AxisBorder? AxisBorder { get; set; } = null;

    public bool? isInnerAxis { get; set; } = null;

    //to do: add label providers

}

[Serializable]
public class SciChartNumberRange
{
    public SciChartNumberRange(double min, double max)
    {
        Max = max;
        Min = min;
    }

    public double Min { get; set; }
    public double Max { get; set; }
}