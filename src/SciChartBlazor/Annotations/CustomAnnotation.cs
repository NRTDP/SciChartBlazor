using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Annotations;

public class CustomAnnotation : AnnotationBase
{
	[SciChartElementType]
	public override string Type => "SVGCustomAnnotation";
	public string? SvgString { get; set; }
}

