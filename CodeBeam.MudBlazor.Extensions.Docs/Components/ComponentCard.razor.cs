﻿using Microsoft.AspNetCore.Components;
using MudExtensions.Docs.Services;

namespace MudExtensions.Docs.Components
{
    public partial class ComponentCard
    {
        [Inject] NavigationManager? NavigationManager { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? ComponentName { get; set; }

        [Parameter]
        public string? Description { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public EventCallback OnClick { get; set; }

        [Parameter]
        public MudExtensionComponentInfo? Component { get; set; }

        [Parameter]
        public bool NavigateToComponentPage { get; set; } = true;

        private void NavigateComponentPage()
        {
            if (!NavigateToComponentPage)
            {
                return;
            }
            string? properName = ComponentName?.Replace(" ", null);
            NavigationManager?.NavigateTo($"/{(string.IsNullOrEmpty(properName) ? Title?.ToLowerInvariant() : properName.ToLowerInvariant())}");
        }
    }
}
