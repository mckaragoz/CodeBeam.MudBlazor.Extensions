using MudExtensions.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudExtensions.Docs.Services
{
    public class MudExtensionsDocsService
    {
        List<MudExtensionComponentInfo> _components = new()
        {
            new MudExtensionComponentInfo() {Title = "MudAnimate", Component = typeof(MudAnimate), IsUnique = true, Description = "A revolutionary next generation animate component."},
            new MudExtensionComponentInfo() {Title = "MudBarcode", Component = typeof(MudBarcode), IsUnique = true, Description = "A QR and barcode viewer with defined value."},
            new MudExtensionComponentInfo() {Title = "MudChipField", Component = typeof(MudChipField<string>), IsUnique = true, Description = "A textfield which transform a text to a chip when pressed pre-defined key."},
            new MudExtensionComponentInfo() {Title = "MudCodeInput", Component = typeof(MudCodeInput<string>), IsUnique = true, Description = "A group of textfields that each one contains a char."},
            new MudExtensionComponentInfo() {Title = "MudColorProvider", Component = typeof(MudColorProvider), IsUnique = true, Description = "An extension for primary, secondary and tertiary colors to support Material 3.", IsMaterial3 = true},
            new MudExtensionComponentInfo() {Title = "MudComboBox", Component = typeof(MudComboBox<string>), RelatedComponents = new List<Type>() {typeof(MudComboBoxItem<string>)}, IsUnique = true, Description = "Unites MudSelect and MudAutocomplete features."},
            new MudExtensionComponentInfo() {Title = "MudCssManager", Component = typeof(MudCssManager), IsUnique = true, IsUtility = true, Description = "Directly and dynamically get or set component's css property."},
            new MudExtensionComponentInfo() {Title = "MudCsvMapper", Component = typeof(MudCsvMapper), IsUnique = true, Description = "A .csv file uploader that matches the .csv file headers to supplied / expected headers."},
            new MudExtensionComponentInfo() {Title = "MudDateWheelPicker", Component = typeof(MudDateWheelPicker), IsUnique = true, Description = "A date time picker with MudWheels."},
            new MudExtensionComponentInfo() {Title = "MudGallery", Component = typeof(MudGallery), IsUnique = true, Description = "Mobile friendly image gallery component."},
            new MudExtensionComponentInfo() {Title = "MudInputStyler", Component = typeof(MudInputStyler), IsUnique = true, Description = "Applies colors or other CSS styles easily for mud inputs like MudTextField and MudSelect."},
            new MudExtensionComponentInfo() {Title = "MudListExtended", Component = typeof(MudListExtended<string>), RelatedComponents = new List<Type>() {typeof(MudListItemExtended<string>)}, IsUnique = false, Description = "The extended MudList component with richer features."},
            new MudExtensionComponentInfo() {Title = "MudLoading", Component = typeof(MudLoading), IsUnique = true, Description = "Loading container for a whole page or a specific section."},
            new MudExtensionComponentInfo() {Title = "MudLoadingButton", Component = typeof(MudLoadingButton), IsUnique = true, Description = "A classic MudButton with loading improvements."},
            new MudExtensionComponentInfo() {Title = "MudPage", Component = typeof(MudPage), RelatedComponents = new List<Type>() {typeof(MudSection)}, IsUnique = true, Description = "A CSS grid layout component that builds columns and rows, supports ColSpan & RowSpan."},
            new MudExtensionComponentInfo() {Title = "MudPasswordField", Component = typeof(MudPasswordField<string>), IsUnique = true, Description = "A specialized textfield that designed for working easily with passwords."},
            new MudExtensionComponentInfo() {Title = "MudPopup", Component = typeof(MudPopup), IsUnique = true, Description = "A mobile friendly multi-functional popup content."},
            new MudExtensionComponentInfo() {Title = "MudRangeSlider", Component = typeof(MudRangeSlider<int>), IsUnique = true, Description = "A slider with range capabilities, set upper and lower values."},
            new MudExtensionComponentInfo() {Title = "MudScrollbar", Component = typeof(MudScrollbar), IsUnique = true, Description = "Customize all or defined scrollbars."},
            new MudExtensionComponentInfo() {Title = "MudSelectExtended", Component = typeof(MudSelectExtended<string>), RelatedComponents = new List<Type>() {typeof(MudSelectItemExtended<string>)}, IsUnique = false, Description = "The extended MudSelect component with richer features."},
            new MudExtensionComponentInfo() {Title = "MudSignaturePad", Component = typeof(MudSignaturePad), IsUnique = true, Description = "Draw and export a signature on a canvas."},
            new MudExtensionComponentInfo() {Title = "MudSpeedDial", Component = typeof(MudSpeedDial), IsUnique = true, Description = "A resizeable content splitter."},
            new MudExtensionComponentInfo() {Title = "MudSplitter", Component = typeof(MudSplitter), IsUnique = true, Description = "A slider with range capabilities, set upper and lower values."},
            new MudExtensionComponentInfo() {Title = "MudStepperExtended", Component = typeof(MudStepperExtended), RelatedComponents = new List<Type>() {typeof(MudStepExtended)}, IsUnique = false, Description = "A wizard-like steps to control the flow with rich options."},
            new MudExtensionComponentInfo() {Title = "MudSwitchM3", Component = typeof(MudSwitchM3<bool>), IsUnique = true, IsMaterial3 = true, Description = "Material 3 switch component that has all MudBlazor features."},
            new MudExtensionComponentInfo() {Title = "MudTeleport", Component = typeof(MudTeleport), IsUnique = true, Description = "Teleport the content to the specified parent and redesign the DOM hierarchy."},
            new MudExtensionComponentInfo() {Title = "MudTextFieldExtended", Component = typeof(MudTextFieldExtended<string>), IsUnique = false, Description = "The extended MudTextField component with richer features."},
            new MudExtensionComponentInfo() {Title = "MudTextM3", Component = typeof(MudTextM3), IsUnique = true, IsMaterial3 = true, Description = "Material 3 typography."},
            new MudExtensionComponentInfo() {Title = "MudTransferList", Component = typeof(MudTransferList<string>), IsUnique = true, Description = "A component that has 2 lists that transfer items to another."},
            new MudExtensionComponentInfo() {Title = "MudWatch", Component = typeof(MudWatch), IsUnique = true, Description = "A performance optimized watch to show current time or show stopwatch or countdown."},
            new MudExtensionComponentInfo() {Title = "MudWheel", Component = typeof(MudWheel<string>), IsUnique = true, Description = "Smoothly changes values in a wheel within defined ItemCollection."},
        };

        public List<MudExtensionComponentInfo> GetAllComponentInfo()
        {
            return _components;
        }
    }
}
