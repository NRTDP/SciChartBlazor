using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using SciChartBlazor.DataSeries;

namespace SciChartBlazor;
/// <summary>
/// The base class for all SciChartElements. Handles Json conversion.
/// </summary>
public abstract class SciChartElementBase
{
    /// <summary>
    /// The type of the element. Usually the name of the element in JS.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [SciChartElementType]
    public abstract string Type { get; }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public string Id { get; set; } = default!;

    JsonSerializerOptions _op = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
         AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter(), new DataSeriesConverter() }
    };


    /// <summary>
    /// A converter for serializing Dataseries and interfaces.
    /// </summary>

    public class DataSeriesConverter : JsonConverter<DataSeriesBase>
    {
        /// <summary>
        /// Reads and converts the JSON to type.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override DataSeriesBase Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a specified value as JSON.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
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
    /// <summary>
    /// Gets the json.
    /// </summary>
    /// <returns></returns>
    public string GetJson()
    {
        return JsonSerializer.Serialize(GetJsonObject(), _op);;
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
            if (attr is SciChartElementType)
            {
                return attr as SciChartElementType;
            }
            else if (attr is SciChartCustomElementType)
            {
                return attr as SciChartCustomElementType;
            }
            else if (attr is PureIntEnum)
            {
                return attr as PureIntEnum;
            }
            else if (attr is HasOptions)
            {
                return attr as HasOptions;
            }
            else if (attr is SciChartDataSeries a)
            {
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

/// <summary>
/// An attribute that defines the type/name of an element.
/// </summary>
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Property)]
public class SciChartElementType : Attribute { }

/// <summary>
/// An attribute that informs the Json parser that this option also contains options.
/// </summary>
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Property)]
public class HasOptions : Attribute { }

/// <summary>
/// An attribute that defines this property as a custom element.
/// </summary>
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Property)]
public class SciChartCustomElementType : Attribute { }

/// <summary>
/// An attribute that defines this property as a dataseries of type <type name="DataSeriesType" />
/// </summary>
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
public class SciChartDataSeries : Attribute
{
    DataSeriesType type;
    /// <summary>
    /// Initializes a new instance of the <see cref="SciChartDataSeries"/> class.
    /// </summary>
    /// <param name="dataSeriesType">Type of the data series.</param>
    public SciChartDataSeries(DataSeriesType dataSeriesType)
    {
        type = dataSeriesType;
    }

    /// <summary>
    /// Gets the type of the data.
    /// </summary>
    /// <returns></returns>
    public DataSeriesType GetDataType()
    {
        return type;
    }
}

/// <summary>
/// An attribute informing the json writer that this enum should be written as an int.
/// </summary>
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Property)]
public class PureIntEnum : Attribute { }