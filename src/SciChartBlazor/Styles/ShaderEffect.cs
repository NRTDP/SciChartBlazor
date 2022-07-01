namespace SciChartBlazor.Styles;

public class ShaderEffect 
{
	public ShaderEffect(ShaderEffectType effectType)
	{
		EffectType = effectType;
	}

	public ShaderEffectType EffectType { get; }
	public string? Color { get; set; }
	public double? Intensity { get; set; }
	public Point? Offset { get; set; }
	public double? Range { get; set; }
}
