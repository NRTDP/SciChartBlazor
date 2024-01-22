using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Runtime.InteropServices;
using SciChartBlazor.Annotations;
using SciChartBlazor.Axes;
using SciChartBlazor.DataSeries;
using SciChartBlazor.Modifiers;
using SciChartBlazor.RenderableSeries;
using SciChartBlazor.Services;
using SciChartBlazor.Themes;

namespace SciChartBlazor;

/// <summary>
/// Creates and controls a SciChart Surface.
/// </summary>
public class SciChartBuilder : IDisposable
{
    ElementReference _chart;
    string _elementId = "";
    IJSRuntime _jsRuntime;
    ISciChartBlazorService _sciChartBlazorService;

    /// <summary>
    /// Creates a SciChart Surface.
    /// </summary>
    /// <param name="elementRef">The ElementReference for the containg div.</param>
    /// <param name="jsRuntime">The JS Runtime</param>
    /// <param name="sciChartBlazorService">The SciChartBlazor Service</param>
    public SciChartBuilder(ElementReference elementRef, IJSRuntime jsRuntime, ISciChartBlazorService sciChartBlazorService)
    {
        _chart = elementRef;
        _jsRuntime = jsRuntime;
        _sciChartBlazorService = sciChartBlazorService;
    }

    private List<AnnotationBase> _annotations = new();

    /// <summary>
    /// The current annotations.
    /// </summary>
    public IReadOnlyList<AnnotationBase> Annotations => _annotations;

    private List<ModifierBase> _modifiers = new();

    /// <summary>
    /// The current modifers. Not currently used.
    /// </summary>
    public IReadOnlyList<ModifierBase> Modifiers => _modifiers; //not used, maybe should use in the future


    private List<SeriesBase> _renderableSeries = new();
    /// <summary>
    /// The current active renderable series.
    /// </summary>
    public ICollection<SeriesBase> RenderableSeries => _renderableSeries;

    /// <summary>
    /// Initialize a chart.
    /// </summary>
    /// <param name="theme">A SciChart theme. Defaults to SciChartThemeLight.</param>
    /// <param name="modifiers">Modifiers to use.</param>
    /// <returns></returns>
    public async Task CreateChart(SciChartThemeBase? theme = null, ICollection<ModifierBase>? modifiers = null)
    {
        theme ??= new SciChartThemeLight();

        await _sciChartBlazorService.SetRuntimeLicenseKey();
        _elementId = await _jsRuntime.InvokeAsync<string>("sciChartBlazorJson.initSciChart", _chart, theme);

        if (modifiers != null)
            await AddModifiers(modifiers);
    }

    /// <summary>
    /// Runs the Test JS script. For testing Json strings.
    /// </summary>
    /// <returns></returns>
    public async Task<string> Test()
    {

        await this._sciChartBlazorService.SetRuntimeLicenseKey();

        var data = await _jsRuntime.InvokeAsync<string>("sciChartBlazorJson.test", _chart);

        return data;
    }

    /// <summary>
    /// Zooms to a region in the X axis.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public async Task ZoomTo(double start, double end) =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.zoomTo", _chart, start, end);
    
