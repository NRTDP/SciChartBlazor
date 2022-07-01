using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Annotations;
public class TextAnnotation : AnnotationBase
{
	[SciChartElementType]
	public override string Type => "SVGTextAnnotation";
	public string? Text { get; set; }
}