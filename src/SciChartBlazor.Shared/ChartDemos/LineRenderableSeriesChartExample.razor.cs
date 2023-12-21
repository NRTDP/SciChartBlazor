using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SciChartBlazor.Axes;
using SciChartBlazor.DataSeries;
using SciChartBlazor.Modifiers;
using SciChartBlazor.RenderableSeries;
using SciChartBlazor.Services;

namespace SciChartBlazor.Shared.ChartDemos
{
    public partial class LineRenderableSeriesChartExample : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        public static string __description__ = "An example using the LineRenderable series";

        /// <summary>
        /// 
        /// </summary>
       public  static string __niceName__ = "LineRenderable Series";


        private string Id { get; set; } = "C" + Guid.NewGuid().ToString();

        private protected ElementReference _chart;

        SciChartBuilder _chartBuilder = default!;

        private CursorModifier _cursorModifier = default!;


        [Inject] IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] ISciChartBlazorService sciChartBlazorService { get; set; } = default!;

        /// <summary>
        /// Initialize the chart OnAfterRenderAsync
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //Create the chart
                _chartBuilder = new SciChartBuilder(_chart, JSRuntime, sciChartBlazorService);
                await _chartBuilder.CreateChart();
                await AddModifiers();
                await CreateAxis();
                await LoadData();
                await LoadAlternativeData();
                await _chartBuilder.SetModifierEnabled(_cursorModifier, false);
            }

            await base.OnAfterRenderAsync(firstRender);

        }
        private async Task LoadData()
        {
            double[] x = new double[1000];
            double[] y = new double[1000];

            for (int i = 0; i < 1000; i++)
            {
                x[i] = (double)i;
                y[i] = Math.Sin(i * 0.2) * 100;
            }

            XyDataSeries<double, double> dataSeries = new(x, y) { DataSeriesName = "Data", ContainsNaN = false, DataIsSortedInX = true }; // using containsNaN = false and DataIsSortedInX speeds up data loading
            FastLineRenderableSeries<double, double> series = new(dataSeries)
            {
                //Stroke = "black",
                StrokeThickness = 1,
                Effect = new Styles.ShaderEffect(ShaderEffectType.Glow)
                {
                //   Range = 0.7,
                    Color = "green",
                   Intensity = 1,
                    Offset = new Point(5, 5)
                 }
            };

            await _chartBuilder.AddSeries(series);
        }
        
        private async Task LoadAlternativeData()
        {
            var x = new double[1000];
            var y = new double[1000];

            for (var i = 0; i < 1000; i++)
            {
                x[i] = i+10;
                y[i] = Math.Sin(i * 0.2) * 100;
            }

            XyDataSeries<double, double> dataSeries = new(x, y) { DataSeriesName = "Alternative Data", ContainsNaN = false, DataIsSortedInX = true };
            FastLineRenderableSeries<double, double> series = new(dataSeries)
            {
                StrokeThickness = 1,
                StrokeDashArray = new double[]{10, 3}
            };

            await _chartBuilder.AddSeries(series);
        }

        private async Task AddModifiers()
        {
            _cursorModifier = new CursorModifier();
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
                new ZoomPanModifier() { ExecuteOn = ExecuteOn.MouseMiddleButton },
                _cursorModifier
            };

            await _chartBuilder.AddModifiers(modifiers);
        }

        private async Task CreateAxis()
        {
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
        }

        private async void ToggleCursorModifier()
        {
           await _chartBuilder.ToggleModifierEnabled(_cursorModifier);
        }


    


}
}