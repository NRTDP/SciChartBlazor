using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Modifiers;

/// <summary>
/// The base class for Modifiers.
/// </summary>
/// <seealso cref="SciChartBlazor.SciChartElementBase" />
public abstract class ModifierBase : SciChartElementBase
{
    /// <summary>
    /// Gets or sets the execute on.
    /// </summary>
    /// <value>
    /// The execute on.
    /// </value>
    [PureIntEnum]
    public ExecuteOn? ExecuteOn { get; set; } = null;

    /// <summary>
    /// Gets or sets the xy direction.
    /// </summary>
    /// <value>
    /// The xy direction.
    /// </value>
    public XyDirection? XyDirection { get; set; } = null;

    /// <summary>
    /// Gets or sets the x axis identifier.
    /// </summary>
    /// <value>
    /// The x axis identifier.
    /// </value>
    public string? XAxisId { get; set; } = null;

    /// <summary>
    /// Gets or sets the y axis identifier.
    /// </summary>
    /// <value>
    /// The y axis identifier.
    /// </value>
    public string? YAxisId { get; set; } = null;
}