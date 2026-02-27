Scichart have recently announced that they are devloping their own blazor wrapper! Which you can find here: [scichart.blazor.examples](https://github.com/abtsoftware/scichart.blazor.examples)


# SciChartBlazor
A Blazor wrapper for SciChart JS

| Version | Package | Description |
| ------- | ------- | ----------- |
| [![NuGet Package](https://img.shields.io/nuget/v/SciChartBlazor.svg)](https://www.nuget.org/packages/SciChartBlazor) | [SciChartBlazor](https://www.nuget.org/packages/SciChartBlazor) | .NET 6 |

> **Licensing and Trials** 
> SciChart no longer requires a license or a trial for community use. You can find details here: 
> * **[Licensing SciChart.js](https://www.scichart.com/community-licensing/)**

## Please Contribute!

This is an open source project that welcomes contributions/suggestions/bug reports from those who use it. If you have any ideas on how to improve the library, please [post an issue here on GitHub](https://github.com/NRTDP/SciChartBlazor/issues).

## Using SciChartBlazor
First either install the Nuget Package, or pull down the repository and reference the SciChartBlazor project directly.

For Wasm & Server side you need to register the ScichartBlazor Service (and add a license if you need one) in Project.cs, using the following code:
```C#
builder.Services.AddSciChart(options =>
{
    options.RuntimeLicenseKey = "LICENSE_HERE"; // if you're using the community license you can leave this bit out
});
```

Then add a reference to the sciChartBlazorJson.js file in either index.html (for Wasm) or _Layout.cshtml (Server side):
```HTML
<script async src="_content/SciChartBlazor/SciChart/sciChartBlazorJson.js"></script>
 ```
## Adding a chart to a razor page

Start by adding a div container for the chart:
```HTML
<div id="@Id" @ref="_chart" style="height:600px" />
```

id and ref are required and can be set up in the code{} or code-behind. The chart builder class should be Initialized inside OnAfterRenderAsync:
```C#
        private string Id { get; set; } = "C" + Guid.NewGuid().ToString();

        private protected ElementReference _chart;

        SciChartBuilder _chartBuilder = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //Create the chart
                _chartBuilder = new SciChartBuilder(_chart, JSRuntime, sciChartBlazorService);
                await _chartBuilder.CreateChart();
            }
            await base.OnAfterRenderAsync(firstRender);
        }
```
After initialization you can start building your chart. i.e.:
* Adding Modifiers:
```C#
            List<ModifierBase> modifiers = new()
            {
                new SciChartBlazor.Modifiers.RubberBandXyZoomModifier
                {
                    IsAnimated = true,
                    AnimationDuration = 400,
                    Fill = "#FFFFFF33",
                    Stroke = "red",
                    StrokeThickness = 1,
                    XyDirection = XyDirection.XyDirection
                },
                new SciChartBlazor.Modifiers.ZoomExtentsModifier
                {
                    IsAnimated = true,
                    AnimationDuration = 400
                },
                new MouseWheelZoomModifier(),
                new ZoomPanModifier() { ExecuteOn = ExecuteOn.MouseMiddleButton }
            };

            await _chartBuilder.AddModifiers(modifiers);
```
* Creating Axis
```C#
            var XAxis = new NumericAxis()
            {
                AxisTitle = "X",
                GrowBy = new SciChartNumberRange(0.05, 0.05),
                AxisTitleStyle = new Styles.AxisTitleStyle()
                {
                    FontSize = 24,
                    Color = "black",
                },
                MajorGridLineStyle = new Styles.MajorGridLineStyle()
                {
                    StrokeThickness = 0
                },
                MinorGridLineStyle = new Styles.MinorGridLineStyle()
                {
                    StrokeThickness = 0
                },
                VisibleRangeLimit = new SciChartNumberRange(0, 1000),
                AxisBorder = new Styles.AxisBorder() { BorderTop = 2}

            };
            var YAxis = new NumericAxis()
            {
                AxisTitle = "Y",
                AxisTitleStyle = new Styles.AxisTitleStyle()
                {
                    FontSize = 24,
                    Color = "black",
                },
                AxisAlignment = AxisAlignment.Left,
                AutoRange = AutoRange.Always,
                LabelFormat = NumericFormat.Decimal,
                MajorGridLineStyle = new Styles.MajorGridLineStyle()
                {
                    StrokeThickness = 0
                },
                MinorGridLineStyle = new Styles.MinorGridLineStyle()
                {
                    StrokeThickness = 0
                },
                AxisBorder = new Styles.AxisBorder() { BorderRight = 2 }
            };

            //currently have to do seperately
            await _chartBuilder.AddAxis(XAxis, AxisType.X);
            await _chartBuilder.AddAxis(YAxis, AxisType.Y);
```
* Adding a series:
```C#
            double[] x = new double[1000];
            double[] y = new double[1000];

            for (int i = 0; i < 1000; i++)
            {
                x[i] = (double)i;
                y[i] = Math.Sin(i * 0.2) * 100;
            }

            XyDataSeries<double, double> dataSeries = new(x, y) { DataSeriesName = "Data", ContainsNaN = false, DataIsSortedInX = true };
            FastLineRenderableSeries<double, double> series = new(dataSeries)
            {
                Stroke = "black",
                StrokeThickness = 1
            };

            await _chartBuilder.AddSeries(series);
```
## Thank you!
A special thank you to Matt Roby (@mtroby) & Ryan Fellers @rfellers who are major contributors to this project.
