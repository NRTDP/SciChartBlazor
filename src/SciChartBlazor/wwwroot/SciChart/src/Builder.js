
import { SciChartSurface } from "scichart/Charting/Visuals/SciChartSurface";
import { SciChartJSLightTheme } from "scichart/Charting/Themes/SciChartJSLightTheme";
import { chartBuilder } from "scichart/Builder/chartBuilder";
import { RubberBandXySelectorModifier } from "././SciChartExtensions/RubberBandXySelectorModifier"
import { EBaseType } from "scichart/types/BaseType"
import { SciChartDefaults } from "scichart/Charting/Visuals/SciChartDefaults";
import { XyDataSeries } from "scichart/Charting/Model/XyDataSeries";

let chartInstances = {};

function resolveContext(element) {
    return chartInstances.hasOwnProperty(element.id) && chartInstances[element.id];
}


export async function setLincenseKey(key) {

    SciChartSurface.setRuntimeLicenseKey(key);
}

export async function initSciChart(element, theme = null) {

    window.SetFocusToElement = (element) => {
        element.focus();
    };

    SciChartSurface.useWasmFromCDN()

    const { sciChartSurface, wasmContext } = await SciChartSurface.create(element.id);

    if (theme != null) {
        sciChartSurface.applyTheme(theme);
    }
    else {
        theme = new SciChartJSLightTheme();
        console.log(theme)
        sciChartSurface.applyTheme(theme);
    }

    chartInstances[element.id] = { sciChartSurface, wasmContext };

    chartBuilder.registerType(
        EBaseType.Chart2DModifier,
        "RubberBandXYSelection",
        (options) => new RubberBandXySelectorModifier(options), true
    );

    SciChartDefaults.enableResampling = true;

    return element.id;
}

export async function addXAxis(element, jsonString) {

    const { sciChartSurface, wasmContext } = resolveContext(element);
    sciChartSurface.xAxes.clear();
    const axis = chartBuilder.buildAxes(wasmContext, jsonString);
    sciChartSurface.xAxes.add(...axis);

}

export async function zoomExtents(element) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    sciChartSurface.zoomExtents();
}

export async function zoomTo(element, start, end) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    var xAxis = sciChartSurface.xAxes.get(0);

    const coordCalc = xAxis.getCurrentCoordinateCalculator();
    var coordStart = coordCalc.getCoordinate(start);
    var coordend = coordCalc.getCoordinate(end);

    xAxis.zoom(coordStart, coordend);
}

export async function addYAxis(element, jsonString) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    sciChartSurface.yAxes.clear();
    const axis = chartBuilder.buildAxes(wasmContext, jsonString);
    sciChartSurface.yAxes.add(...axis);
}

export async function clearAnnotations(element) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    sciChartSurface.annotations.clear();
}

export async function removeAnnotation(element, id) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    var item = sciChartSurface.annotations.getById(id);
    sciChartSurface.annotations.remove(item);
}

export async function removeSeries(element, id) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    var item = sciChartSurface.renderableSeries.getById(id);
    sciChartSurface.renderableSeries.remove(item);
}

export async function updateSeries(element, id, data) {
    const { sciChartSurface, wasmContext } = resolveContext(element);

    var item = sciChartSurface.renderableSeries.getById(id);
    const newdata = chartBuilder.buildDataSeries(wasmContext, data);
    item.dataSeries = newdata;
}

export async function updateSeriesUnmarshalled(fields, dataX, dataY) {

    const element = Blazor.platform.readStringField(fields, 8);
    const id = Blazor.platform.readStringField(fields, 0);
    const X = parseFloat64Array(dataX);
    const Y = parseFloat64Array(dataY);
    const { sciChartSurface, wasmContext } = chartInstances.hasOwnProperty(element) && chartInstances[element];

    var item = sciChartSurface.renderableSeries.getById(id);
    var data = new XyDataSeries(wasmContext);

    for (let i = 0; i < X.length; i++) {
        data.append(X[i], Y[i]);
    }

    item.dataSeries = data;
}

function parseFloat64Array(array) {
    const dataPtr = getArrayDataPointer(array);
    const length = getValueI32(dataPtr);

    const array8 = Module.HEAPU8.subarray(dataPtr + 4, dataPtr + 4 + (length * 8));
    return new Float64Array(array8.buffer, array8.byteOffset, array8.byteLength / 8);
}



function getArrayDataPointer(e) {
    return e + 12;
}

function getValueI32(e) {
    return Module.HEAP32[e >> 2];
}



export async function addAnnotations(element, jsonString) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    const annotations = chartBuilder.buildAnnotations(jsonString);
    sciChartSurface.annotations.add(...annotations);

    var ids = annotations.map(function (i) {
        return i.id;
    });
    return ids
}

export async function clearModifiers(element) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    sciChartSurface.chartModifiers.clear();
}

export async function addModifiers(element, jsonString) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    const mod = chartBuilder.buildModifiers(jsonString);
    sciChartSurface.chartModifiers.add(...mod);
}

export async function addSeries(element, jsonString) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    const seriesArray = chartBuilder.buildSeries(wasmContext, jsonString);

    sciChartSurface.renderableSeries.add(...seriesArray);
    sciChartSurface.zoomExtents();

    var ids = seriesArray.map(function (i) {
        return i.id;
    });
    return ids
}

export async function addSeriesUnmarshalled(element, jsonString) {

    const id = BINDING.conv_string(element)
    const { sciChartSurface, wasmContext } = chartInstances.hasOwnProperty(id) && chartInstances[id];
    const json = BINDING.conv_string(jsonString);
    const seriesArray = chartBuilder.buildSeries(wasmContext, json);

    sciChartSurface.renderableSeries.add(...seriesArray);
    sciChartSurface.zoomExtents();

    var ids = seriesArray.map(function (i) {
        return i.id;
    });
    return ids[0];
}

export async function clear(element) {
    const { sciChartSurface, wasmContext } = resolveContext(element);

    sciChartSurface.renderableSeries.clear();
    sciChartSurface.annotations.clear();
}

export function addCustomEventListener(dotNetObjectRef, name) {
    document.addEventListener(name, (event) => {
        dotNetObjectRef.invokeMethodAsync('OnCustomEvent', event.detail)
    });
}