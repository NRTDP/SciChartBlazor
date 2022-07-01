namespace SciChartBlazor;

public enum AxisAlignment
{
    Bottom,
    Left,
    Right,
    Top,
}

public enum AutoRange
{
    Always,
    Never,
    Once,
}

public enum LineDrawMode
{
    DiscontinousLine,
    PolyLine,
}

public enum ShaderEffectType
{
    Glow,
    Shadow,
}

public enum PointMarkerShape
{
    Ellipse,
    Square,
    Triangle,
    Cross,
    X
}

public enum XyDirection
{
    XDirection,
    XyDirection,
    YDirection
}

public enum DragMode
{
    Panning,
    Scaling,
}

public enum EasingFunction
{
    Cubic,
    Elastic,
    InCirc,
    InCubic,
    InExpo,
    InOutCirc,
    InOutCubic,
    InOutExpo,
    InOutQuad,
    InOutQuart,
    InOutQuint,
    InOutSine,
    InQuad,
    InQuart,
    InQuint,
    InSine,
    Linear,
    OutCirc,
    OutCubic,
    OutExpo,
    OutQuad,
    OutQuart,
    OutQuint,
    OutSine,
    Quadratic
}

public enum AnnotationLayer
{
    AboveChart,
    BelowChart,
}

public enum CoordinateMode
{
    DataValue,
    Pixel,
    Relative
}

public enum HorizontalAnchorPoint
{
    Left,
    Center,
    Right
}

public enum VerticalAnchorPoint
{
    Top,
    Center,
    Bottom
}

public enum LabelPlacement
{
    Auto,
    Axis,
    Bottom,
    BottomLeft,
    BottomRight,
    Left,
    Right,
    Top,
    TopLeft,
    TopRight
}

public enum ExecuteOn
{
    MouseLeftButton = 0,
    MouseMiddleButton = 1,
    MouseRightButton = 2
}

public enum NumericFormat
{
    /// <summary>
    /// No format, return the string representation unchanged
    /// </summary>
    NoFormat,

    /// <summary>
    /// Format to a specified number of decimal places
    /// </summary>
    Decimal,

    /// <summary>
    /// Format to a specified number of significant figures
    /// </summary>
    SignificantFigures,

    /// <summary>
    /// Format as a date in format DD/MM/YYYY
    /// </summary>
    Date_DDMMYYYY,

    /// <summary>
    /// Format as a date in format DD/MM/YY
    /// </summary>
    Date_DDMMYY,

    /// <summary>
    /// Format as a date in format DD/MM HH:MM
    /// </summary>
    Date_DDMMHHMM,

    /// <summary>
    /// Format as a date in format DD/MM
    /// </summary>
    Date_DDMM,

    /// <summary>
    /// Format as a date in format HH:MM
    /// </summary>
    Date_HHMM,

    /// <summary>
    /// Format using Exponential notation to a specified number of significant figures eg 1.0E0, 1.5E1, 2.7E2
    /// Note that this will ALWAYS be base 10, even when used on a Logarithmic axis
    /// </summary>
    Exponential,

    /// <summary>
    /// Format using Scientific notation to a specified number of significant figures eg 1.0x10^1, 1.5x10^2, 2.7x10^3
    /// On a Logarithmic axis, the base will be the same as the axis logarithmic base
    /// </summary>
    Scientific
}
public enum DataSeriesType
{
    XyData,
    XyyData,
    XyzData
}