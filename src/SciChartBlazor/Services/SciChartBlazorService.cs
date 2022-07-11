using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciChartBlazor.Services
{
    /// <summary>
    /// An interface for the ScichartBlazorService.
    /// </summary>
    public interface ISciChartBlazorService
    {
        /// <summary>
        /// Sets the SciChart license key.
        /// </summary>
        /// <returns></returns>
        public Task SetRuntimeLicenseKey();
    }

    /// <summary>
    /// A Blazor service for SciChart. Currently handles license key registration.
    /// </summary>
    public class SciChartBlazorService: ISciChartBlazorService, IDisposable
    {
        private readonly IJSRuntime _jsRuntime;
        private SciChartOptions _options;
        private readonly DotNetObjectReference<SciChartBlazorService> _dotNetRef;

        /// <summary>
        /// A Blazor service for SciChart. Currently handles license key registration.
        /// </summary>
        /// <param name="jsRuntime">The JS runtime.</param>
        /// <param name="options">The options for SciChartBlazor service. Currently just the license key.</param>
        public SciChartBlazorService(IJSRuntime jsRuntime, SciChartOptions options)
        {
            _dotNetRef = DotNetObjectReference.Create(this);
            _jsRuntime = jsRuntime;
            _options = options;
        }
        /// <summary>
        /// A Blazor service for SciChart. Currently handles license key registration.
        /// </summary>
        /// <param name="jsRuntime">The JS runtime.</param>
        /// <param name="options">The options for SciChartBlazor service. Currently just the license key.</param>
        public SciChartBlazorService(IJSRuntime jsRuntime, IOptions<SciChartOptions> options) : this(jsRuntime, options.Value) { }
        
        /// <summary>
        /// Disposes the service.
        /// </summary>
        public void Dispose() => _dotNetRef.Dispose();

        /// <summary>
        /// Sets the SciChart license key.
        /// </summary>
        /// <returns></returns>
        public async Task SetRuntimeLicenseKey() => await _jsRuntime.InvokeVoidAsync("sciChartBlazorJson.setLicenseKey", _options.RuntimeLicenseKey);
    }
    /// <summary>
    /// Options for the SciChartBlazor service.
    /// </summary>
    public class SciChartOptions
    {
        /// <summary>
        /// The SciChart JS license key. 
        /// </summary>
        public string? RuntimeLicenseKey { get; set; }
    }
}
