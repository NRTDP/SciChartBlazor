namespace SciChartBlazor.Modifiers;

public abstract class ModifierBase : SciChartElementBase
{
    [PureIntEnum]
    public ExecuteOn? ExecuteOn { get; set; } = null;
    public XyDirection? XyDirection { get; set; } = null;
    public string? XAxisId { get; set; } = null;
    public string? YAxisId { get; set; } = null;
}