using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Annotations;

public class LineAnnotation : AnnotationBase
{
    [SciChartElementType]
    public override string Type => "RenderContextLineAnnotation";
    public string? Stroke { get; set; }
    public double? StrokeThickness { get; set; }
}

