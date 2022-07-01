using System.Text.Json;
using System.Text.Json.Serialization;
using static SciChartBlazor.SciChartElementBase;

namespace SciChartBlazor.DataSeries;

[Serializable]
public abstract class DataSeriesBase
{
    public string? DataSeriesName { get; set; } = null;

    public bool? DataIsSortedInX { get; set; } = null;

    public bool? ContainsNaN { get; set; } = null;

    public string GetJson()
    {
        var typeAttribute = this.GetType().GetCustomAttributes(typeof(SciChartDataSeries), true).FirstOrDefault() as SciChartDataSeries;
        var output = new jsonObject();

        switch (typeAttribute?.GetDataType())
        {
            case DataSeriesType.XyData:
                {
                    output.XyData = (DataSeriesBase)this;
                    break;
                }
            case DataSeriesType.XyyData:
                {
                    output.XyyData = (DataSeriesBase)this;
                    break;
                }
            case DataSeriesType.XyzData:
                {
                    output.XyzData = (DataSeriesBase)this;
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
        public DataSeriesBase? XyData { get; set; } = null;

        public DataSeriesBase? XyyData { get; set; } = null;

        public DataSeriesBase? XyzData { get; set; } = null;
    }
}