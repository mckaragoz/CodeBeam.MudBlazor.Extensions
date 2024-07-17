using Microsoft.AspNetCore.Components;
using MudExtensions.Docs.Services;
using MudExtensions.Docs.Shared;

namespace MudExtensions.Docs.Pages
{
    public partial class Index
    {
        [CascadingParameter]
        MainLayout? MainLayout { get; set; }

        List<MudExtensionComponentInfo> _components = new();
        MudAnimate _animate = new();

        bool _hover = false;
        string? _searchString;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _components = DocsService.GetAllComponentInfo();
        }

        private bool NothingFound()
        {
            if (_components.Select(x => x.Title).ToList().Any(x => x.Contains(_searchString ?? "", StringComparison.CurrentCultureIgnoreCase)))
            {
                return false;
            }

            return true;
        }

        private string Version
        {
            get
            {
                var v = typeof(MudAnimate).Assembly.GetName().Version;
                return $"v {v?.Major}.{v?.Minor}.{v?.Build}";
            }
        }
    }
}
