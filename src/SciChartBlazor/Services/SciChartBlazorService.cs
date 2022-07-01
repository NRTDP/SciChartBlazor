using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Services
{

    public interface ISciChartBlazorService
    {
        public Task SetRuntimeLicenseKey();
    }
    public class SciChartBlazorService: ISciChartBlazorService, IDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private SciChartOptions _options;
        private readonly DotNetObjectReference<SciChartBlazorService> _dotNetRef;

        public SciChartBlazorService(IJSRuntime jsRuntime, SciChartOptions options)
        {
            _dotNetRef = DotNetObjectReference.Create(this);
            _jsRuntime = jsRuntime;
            _options = options;
        }

        public SciChartBlazorService(IJSRuntime jsRuntime, IOptions<SciChartOptions> options) : this(jsRuntime, options.Value) { }

        public void Dispose() => _dotNetRef.Dispose();
        
        public async Task SetRuntimeLicenseKey() => await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.setLincenseKey", _options.RuntimeLicenseKey);
    }

    public class SciChartOptions
    {
        public string? RuntimeLicenseKey { get; set; }
    }
}
