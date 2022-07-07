namespace SciChartBlazor.Styles;

[Serializable]
/// <summary>
/// Shader effect. Not currently working :/
/// </summary>
public class ShaderEffect : SciChartElementBase
{
	string _type { get; }
	/// <summary>
	/// Create a shader effect.
	/// </summary>
	/// <param name="effectType"></param>
	public ShaderEffect(ShaderEffectType effectType)
	{
		_type = effectType.ToString();
	}


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	 
	public string? Color { get; set; }
	public double? Intensity { get; set; }
	public Point? Offset { get; set; }
	public double? Range { get; set; }

	[SciChartElementType]
	public override string Type => _type;
}
