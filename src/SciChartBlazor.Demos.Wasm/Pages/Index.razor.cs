using Microsoft.AspNetCore.Components;
using System.Reflection;
using MudBlazor;

namespace SciChartBlazor.Demos.Wasm.Pages
{
    public partial class Index : ComponentBase
    {
        Type selectedType = default!;
        Type[] availableComponentTypes = new Type[0];
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            availableComponentTypes = getChartComponenTypes().ToArray();
        }

        IEnumerable<Type> getChartComponenTypes()
        {
            foreach (var type in typeof(Program).Assembly.GetTypes().OrderBy(x => x.Name))
            {
                if (!type.Name.Contains("ChartExample"))
                    continue;
                if (type.Name.StartsWith("<"))
                    continue;
                if (!type.GetInterfaces().Contains(typeof(IComponent)))
                    continue;
                yield return type;
            }

            var assembly = Assembly.GetAssembly(typeof(SciChartBlazor.Shared.ChartDemos.LineRenderableSeriesChartExample));
            foreach (var type in assembly.GetTypes().OrderBy(x => x.Name))
            {
                if (!type.Name.Contains("ChartExample"))
                    continue;
                if (type.Name.StartsWith("<"))
                    continue;
                if (!type.GetInterfaces().Contains(typeof(IComponent)))
                    continue;
                yield return type;
            }
        }

        private string? getNiceName(Type type)
        {
            if (type == null)
                return "";
            try
            {
                var field = type.GetField("__niceName__", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
                return (string?)field?.GetValue(null);
            }
            catch (Exception)
            {
                return type.Name;
            }
        }


        private string? getDescription(Type type)
        {
            if (type == null)
                return "";
            try
            {
                var field = type.GetField("__description__", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
                return (string?)field?.GetValue(null);
            }
            catch (Exception)
            {
                return "string __description__ = \"...\" not found in this component.";
            }
        }

        bool _drawerOpen = true;
        RenderFragment TestComponent() => builder =>
        {
            builder.OpenComponent(0, selectedType);
            //builder.AddAttribute(1, "Title", "Some title");
            builder.CloseComponent();
        };
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
    }
}