    /// <summary>
    /// Add an Axis.
    /// </summary>
    /// <param name="Axis"></param>
    /// <param name="axisType">X or Y axis</param>
    /// <returns></returns>
    public async Task AddAxis(AxisBase Axis, AxisType axisType)
    {
        //Console.WriteLine(Axis.GetJson());

        if (axisType == AxisType.X)
            await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.addXAxis", _chart, Axis.GetJson());
        else if (axisType == AxisType.Y)
            await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.addYAxis", _chart, Axis.GetJson());
    }
    /// <summary>
    /// Add chart modifiers.
    /// </summary>
    /// <param name="modifiers"></param>
    /// <returns></returns>
    public async Task AddModifiers(IEnumerable<ModifierBase> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            var ids = await _jsRuntime.InvokeAsync<string[]>("sciChartBlazorJson.addModifiers", _chart,
                modifier.GetJson());
            modifier.Id = ids.First();
        }
    }
    
    /// <summary>
    /// Set modifier isEnabled value to given value.
    /// </summary>
    /// <param name="modifierBase">Modifier to be altered.</param>
    /// <param name="isEnabled">Value to be set.</param>
    public async Task SetModifierEnabled(ModifierBase modifierBase, bool isEnabled)
     => await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.setModifierEnabled", _chart, modifierBase.Id, isEnabled);
    

    /// <summary>
    /// Reverse the boolean value of isEnabled of given modifier.
    /// </summary>
    /// <param name="modifierBase">Modifier to be altered.</param>
    public async Task ToggleModifierEnabled(ModifierBase modifierBase)
        => await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.toggleModifierEnabled", _chart, modifierBase.Id);
    
    /// <summary>
    /// Clear all modifiers.
    /// </summary>
    /// <returns></returns>
    public async Task ClearModifiers() => 
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.clearModifiers", _chart);

    /// <summary>
    /// Add a single chart modifier.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public async Task AddModifier(ModifierBase modifier)
    {
        var ids = await _jsRuntime.InvokeAsync<string[]>("sciChartBlazorJson.addModifiers", _chart, modifier.GetJson());
        modifier.Id = ids.First();
    }

    /// <summary>
    /// Add multiple RenderableSeries.
    /// </summary>
    /// <param name="series"></param>
    /// <returns></returns>
    public async Task AddSeries(IList<SeriesBase> series)
    {
        foreach (var single in series)
        {
            string json = single.GetJson();
            var ids = await _jsRuntime.InvokeAsync<string[]>("sciChartBlazorJson.addSeries", _chart, json);

            for (int i = 0; i < series.Count(); i++)
            {
                series[i].Id = ids[i];
                this._renderableSeries.Add(series[i]);
            }
        }
    }
    /// <summary>
    /// Add a single RenderableSeries.
    /// </summary>
    /// <param name="series"></param>
    /// <returns></returns>
    public async Task AddSeries(SeriesBase series)
    {
        string json = series.GetJson();

        var ids = await _jsRuntime.InvokeAsync<string[]>("sciChartBlazorJson.addSeries", _chart, json);
        series.Id = ids[0];
        this._renderableSeries.Add(series);
    }
    /// <summary>
    /// Add a single RenderableSeries without marshalling. May be faster with large datasets.
    /// </summary>
    /// <param name="series"></param>
    /// <returns></returns>
    public async Task AddSeriesUnmarshalled(SeriesBase series)
    {
        await Task.Run(() => 
        { 
         string json = series.GetJson();

        var unmarshalledRuntime = (IJSUnmarshalledRuntime)_jsRuntime;

            var jsUnmarshalledReference = unmarshalledRuntime
            .InvokeUnmarshalled<IJSUnmarshalledObjectReference>(
                "returnObjectReference");

            string id =
            jsUnmarshalledReference.InvokeUnmarshalled<string, string, string>("addSeriesUnmarshalled", _elementId, json);

        series.Id = id;
        this._renderableSeries.Add(series);
        }); 
    }

    /// <summary>
    /// Add annotations.
    /// </summary>
    /// <param name="annotations"></param>
    /// <returns></returns>
    public async Task AddAnnotations(IList<AnnotationBase> annotations)
    {
        //This is super hacky!
        string[] json1 = annotations.Select(x => x.GetJson()).ToArray();

        string json2 = "[";

        for (int i = 0; i < json1.Length; i++)
        {
            if (i != 0)
                json2 += ",";
            json2 += $" {json1[i]}";

        }
        json2 += "]";

        var ids = await _jsRuntime.InvokeAsync<string[]>("sciChartBlazorJson.addAnnotations", _chart, json2);

        for (int i = 0; i < annotations.Count(); i++)
        {
            annotations[i].Id = ids[i];
            this._annotations.Add(annotations[i]);
        }
    }
    /// <summary>
    /// Add an annotation.
    /// </summary>
    /// <param name="annotations"></param>
    /// <returns></returns>
    public async Task AddAnnotation(AnnotationBase annotations)
    {
        string json = annotations.GetJson();

        var ids = await _jsRuntime.InvokeAsync<string[]>("sciChartBlazorJson.addAnnotations", _chart, json);
        annotations.Id = ids[0];
        this._annotations.Add(annotations);
    }
    /// <summary>
    /// Remove an annotation.
    /// </summary>
    /// <param name="annotation"></param>
    /// <returns></returns>
    public async Task RemoveAnnotation(AnnotationBase annotation)
    {
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.removeAnnotation", _chart, annotation.Id);
        this._annotations.Remove(annotation);
    }
    /// <summary>
    /// Remove a RenderableSeries.
    /// </summary>
    /// <param name="series"></param>
    /// <returns></returns>
    public async Task RemoveRenderableSeries(SeriesBase series) => await RemoveRenderableSeries(series.Id);

    /// <summary>
    /// Remove a RenderableSeries.
    /// </summary>
    /// <param name="renderableSeriesId"></param>
    /// <returns></returns>
    public async Task RemoveRenderableSeries(string renderableSeriesId)
    {
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.removeSeries", _chart, renderableSeriesId);
        this._renderableSeries.Remove(this._renderableSeries.First(x=>x.Id == renderableSeriesId));
    }

    /// <summary>
    /// Update a renderable series. This is usually faster than creating a new one.
    /// </summary>
    /// <param name="series"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task UpdateRenderableSeries(SeriesBase series, DataSeriesBase data) => await UpdateRenderableSeries(series.Id, data);

    /// <summary>
    /// Update a renderable series. This is usually faster than creating a new one.
    /// </summary>
    /// <param name="renderableSeriesId"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public async Task UpdateRenderableSeries(string renderableSeriesId, DataSeriesBase data)
    {
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.updateSeries", _chart, renderableSeriesId, data.GetJson());
    }


    /// <summary>
    /// Update a renderable series without marshalling. Potentially much faster with large datasets. Currently only X,Y dataseries.
    /// </summary>
    /// <param name="series"></param>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <returns></returns>
    public async Task UpdateRenderableSeriesUnmarshalled(SeriesBase series, double[] X, double[] Y)
    {
        await Task.Run(() => 
        { 
         var unmarshalledRuntime = (IJSUnmarshalledRuntime)_jsRuntime;

        var callResultForBoolean =
            unmarshalledRuntime.InvokeUnmarshalled<UpdateSeriesMetaData,double[],double[], bool>(
                "sciChartBlazorJson.updateSeriesUnmarshalled", new UpdateSeriesMetaData() { Element= _elementId, SeriesId = series.Id }, X, Y );
        });
    }

    /// <summary>
    /// Cleats all annotations.
    /// </summary>
    /// <returns></returns>
    public async Task ClearAnnotations() => 
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.clearAnnotations", _chart);

    /// <summary>
    /// Clears the chart.
    /// </summary>
    /// <returns></returns>
    public async Task Clear()
    {
        this.RenderableSeries.Clear();
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.clear", _chart);
    }
    /// <summary>
    /// Dispose the chart async.
    /// </summary>
    /// <returns></returns>
    public async Task DisposeAsync() =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.unregister", _chart);
    
    /// <summary>
    /// Zoom to Extents.
    /// </summary>
    /// <returns></returns>
    public async Task ZoomExtents() =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.zoomExtents", _chart);

    /// <summary>
    /// Dispose the chart.
    /// </summary>
    public void Dispose() =>
        _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.unregister", _chart);

    /// <summary>
    /// Mark if the Series should be included or excluded in the legend modifier.
    /// </summary>
    /// <param name="legendModifierId">Legend modifier id.</param>
    /// <param name="seriesId">Series id.</param>
    /// <param name="isIncluded">Included in legend.</param>
    public async Task IncludeSeries(string legendModifierId, string seriesId, bool isIncluded) =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.includeSeries", _chart, legendModifierId, seriesId, isIncluded);
    
    
[StructLayout(LayoutKind.Explicit)]
private struct UpdateSeriesMetaData
{
    [FieldOffset(8)]
    public string Element;

    [FieldOffset(0)]
    public string SeriesId;
}
}