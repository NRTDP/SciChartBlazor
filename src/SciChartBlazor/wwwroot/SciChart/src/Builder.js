
import { RubberBandXySelectorModifier } from "././SciChartExtensions/RubberBandXySelectorModifier"
import {
    SciChartSurface,
    SciChartJSLightTheme,
    chartBuilder,
    EBaseType,
    SciChartDefaults,
    XyDataSeries,
    NumericAxis,
    MouseWheelZoomModifier,
    ZoomExtentsModifier,
    ZoomPanModifier,
    FastLineRenderableSeries,
    NumberRange,
    Point,
    EAnimationType,
    ShadowEffect
} from "scichart";


let chartInstances = {};

function resolveContext(element) {
    return chartInstances.hasOwnProperty(element.id) && chartInstances[element.id];
}

export async function setLicenseKey(key) {

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

export async function setYAxisVisibleRange(element, min, max) {
    const { sciChartSurface, wasmContext } = resolveContext(element);

    var yAxis = sciChartSurface.yAxes.get(0);

    yAxis.visibleRange = new NumberRange(min, max);
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

export async function setModifierEnabled(element, id, isEnabled) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    const item = sciChartSurface.chartModifiers.getById(id);
    item.isEnabled = isEnabled
}

export async function toggleModifierEnabled(element, id) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    const item = sciChartSurface.chartModifiers.getById(id);
    item.isEnabled = !item.isEnabled
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

    return mod.map(function (i) {
        return i.id;
    })
}

export async function addSeries(element, jsonString) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    const seriesArray = chartBuilder.buildSeries(wasmContext, jsonString);

    sciChartSurface.renderableSeries.add(...seriesArray);
    //sciChartSurface.zoomExtents();

    var ids = seriesArray.map(function (i) {
        return i.id;
    });
    return ids
}

window.returnObjectReference = () => {
    return {
        addSeriesUnmarshalled: function (element, jsonString) {

            const id = BINDING.conv_string(element)
            const { sciChartSurface, wasmContext } = chartInstances.hasOwnProperty(id) && chartInstances[id];
            const json = BINDING.conv_string(jsonString);
            const seriesArray = chartBuilder.buildSeries(wasmContext, json);

            sciChartSurface.renderableSeries.add(...seriesArray);
            sciChartSurface.zoomExtents();

            var ids = seriesArray.map(function (i) {
                return i.id;
            });
            return BINDING.js_string_to_mono_string(ids[0]);
        }
    };
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

export async function unregister(element) {
    const { sciChartSurface, wasmContext } = resolveContext(element);
    sciChartSurface.delete();
}

export async function test(element) {

    SciChartSurface.useWasmFromCDN()
  
    const { sciChartSurface, wasmContext } = await SciChartSurface.create(element.id);


    sciChartSurface.xAxes.add(new NumericAxis(wasmContext));
    sciChartSurface.yAxes.add(new NumericAxis(wasmContext, { growBy: new NumberRange(0.05, 0.05) }));

    const xValues = Array.from({ length: 100 }, (x, i) => i);
    const yValues = xValues.map(x => Math.sin(x * 0.1));

    sciChartSurface.renderableSeries.add(new FastLineRenderableSeries(wasmContext, {
        dataSeries: new XyDataSeries(wasmContext, { xValues, yValues }),
        stroke: "#ff6600",
        strokeThickness: 5,
        animation: { type: EAnimationType.Wave, options: { zeroLine: -1, pointDurationFraction: 0.5, duration: 1000 } },
        effect: new ShadowEffect(wasmContext, { brightness: 1, offset: new Point(5, -10), range: 0.7 })

    }));

    sciChartSurface.chartModifiers.add(new ZoomPanModifier());
    sciChartSurface.chartModifiers.add(new ZoomExtentsModifier());
    sciChartSurface.chartModifiers.add(new MouseWheelZoomModifier());

    // Zoom to fit
    sciChartSurface.zoomExtents();

    const definition = sciChartSurface.toJSON(true);


    return JSON.stringify(definition);


}