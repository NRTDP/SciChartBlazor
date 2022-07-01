using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SciChartBlazor;

public class CustomEventHelper<T>
{
    private readonly Func<T, Task> _callback;

    public CustomEventHelper(Func<T, Task> callback)
    {
        _callback = callback;
    }

    [JSInvokable]
    public Task OnCustomEvent(T args) => 
        _callback(args) ;
}

public class CustomEventInterop<T> : IDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private DotNetObjectReference<CustomEventHelper<T>> Reference = default!;

    public CustomEventInterop(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public ValueTask<string> SetupCustomEventCallback(string eventName, Func<T, Task> callback)
    {
        Reference = DotNetObjectReference.Create(new CustomEventHelper<T>(callback));
        return _jsRuntime.InvokeAsync<string>("sciChartBlazorJson.addCustomEventListener", Reference,eventName);
    }

    public void Dispose()
    {
        Reference?.Dispose();
    }
}






