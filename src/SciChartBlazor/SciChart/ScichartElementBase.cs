using SciChartBlazor.DataSeries;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SciChartBlazor;

public abstract class SciChartElementBase
{
    [SciChartElementType]
    public abstract string Type { get; }
    public string Id { get; set; } = default!;

    JsonSerializerOptions _op = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter(), new DataSeriesConverter() }
    };

    public class DataSeriesConverter : JsonConverter<DataSeriesBase>
    {
        public override DataSeriesBase Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(
            Utf8JsonWriter writer,
            DataSeriesBase value,
            JsonSerializerOptions options)
        {
            switch (value)
            {
                case null:
                    JsonSerializer.Serialize(writer, (DataSeriesBase?)null, options);
                    break;
                default:
                    {
                        var type = value.GetType();
                        JsonSerializer.Serialize(writer, value, type, options);
                        break;
                    }
            }
        }
    }

    public string GetJson()
    {
        return JsonSerializer.Serialize(GetJsonObject(), _op);
    }

    private jsonObject GetJsonObject()
    {
        jsonObject output = new();

        var properites = this.GetType().GetProperties();

        foreach (var property in properites)
        {
            var value = property.GetValue(this);

            if (value != null)
            {
                var attribute = GetAttribute(property);
                switch (attribute)
                {
                    case SciChartElementType:
                        {
                            output.Type = value.ToString();
                            break;
                        }
                    case SciChartCustomElementType:
                        {
                            output.CustomType = value.ToString();
                            break;
                        }
                    case PureIntEnum:
                        {
                            if (output.Options == null) { output.Options = new(); }

                            output.Options.Add(ConvertToCamelCase(property.Name), (int)value);
                            break;
                        }
                    case DataSeriesType.XyData:
                        {
                            output.XyData = (DataSeriesBase)value;
                            break;
                        }
                    case DataSeriesType.XyyData:
                        {
                            output.XyyData = (DataSeriesBase)value;
                            break;
                        }
                    case DataSeriesType.XyzData:
                        {
                            output.XyzData = (DataSeriesBase)value;
                            break;
                        }
                    case HasOptions:
                        if (output.Options == null) { output.Options = new(); }
                        if (value is SciChartElementBase v)
                        {
                            var thisJson = v.GetJson();
                            output.Options.Add(ConvertToCamelCase(property.Name), v.GetJsonObject());
                        }

                        break;
                    default:
                        {
                            if (output.Options == null) { output.Options = new(); }
                            output.Options.Add(ConvertToCamelCase(property.Name), value);
                            break;
                        }
                }
            }
        }

        return output;
    }

    private string ConvertToCamelCase(string str)
    {
        return char.ToLowerInvariant(str[0]) + str.Substring(1);
    }

    private object? GetAttribute(PropertyInfo info)
    {
        Attribute[] attrs = Attribute.GetCustomAttributes(info);  // Reflection.

        // Displaying output.  
        foreach (Attribute attr in attrs)
        {
            switch (attr)
            {
                case SciChartElementType:
                    return attr as SciChartElementType;
                case SciChartCustomElementType:
                    return attr as SciChartCustomElementType;
                case PureIntEnum:
                    return attr as PureIntEnum;
                case HasOptions:
                    return attr as HasOptions;
                case SciChartDataSeries a:
                    return a.GetDataType();
            }
        }

        return null;
    }

    [Serializable]
    private class jsonObject
    {
        public string? Type { get; set; }
        public string? CustomType { get; set; }
        public Dictionary<string, object> Options { get; set; } = default!;
        public DataSeriesBase? XyData { get; set; } = null;
        public DataSeriesBase? XyyData { get; set; } = null;
        public DataSeriesBase? XyzData { get; set; } = null;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class SciChartElementType : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
public class HasOptions : Attribute { }

[AttributeUsage(AttributeTargets.Property)]
public class SciChartCustomElementType : Attribute { }

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
public class SciChartDataSeries : Attribute
{
    DataSeriesType type;
    public SciChartDataSeries(DataSeriesType dataSeriesType)
    {
        type = dataSeriesType;
    }

    public DataSeriesType GetDataType()
    {
        return type;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class PureIntEnum : Attribute { }