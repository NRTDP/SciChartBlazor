using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Axes.LabelProviders
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="SciChartBlazor.SciChartElementBase" />

    public class TextLabelProvider : SciChartElementBase
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public override string Type => "Text";

        /// <summary>
        /// Gets or sets the labels.
        /// </summary>
        /// <value>
        /// The labels.
        /// </value>
        public string[]? Labels { get;set; } 
    }
}
