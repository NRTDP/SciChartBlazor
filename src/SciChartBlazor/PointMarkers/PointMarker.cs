namespace SciChartBlazor;

[Serializable]
public class PointMarker : SciChartElementBase
{
	string _type;

	public PointMarker(PointMarkerShape shape)
	{
		_type = shape.ToString();
	}

	public double? Width { get; set; }
	public double? Height { get; set; }
	public string? Fill { get; set; }
	public string? Stroke { get; set; }
	public double? StrokeThickness { get; set; }

	public double Size { get; set; }


	[SciChartElementType]
	public override string Type => _type;
}