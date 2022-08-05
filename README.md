# SciChartBlazor
A Blazor wrapper for SciChart JS


> **Licensing and Trials** 
> SciChart requires a license or a trial. You can obtain a license here: 
> * **[Licensing SciChart.js](https://www.scichart.com/licensing-scichart-js/)**

### Using SciChartBlazor
> 
First either install the Nuget Package **[https://www.nuget.org/packages/SciChartBlazor/]** (currently in alpha), or pull down the repository and reference the SciChartBlazor project directly. 


For Wasm & serverside you need to register the ScichartBlazor Service (and add a license) in Project.cs, using the following code:
```c#
builder.Services.AddSciChart(options =>
{
    options.RuntimeLicenseKey = "LICENSE_HERE";
});
```html
Then add a reference to the sciChartBlazorJson.js file in either index.html (for Wasm) or _Layout.cshtml (server side):
```
<script async src="_content/SciChartBlazor/SciChart/sciChartBlazorJson.js"></script>
 ```




### Licensing the application 
