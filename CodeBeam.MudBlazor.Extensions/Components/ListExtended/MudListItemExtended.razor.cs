﻿using System.Windows.Input;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Extensions;
using MudBlazor.Utilities;
using MudBlazor;

namespace MudExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class MudListItemExtended<T> : MudComponentBase, IDisposable
    {

        #region Parameters, Fields, Injected Services

        /// <summary>
        /// 
        /// </summary>
        [Inject] protected NavigationManager? NavigationManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [CascadingParameter] protected MudListExtended<T?>? MudListExtended { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [CascadingParameter] protected internal MudListItemExtended<T?>? ParentListItem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected string? Classname =>
        new CssBuilder("mud-list-item-extended")
          .AddClass("mud-list-item-dense-extended", Dense == true || MudListExtended?.Dense == true)
          .AddClass("mud-list-item-gutters-extended", Gutters && (MudListExtended?.Gutters == true))
          .AddClass("mud-list-item-clickable-extended", MudListExtended?.Clickable)
          .AddClass("mud-ripple", MudListExtended?.Clickable == true && Ripple && !GetDisabledStatus() && !IsFunctional)
          .AddClass($"mud-selected-item mud-{MudListExtended?.Color.ToDescriptionString()}-text mud-{MudListExtended?.Color.ToDescriptionString()}-hover", _selected && !GetDisabledStatus() && NestedList == null && MudListExtended?.EnableSelectedItemStyle == true)
          .AddClass("mud-list-item-hilight-extended", _active && !GetDisabledStatus() && NestedList == null && !IsFunctional)
          .AddClass("mud-list-item-disabled-extended", GetDisabledStatus())
          .AddClass("mud-list-item-nested-background-extended", MudListExtended != null && MudListExtended.SecondaryBackgroundForNestedItemHeader && NestedList != null)
          .AddClass("mud-list-item-functional", IsFunctional)
          .AddClass(Class)
        .Build();

        /// <summary>
        /// 
        /// </summary>
        protected string? MultiSelectClassName =>
        new CssBuilder()
            .AddClass("mud-list-item-multiselect-extended")
            .AddClass("mud-list-item-multiselect-checkbox-extended", MudListExtended?.MultiSelectionComponent == MultiSelectionComponent.CheckBox || OverrideMultiSelectionComponent == MultiSelectionComponent.CheckBox)
            .Build();

        /// <summary>
        /// 
        /// </summary>
        protected internal string? ItemId { get; } = "listitem_" + Guid.NewGuid().ToString().Substring(0, 8);

        /// <summary>
        /// Functional items does not hold values. If a value set on Functional item, it ignores by the MudList. They can not count on Items list (they count on AllItems), cannot be subject of keyboard navigation and selection.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public bool IsFunctional { get; set; }

        /// <summary>
        /// The text to display
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public string? Text { get; set; }

        /// <summary>
        /// The secondary text to display
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public string? SecondaryText { get; set; }

        /// <summary>
        /// Value of the item.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Selecting)]
        public T? Value { get; set; }

        /// <summary>
        /// Avatar to use if set.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public string? Avatar { get; set; }

        /// <summary>
        /// Avatar CSS Class to apply if Avatar is set.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Appearance)]
        public string? AvatarClass { get; set; }

        /// <summary>
        /// Link to a URL when clicked.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.ClickAction)]
        public string? Href { get; set; }

        /// <summary>
        /// If true, force browser to redirect outside component router-space.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.ClickAction)]
        public bool ForceLoad { get; set; }

        private bool _disabled;
        /// <summary>
        /// If true, will disable the list item if it has onclick.
        /// The value can be overridden by the parent list.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public bool Disabled
        {
            get => _disabled || (MudListExtended?.Disabled ?? false);
            set => _disabled = value;
        }

        /// <summary>
        /// If true, the left and right padding is removed.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Appearance)]
        public bool Gutters { get; set; } = true;

        /// <summary>
        /// If true, disables ripple effect.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Appearance)]
        public bool Ripple { get; set; } = true;

        /// <summary>
        /// Overrided component for multiselection. Keep it null to have default one that MudList has.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.ClickAction)]
        public MultiSelectionComponent? OverrideMultiSelectionComponent { get; set; } = null;

        /// <summary>
        /// Icon to use if set.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public string? Icon { get; set; }

        /// <summary>
        /// The color of the icon.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Appearance)]
        public Color IconColor { get; set; } = Color.Inherit;

        /// <summary>
        /// Sets the Icon Size.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Appearance)]
        public Size IconSize { get; set; } = Size.Medium;

        /// <summary>
        /// The color of the adornment if used. It supports the theme colors.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Expanding)]
        public Color AdornmentColor { get; set; } = Color.Default;

        /// <summary>
        /// Custom expand less icon.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Expanding)]
        public string ExpandLessIcon { get; set; } = Icons.Material.Filled.ExpandLess;

        /// <summary>
        /// Custom expand more icon.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Expanding)]
        public string ExpandMoreIcon { get; set; } = Icons.Material.Filled.ExpandMore;

        /// <summary>
        /// If true, the List Subheader will be indented.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Appearance)]
        public bool Inset { get; set; }

        /// <summary>
        /// If true, stop propagation on click. Default is true.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Appearance)]
        public bool OnClickStopPropagation { get; set; } = true;

        private bool? _dense;
        /// <summary>
        /// If true, compact vertical padding will be used.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Appearance)]
        public bool? Dense
        {
            get => _dense;
            set
            {
                if (_dense == value)
                {
                    return;
                }
                _dense = value;
                OnListParametersChanged();
            }
        }

        /// <summary>
        /// Prevent default behavior when click on MudSelectItem. Default behavior is selecting the item and style adjustments.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public bool OnClickHandlerPreventDefault { get; set; }

        /// <summary>
        /// Display content of this list item. If set, overrides Text.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// Add child list items here to create a nested list.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Behavior)]
        public RenderFragment? NestedList { get; set; }

        /// <summary>
        /// List click event.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        /// <summary>
        /// If true, expands the nested list on first display.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Expanding)]
        public bool InitiallyExpanded { get; set; }

        private bool _expanded;
        /// <summary>
        /// Expand or collapse nested list. Two-way bindable. Note: if you directly set this to
        /// true or false (instead of using two-way binding) it will force the nested list's expansion state.
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.List.Expanding)]
        public bool Expanded
        {
            get => _expanded;
            set
            {
                if (_expanded == value)
                    return;
                _expanded = value;
                _ = ExpandedChanged.InvokeAsync(value);
            }
        }

        /// <summary>
        /// Called when expanded state change.
        /// </summary>
        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }

        #endregion


        #region Lifecycle Methods (& Dispose)

        /// <summary>
        /// 
        /// </summary>
        protected override void OnInitialized()
        {
            _expanded = InitiallyExpanded;
            if (MudListExtended != null)
            {
                MudListExtended.Register(this);
                OnListParametersChanged();
                MudListExtended.ParametersChanged += OnListParametersChanged;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (MudListExtended == null)
                    return;
                MudListExtended.ParametersChanged -= OnListParametersChanged;
                MudListExtended.Unregister(this);
            }
            catch (Exception) { /*ignore*/ }
        }

        #endregion


        #region Select & Active

        private bool _selected;
        private bool _active;

        /// <summary>
        /// Selected state of the option. Readonly. Use SetSelected for selecting.
        /// </summary>
        public bool IsSelected
        {
            get => _selected;
        }

        internal bool IsActive
        {
            get => _active;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="forceRender"></param>
        /// <param name="returnIfDisabled"></param>
        public void SetSelected(bool selected, bool forceRender = true, bool returnIfDisabled = false)
        {
            if (returnIfDisabled == true && Disabled)
            {
                return;
            }
            if (_selected == selected)
                return;
            _selected = selected;
            if (forceRender)
            {
                StateHasChanged();
            }
        }

        internal void SetActive(bool active, bool forceRender = true)
        {
            if (Disabled)
                return;
            if (_active == active)
                return;
            _active = active;
            if (forceRender)
            {
                StateHasChanged();
            }
        }

        #endregion


        #region Other (ClickHandler etc.)

        /// <summary>
        /// 
        /// </summary>
        public void ForceRender()
        {
            StateHasChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ev"></param>
        protected void OnClickHandler(MouseEventArgs ev)
        {
            if (Disabled)
                return;

            if (OnClickHandlerPreventDefault)
            {
                OnClick.InvokeAsync(ev).CatchAndLog();
                return;
            }

            if (NestedList != null)
            {
                Expanded = !Expanded;
            }
            else if (Href != null)
            {
                MudListExtended?.SetSelectedValue(this);
                OnClick.InvokeAsync(ev).CatchAndLog();
                NavigationManager?.NavigateTo(Href, ForceLoad);
            }
            else if (MudListExtended?.Clickable == true || MudListExtended?.MultiSelection == true)
            {
                MudListExtended?.SetSelectedValue(this);
                OnClick.InvokeAsync(ev).CatchAndLog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ev"></param>
        protected void OnlyOnClick(MouseEventArgs ev)
        {
            OnClick.InvokeAsync(ev).CatchAndLog();
        }

        private Typo _textTypo;
        /// <summary>
        /// 
        /// </summary>
        protected void OnListParametersChanged()
        {
            if ((Dense ?? MudListExtended?.Dense) ?? false)
            {
                _textTypo = Typo.body2;
            }
            else
            {
                _textTypo = Typo.body1;
            }
            StateHasChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected internal bool GetDisabledStatus()
        {
            if (MudListExtended?.ItemDisabledFunc != null)
            {
                return MudListExtended.ItemDisabledFunc(Value);
            }
            return Disabled;
        }

        #endregion

    }
}
