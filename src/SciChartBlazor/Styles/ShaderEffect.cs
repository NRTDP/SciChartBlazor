namespace SciChartBlazor.Styles;

/// <summary>
/// Sharder effect. Untested.
/// </summary>
public class ShaderEffect 
{
	/// <summary>
	/// Create a shader effect.
	/// </summary>
	/// <param name="effectType"></param>
	public ShaderEffect(ShaderEffectType effectType)
	{
		EffectType = effectType;
	}


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public ShaderEffectType EffectType { get; }
	public string? Color { get; set; }
	public double? Intensity { get; set; }
	public Point? Offset { get; set; }
	public double? Range { get; set; }
}
