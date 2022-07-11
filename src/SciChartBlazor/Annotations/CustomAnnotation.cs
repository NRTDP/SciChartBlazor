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
public class CustomAnnotation : AnnotationBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
	public override string Type => "SVGCustomAnnotation";

    /// <summary>
    /// Gets or sets the SVG string.
    /// </summary>
    /// <value>
    /// The SVG string.
    /// </value>
    public string? SvgString { get; set; }
}

