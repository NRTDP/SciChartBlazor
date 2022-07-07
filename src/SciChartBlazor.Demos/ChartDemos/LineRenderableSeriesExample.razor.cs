using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SciChartBlazor.Axes;
using SciChartBlazor.DataSeries;
using SciChartBlazor.Modifiers;
using SciChartBlazor.RenderableSeries;
using SciChartBlazor.Services;

namespace SciChartBlazor.Demos.ChartDemos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LineRenderableSeriesChartExample : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        private static string __description__ = "An example using the LineRenderable series";

        /// <summary>
        /// 
        /// </summary>
        private static string __niceName__ = "LineRenderable Series";


        private string Id { get; set; } = "C" + Guid.NewGuid().ToString();

        private protected ElementReference _chart;

        SciChartBuilder _chartBuilder = default!;


        [Inject]  IJSRuntime JSRuntime { get; set; } = default!;
        [Inject]  ISciChartBlazorService sciChartBlazorService { get; set; } = default!;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _chartBuilder = new SciChartBuilder(_chart, JSRuntime, sciChartBlazorService);
                await _chartBuilder.CreateChart();
                await AddModifiers();
                await CreateAxis();
                await LoadData();


            }

            await base.OnAfterRenderAsync(firstRender);
   
        }
        private async Task LoadData()
        {
            double[] x = new double[1000];
            double[] y = new double[1000];

            for (int i =0; i < 1000; i++)
            {
                x[i] = (double)i;
                y[i] = Math.Sin(i * 0.2);
            }

            XyDataSeries<double, double> dataSeries = new(x, y) { DataSeriesName = "Data", ContainsNaN = false, DataIsSortedInX = true };
            FastLineRenderableSeries<double, double> series = new(dataSeries)
            {
                Stroke = "black",
                StrokeThickness = 3,
            };

            await _chartBuilder.AddSeries(series);
        }

        private async Task AddModifiers()
        {
            List<ModifierBase> modifiers = new()
            {
                new SciChartBlazor.Modifiers.RubberBandXyZoomModifier
                {
                    IsAnimated = true,
                    AnimationDuration = 400,
                    Fill = "#FFFFFF33",
                    Stroke = "#4E2A84",
                    StrokeThickness = 1,
                    XyDirection = XyDirection.XDirection
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
        }

        private async Task CreateAxis()
        {
            var XAxis = new NumericAxis()
            {
                AxisTitle = "X",
                GrowBy = new SciChartNumberRange(0.05, 0.05)
            };
            var YAxis = new NumericAxis()
            {
                AxisTitle = "Y",
                AxisAlignment = AxisAlignment.Left,
                AutoRange = AutoRange.Always,
            };

            await _chartBuilder.AddAxis(XAxis, AxisType.X);
            await _chartBuilder.AddAxis(YAxis, AxisType.Y);
        }


    }
}