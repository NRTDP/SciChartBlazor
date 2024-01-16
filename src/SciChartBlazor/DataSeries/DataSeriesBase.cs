using System.Text.Json;
using System.Text.Json.Serialization;
using static SciChartBlazor.SciChartElementBase;

namespace SciChartBlazor.DataSeries;

/// <summary>
/// 
/// </summary>
public abstract class DataSeriesBase
{
    /// <summary>
    /// Gets or sets the name of the data series.
    /// </summary>
    /// <value>
    /// The name of the data series.
    /// </value>
    public string? DataSeriesName { get; set; } = null;

    /// <summary>
    /// Gets or sets the data is sorted in x.
    /// </summary>
    /// <value>
    /// The data is sorted in x.
    /// </value>
    public bool? DataIsSortedInX { get; set; } = null;

    /// <summary>
    /// Gets or sets the contains na n.
    /// </summary>
    /// <value>
    /// The contains na n.
    /// </value>
    public bool? ContainsNaN { get; set; } = null;

    /// <summary>
    /// Gets the json.
    /// </summary>
    /// <returns></returns>
    public string GetJson()
    {
        var typeAttribute = this.GetType().GetCustomAttributes(typeof(SciChartDataSeries), true).FirstOrDefault() as SciChartDataSeries;
        var output = new jsonObject();

        switch (typeAttribute?.GetDataType())
        {
            case DataSeriesType.Xy:
				{
					output.Type = DataSeriesType.Xy;
					output.Options = (DataSeriesBase)this;
                    break;
                }
            case DataSeriesType.Xyy:
                {
					output.Type = DataSeriesType.Xyy;
					output.Options = (DataSeriesBase)this;
					break;
                }
            case DataSeriesType.Xyz:
                {
					output.Type = DataSeriesType.Xyz;
					output.Options = (DataSeriesBase)this;
					break;
                }
        }

        JsonSerializerOptions _op = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter(), new DataSeriesConverter() }
        };

        return JsonSerializer.Serialize(output, _op);
    }

    [Serializable]
    private class jsonObject
    {
	    public DataSeriesType? Type { get; set; } = null;
        public DataSeriesBase? Options { get; set; } = null;
    }
}