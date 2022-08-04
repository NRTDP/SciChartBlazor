using Microsoft.JSInterop;

namespace SciChartBlazor;

/// <summary>
/// A custonEventHelper. Used for listening to events in JS.
/// </summary>
/// <typeparam name="T"></typeparam>
public class CustomEventHelper<T>
{
    private readonly Func<T, Task> _callback;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomEventHelper{T}"/> class.
    /// </summary>
    /// <param name="callback">The callback.</param>
    public CustomEventHelper(Func<T, Task> callback)
    {
        _callback = callback;
    }

    /// <summary>
    /// Called when [custom event].
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns></returns>
    [JSInvokable]
    public Task OnCustomEvent(T args) => _callback(args);
}

/// <summary>
/// A custom event interop class. Used for listening to events in JS.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="System.IDisposable" />
public class CustomEventInterop<T> : IDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private DotNetObjectReference<CustomEventHelper<T>> Reference = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomEventInterop{T}"/> class.
    /// </summary>
    /// <param name="jsRuntime">The js runtime.</param>
    public CustomEventInterop(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Setups the custom event callback.
    /// </summary>
    /// <param name="eventName">Name of the event.</param>
    /// <param name="callback">The callback.</param>
    /// <returns></returns>
    public ValueTask<string> SetupCustomEventCallback(string eventName, Func<T, Task> callback)
    {
        Reference = DotNetObjectReference.Create(new CustomEventHelper<T>(callback));
        return _jsRuntime.InvokeAsync<string>("sciChartBlazorJson.addCustomEventListener", Reference, eventName);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose() => Reference?.Dispose();
}