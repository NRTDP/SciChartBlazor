using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Annotations;

/// <summary>
/// 
/// </summary>
/// <seealso cref="SciChartBlazor.Annotations.AnnotationBase" />
public class HorizontalLineAnnotation : AnnotationBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public override string Type => "RenderContextHorizontalLineAnnotation";

    /// <summary>
    /// Gets or sets the label placement.
    /// </summary>
    /// <value>
    /// The label placement.
    /// </value>
    public LabelPlacement? LabelPlacement { get; set; }

    /// <summary>
    /// Gets or sets the show label.
    /// </summary>
    /// <value>
    /// The show label.
    /// </value>
    public bool? ShowLabel { get; set; }

    /// <summary>
    /// Gets or sets the stroke.
    /// </summary>
    /// <value>
    /// The stroke.
    /// </value>
    public string? Stroke { get; set; }

    /// <summary>
    /// Gets or sets the stroke thickness.
    /// </summary>
    /// <value>
    /// The stroke thickness.
    /// </value>
    public double? StrokeThickness { get; set; }

    /// <summary>
    /// Gets or sets the axis label fill.
    /// </summary>
    /// <value>
    /// The axis label fill.
    /// </value>
    public string? AxisLabelFill { get; set; }
}

