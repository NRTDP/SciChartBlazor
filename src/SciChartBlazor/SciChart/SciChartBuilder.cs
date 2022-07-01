using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SciChartBlazor.Annotations;
using SciChartBlazor.Axes;
using SciChartBlazor.DataSeries;
using SciChartBlazor.Modifiers;
using SciChartBlazor.RenderableSeries;
using SciChartBlazor.Services;
using SciChartBlazor.Themes;
using System.Runtime.InteropServices;

namespace SciChartBlazor;

public class SciChartBuilder : IDisposable
{
    ElementReference _chart;
    string _elementId = string.Empty;
    IJSRuntime _jsRuntime;
    ISciChartBlazorService _sciChartBlazorService;

    public SciChartBuilder(ElementReference elementRef, IJSRuntime jsRuntime, ISciChartBlazorService sciChartBlazorService)
    {
        _chart = elementRef;
        _jsRuntime = jsRuntime;
        _sciChartBlazorService = sciChartBlazorService;
    }
    private List<AnnotationBase> _annotations = new();
    public IReadOnlyList<AnnotationBase> Annotations => _annotations;

    private List<ModifierBase> _modifiers = new();
    public IReadOnlyList<ModifierBase> Modifiers => _modifiers; //not used, maybe should use in the future

    private List<RenderableSeriesBase> _renderableSeries = new();
    public ICollection<RenderableSeriesBase> RenderableSeries => _renderableSeries;

    public async Task CreateChart(SciChartThemeBase? theme = null, ICollection<ModifierBase>? modifiers = null)
    {
        theme ??= new SciChartThemeLight();

        //theme.GridBackgroundBrush = "white";
        //theme.GridBorderBrush = "white";
        //theme.SciChartBackground = "white";

        await _sciChartBlazorService.SetRuntimeLicenseKey();
        _elementId = await _jsRuntime.InvokeAsync<string>("sciChartBlazorJson.initSciChart", _chart, theme);

        if (modifiers != null)
            await AddModifiers(modifiers);
    }

    public async Task ZoomTo(double start, double end) =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.zoomTo", _chart, start, end);

    public async Task AddAxis(AxisBase Axis, AxisType axisType)
    {
        if (axisType == AxisType.X)
            await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.addXAxis", _chart, Axis.GetJson());
        else if (axisType == AxisType.Y)
            await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.addYAxis", _chart, Axis.GetJson());
    }

    public async Task AddModifiers(IEnumerable<ModifierBase> modifiers)
    {
        foreach (var modifier in modifiers)
            await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.addModifiers", _chart, modifier.GetJson());
    }

    public async Task ClearModifiers() =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.clearModifiers", _chart);


    public async Task AddModifiers(ModifierBase modifier) =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.addModifiers", _chart, modifier.GetJson());

    public async Task AddSeries(IList<RenderableSeriesBase> series)
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

    public async Task AddSeries(RenderableSeriesBase series)
    {
        string json = series.GetJson();

        var ids = await _jsRuntime.InvokeAsync<string[]>("sciChartBlazorJson.addSeries", _chart, json);
        series.Id = ids[0];
        this._renderableSeries.Add(series);
    }

    public async Task AddSeriesUnmarshalled(RenderableSeriesBase series)
    {
        await Task.Run(() =>
        {
            string json = series.GetJson();

            var unmarshalledRuntime = (IJSUnmarshalledRuntime)_jsRuntime;
            var jsUnmarshalledReference = unmarshalledRuntime.InvokeUnmarshalled<IJSUnmarshalledObjectReference>("returnObjectReference");

            series.Id = jsUnmarshalledReference.InvokeUnmarshalled<string, string, string>("addSeriesUnmarshalled", _elementId, json); ;
            this._renderableSeries.Add(series);
        });
    }

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

    public async Task AddAnnotations(AnnotationBase annotations)
    {
        string json = annotations.GetJson();

        var ids = await _jsRuntime.InvokeAsync<string[]>("sciChartBlazorJson.addAnnotations", _chart, json);
        annotations.Id = ids[0];
        this._annotations.Add(annotations);
    }

    public async Task RemoveAnnotation(AnnotationBase annotation)
    {
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.removeAnnotation", _chart, annotation.Id);
        this._annotations.Remove(annotation);
    }

    public async Task RemoveRenderableSeries(RenderableSeriesBase renderableSeries)
    {
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.removeSeries", _chart, renderableSeries.Id);
        this._renderableSeries.Remove(renderableSeries);
    }

    public async Task UpdateRenderableSeries(RenderableSeriesBase renderableSeries, DataSeriesBase data)
    {
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.updateSeries", _chart, renderableSeries.Id, data.GetJson());
    }

    public async Task UpdateRenderableSeriesUnmarshalled(RenderableSeriesBase renderableSeries, double[] X, double[] Y)
    {
        await Task.Run(() =>
        {
            var unmarshalledRuntime = (IJSUnmarshalledRuntime)_jsRuntime;

            var callResultForBoolean =
                unmarshalledRuntime.InvokeUnmarshalled<UpdateSeriesMetaData, double[], double[], bool>(
                    "sciChartBlazorJson.updateSeriesUnmarshalled", new UpdateSeriesMetaData() { Element = _elementId, SeriesId = renderableSeries.Id }, X, Y);
        });
    }

    public async Task ClearAnnotations() =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.clearAnnotations", _chart);

    public async Task Clear()
    {
        this.RenderableSeries.Clear();
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.clear", _chart);
    }

    public async Task DisposeAsync() =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.unregister", _chart);

    public async Task ZoomExtents() =>
        await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.zoomExtents", _chart);

    public void Dispose() => _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.unregister", _chart);
}

[StructLayout(LayoutKind.Explicit)]
public struct UpdateSeriesMetaData
{
    [FieldOffset(8)]
    public string Element;

    [FieldOffset(0)]
    public string SeriesId;
}

public enum AxisType
{
    X,
    Y
}