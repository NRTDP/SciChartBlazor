using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SciChartBlazor.Services;

namespace SciChartBlazor.Demos.ChartDemos
{
    public partial class TestChartExample : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        public static string __description__ = "An example using the LineRenderable series";
        /// <summary>
        /// 
        /// </summary>
        public static string __niceName__ = "LineRenderable Series";


        private string Id { get; set; } = "C" + Guid.NewGuid().ToString();

        private protected ElementReference _chart;

        SciChartBuilder _chartBuilder = default!;


        [Inject] IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] ISciChartBlazorService sciChartBlazorService { get; set; } = default!;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //Create the chart

                _chartBuilder = new SciChartBuilder(_chart, JSRuntime, sciChartBlazorService);

                string json = await _chartBuilder.Test();
            }

            await base.OnAfterRenderAsync(firstRender);

        }


    }
}