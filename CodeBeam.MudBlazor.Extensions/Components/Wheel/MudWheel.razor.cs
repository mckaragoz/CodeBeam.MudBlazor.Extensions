﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MudBlazor.Extensions;
using MudBlazor.Utilities;

namespace MudExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class MudWheel<T> : MudBaseInput<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [Inject] public IScrollManager ScrollManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected string? Classname => new CssBuilder("mud-width-full")
            .AddClass(Class)
            .Build();

        /// <summary>
        /// 
        /// </summary>
        protected string? InnerClassname => new CssBuilder("mud-wheel d-flex flex-column align-center justify-center relative")
            .AddClass("mud-disabled", Disabled)
            .AddClass(InnerClass)
            .Build();

        /// <summary>
        /// 
        /// </summary>
        protected string? MiddleItemClassname => new CssBuilder("middle-item d-flex align-center justify-center mud-width-full")
            .AddClass("mud-disabled", Disabled)
            .Build();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected string? OuterItemClassname(int index) => new CssBuilder($"mud-wheel-item mud-wheel-ani-{_animateGuid}")
            .AddClass("wheel-item-closest", Math.Abs(ItemCollection.IndexOf(Value) - index) == 1)
            .AddClass("my-1", !Dense)
            .AddClass("mud-disabled", Disabled)
            .Build();

        /// <summary>
        /// 
        /// </summary>
        protected string? BorderClassname => new CssBuilder("mud-wheel-border mud-wheel-item mud-width-full")
            .AddClass($"mud-wheel-border-{Color.ToDescriptionString()}")
            .AddClass($"wheel-border-gradient-{Color.ToDescriptionString()}", SmoothBorders)
            .AddClass("my-1", !Dense)
            .Build();

        /// <summary>
        /// 
        /// </summary>
        protected string? EmptyItemClassname => new CssBuilder("mud-wheel-ani-{_animateGuid} mud-wheel-item wheel-item-empty")
            .AddClass("my-1", !Dense)
            .AddClass("wheel-item-empty-dense", Dense)
            .Build();

        MudAnimate _animate = new();
        Guid _animateGuid = Guid.NewGuid();
        int _animateValue = 52;

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public List<T?>? ItemCollection { get; set; }

        /// <summary>
        /// Determines how many items will show before and after the middle one.
        /// </summary>
        [Parameter]
        public int WheelLevel { get; set; } = 2;

        /// <summary>
        /// The minimum swipe delta to change wheel value on touch devices. Default is 40.
        /// </summary>
        [Parameter]
        public int Sensitivity { get; set; } = 40;

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public string? InnerClass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public bool Dense { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public bool SmoothBorders { get; set; }

        /// <summary>
        /// Color for middle item and borders
        /// </summary>
        [Parameter]
        public Color Color { get; set; }

        private Func<T?, string?>? _toStringFunc = x => x?.ToString();
        /// <summary>
        /// Defines how values are displayed in the drop-down list
        /// </summary>
        [Parameter]
        [Category(CategoryTypes.FormComponent.ListBehavior)]
        public Func<T?, string?>? ToStringFunc
        {
            get => _toStringFunc;
            set
            {
                if (_toStringFunc == value)
                    return;
                _toStringFunc = value;
                Converter = new Converter<T>
                {
                    SetFunc = _toStringFunc ?? (x => x?.ToString()),
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string? GetStylename()
        {
            return new StyleBuilder()
            .AddStyle("height", $"{(WheelLevel * (Dense ? 24 : 40) * 2) + (Dense ? 32 : 46)}px")
            .AddStyle(Style)
            .Build();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task HandleOnWheel(WheelEventArgs args)
        {
            if (Disabled || ReadOnly)
            {
                return;
            }
            if (ItemCollection == null)
            {
                return;
            }
            int index = GetIndex();
            if ((args.DeltaY < 0 && index == 0) || (0 < args.DeltaY && index == ItemCollection.Count - 1))
            {
                return;
            }

            if (0 < args.DeltaY)
            {
                _animateValue = GetAnimateValue();
            }
            else
            {
                _animateValue = - GetAnimateValue();
            }
            await _animate.Refresh();
            if (args.DeltaY < 0 && index != 0)
            {
                T? val = ItemCollection[index - 1];
                await SetValueAsync(val);
            }
            else if (0 < args.DeltaY && index != ItemCollection.Count - 1)
            {
                T? val = ItemCollection[index + 1];
                await SetValueAsync(val);
            }
            await Task.Delay(300);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected async Task HandleOnSwipe(SwipeEventArgs args)
        {
            if (Disabled || ReadOnly)
            {
                return;
            }

            if (ItemCollection == null)
            {
                return;
            }
            int index = GetIndex();
            if ((args.SwipeDirection == SwipeDirection.TopToBottom && index == 0) || (args.SwipeDirection == SwipeDirection.BottomToTop && index == ItemCollection.Count - 1))
            {
                return;
            }
            if (args.SwipeDirection == SwipeDirection.BottomToTop)
            {
                _animateValue = GetAnimateValue();
            }
            else
            {
                _animateValue = - GetAnimateValue();
            }

            int changedCount = (Math.Abs((int)(args.SwipeDelta ?? 0)) / (Sensitivity == 0 ? 1 : Sensitivity));
            for (int i = 0; i < changedCount; i++)
            {
                await _animate.Refresh();
                StateHasChanged();
                if (args.SwipeDirection == SwipeDirection.TopToBottom)
                {
                    if (index - 1 < 0)
                    {
                        break;
                    }
                    T? val = ItemCollection[index - 1];
                    index--;
                    await SetValueAsync(val);
                    StateHasChanged();
                }
                else if (args.SwipeDirection == SwipeDirection.BottomToTop)
                {
                    if (ItemCollection.Count <= index + 1)
                    {
                        break;
                    }
                    T? val = ItemCollection[index + 1];
                    index++;
                    await SetValueAsync(val);
                    StateHasChanged();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changeCount"></param>
        /// <returns></returns>
        public async Task ChangeWheel(int changeCount)
        {
            if (Disabled || ReadOnly)
            {
                return;
            }
            int index = GetIndex();
            if (0 < changeCount)
            {
                _animateValue = GetAnimateValue();
            }
            else
            {
                _animateValue = - GetAnimateValue();
            }
            await _animate.Refresh();
            T val = ItemCollection[index + changeCount];
            await SetValueAsync(val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task RefreshAnimate()
        {
            await _animate.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected int GetIndex() => ItemCollection.IndexOf(Value) == -1 ? 0 : ItemCollection.IndexOf(Value);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected int GetAnimateValue() => Dense ? 24 : 42;
    }
}
