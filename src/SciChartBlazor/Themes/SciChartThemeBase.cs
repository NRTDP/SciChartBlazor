using System.Text.Json;
using System.Text.Json.Serialization;

namespace SciChartBlazor.Themes;
[Serializable]
public abstract class SciChartThemeBase
{
    public abstract string Type { get; }
    public virtual string AnnotationsGripsBackroundBrush { get; set; } = "#FFFFFF33";
    public virtual string AnnotationsGripsBorderBrush { get; set; } = "#232323FF";
    public virtual string Axis3DBandsFill { get; set; } = "#33333333";
    public virtual string AxisBandsFill { get; set; } = "#AAAAAA09";
    public virtual string AxisPlaneBackgroundFill { get; set; } = "TRANSPARENT";
    public virtual string AxisBorder { get; set; } = "#00000000";
    public virtual string ColumnFillBrush { get; set; } = "#777777FF";
    public virtual string ColumnLineColor { get; set; } = "#777777FF";
    public virtual string CursorLineBrush { get; set; } = "#33333355";
    public virtual IList<SciChartColorMap> DefaultColorMapBrush { get; set; } = new List<SciChartColorMap>
    {
        new SciChartColorMap(0, "DARKBLUE"),
        new SciChartColorMap(0.5, "CORNFLOWERBLUE"),
        new SciChartColorMap(1, "#FF22AAFF"),
    };
    public virtual string DownBandSeriesFillColor { get; set; } = "#E26565A0";
    public virtual string DownBandSeriesLineColor { get; set; } = "#E26565FF";
    public virtual string DownBodyBrush { get; set; } = "#E26565D0";
    public virtual string DownWickColor { get; set; } = "#E26565FF";
    public virtual string GridBackgroundBrush { get; set; } = "#05333377";
    public virtual string GridBorderBrush { get; set; } = "#33333399";
    public virtual string LabelBackgroundBrush { get; set; } = "#D0D0D0BB";
    public virtual string LabelBorderBrush { get; set; } = "#33333377";
    public virtual string LabelForegroundBrush { get; set; } = "#555555FF";
    public virtual string LegendBackgroundBrush { get; set; } = "#33333333";
    public virtual string LineSeriesColor { get; set; } = "#777777FF";

    public virtual string LoadingAnimationBackground { get; set; } = "#F9F9F9FF";
    public virtual string LoadingAnimationForeground { get; set; } = "#777777FF";

    public virtual string MajorGridLineBrush { get; set; } = "#CFCFCFFF";
    public virtual string MinorGridLineBrush { get; set; } = "#CFCFCFFF";
    public virtual string MountainAreaBrush { get; set; } = "#76B7E2B4";
    public virtual string MountainLineBrush { get; set; } = "#777777FF";
    public virtual string MountainLineColor { get; set; } = "#777777FF";
    public virtual string OverviewFillBrush { get; set; } = "#33333322";
    public virtual string PlaneBorderColor { get; set; } = "#EEEEEEFF";
    public virtual string RolloverLineBrush { get; set; } = "#33333333";
    public virtual string RubberBandFillBrush { get; set; } = "#33333333";
    public virtual string RubberBandStrokeBrush { get; set; } = "#33333377";
    public virtual string SciChartBackground { get; set; } = "#F9F9F9FF";
    public virtual string ScrollbarBackgroundBrush { get; set; } = "#33333322";
    public virtual string ScrollbarBorderBrush { get; set; } = "#12121255";
    public virtual string ScrollbarGripsBackgroundBrush { get; set; } = "#FFFFFF66";
    public virtual string ScrollbarViewportBackgroundBrush { get; set; } = "#FFFFFF44";
    public virtual string ScrollbarViewportBorderBrush { get; set; } = "#12121255";
    public virtual string ShadowEffectColor { get; set; } = "#A0AABAFA";
    public virtual string TextAnnotationBackground { get; set; } = "#FFFFFFFF";
    public virtual string TextAnnotationForeground { get; set; } = "#000000FF";
    public virtual string TickTextBrush { get; set; } = "#333333FF";
    public virtual string UpBandSeriesFillColor { get; set; } = "#52CC5490";
    public virtual string UpBandSeriesLineColor { get; set; } = "#52CC54FF";
    public virtual string UpBodyBrush { get; set; } = "#52CC54A0";
    public virtual string UpWickColor { get; set; } = "#52CC54FF";
    public virtual string AxisTitleColor { get; set; } = "#777777FF";  
}
