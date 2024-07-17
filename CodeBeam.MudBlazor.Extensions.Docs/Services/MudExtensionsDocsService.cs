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
            new MudExtensionComponentInfo() {Title = "MudAnimate", IsUnique = true, Description = "A revolutionary next generation animate component."},
            new MudExtensionComponentInfo() {Title = "MudBarcode", IsUnique = true, Description = "A QR and barcode viewer with defined value."},
            new MudExtensionComponentInfo() {Title = "MudChipField", IsUnique = true, Description = "A textfield which transform a text to a chip when pressed pre-defined key."},
            new MudExtensionComponentInfo() {Title = "MudCodeInput", IsUnique = true, Description = "A group of textfields that each one contains a char."},
            new MudExtensionComponentInfo() {Title = "MudColorProvider", IsUnique = true, Description = "An extension for primary, secondary and tertiary colors to support Material 3.", IsMaterial3 = true},
            new MudExtensionComponentInfo() {Title = "MudComboBox", IsUnique = true, Description = "Unites MudSelect and MudAutocomplete features."},
            new MudExtensionComponentInfo() {Title = "MudCssManager", IsUnique = true, IsUtility = true, Description = "Directly and dynamically get or set component's css property."},
            new MudExtensionComponentInfo() {Title = "MudCsvMapper", IsUnique = true, Description = "A .csv file uploader that matches the .csv file headers to supplied / expected headers."},
            new MudExtensionComponentInfo() {Title = "MudDateWheelPicker", IsUnique = true, Description = "A date time picker with MudWheels."},
            new MudExtensionComponentInfo() {Title = "MudGallery", IsUnique = true, Description = "Mobile friendly image gallery component."},
            new MudExtensionComponentInfo() {Title = "MudInputStyler", IsUnique = true, Description = "Applies colors or other CSS styles easily for mud inputs like MudTextField and MudSelect."},
            new MudExtensionComponentInfo() {Title = "MudListExtended", IsUnique = false, Description = "The extended MudList component with richer features."},
            new MudExtensionComponentInfo() {Title = "MudLoading", IsUnique = true, Description = "Loading container for a whole page or a specific section."},
            new MudExtensionComponentInfo() {Title = "MudLoadingButton", IsUnique = true, Description = "A classic MudButton with loading improvements."},
            new MudExtensionComponentInfo() {Title = "MudPage", IsUnique = true, Description = "A CSS grid layout component that builds columns and rows, supports ColSpan & RowSpan."},
            new MudExtensionComponentInfo() {Title = "MudPasswordField", IsUnique = true, Description = "A specialized textfield that designed for working easily with passwords."},
            new MudExtensionComponentInfo() {Title = "MudPopup", IsUnique = true, Description = "A mobile friendly multi-functional popup content."},
            new MudExtensionComponentInfo() {Title = "MudRangeSlider", IsUnique = true, Description = "A slider with range capabilities, set upper and lower values."},
            new MudExtensionComponentInfo() {Title = "MudScrollbar", IsUnique = true, Description = "Customize all or defined scrollbars."},
            new MudExtensionComponentInfo() {Title = "MudSelectExtended", IsUnique = false, Description = "The extended MudSelect component with richer features."},
            new MudExtensionComponentInfo() {Title = "MudSignaturePad", IsUnique = true, Description = "Draw and export a signature on a canvas."},
            new MudExtensionComponentInfo() {Title = "MudSpeedDial", IsUnique = true, Description = "A resizeable content splitter."},
            new MudExtensionComponentInfo() {Title = "MudSplitter", IsUnique = true, Description = "A slider with range capabilities, set upper and lower values."},
            new MudExtensionComponentInfo() {Title = "MudStepperExtended", IsUnique = false, Description = "A wizard-like steps to control the flow with rich options."},
            new MudExtensionComponentInfo() {Title = "MudSwitchM3", IsUnique = true, IsMaterial3 = true, Description = "Material 3 switch component that has all MudBlazor features."},
            new MudExtensionComponentInfo() {Title = "MudTeleport", IsUnique = true, Description = "Teleport the content to the specified parent and redesign the DOM hierarchy."},
            new MudExtensionComponentInfo() {Title = "MudTextFieldExtended", IsUnique = false, Description = "The extended MudTextField component with richer features."},
            new MudExtensionComponentInfo() {Title = "MudTextM3", IsUnique = true, IsMaterial3 = true, Description = "Material 3 typography."},
            new MudExtensionComponentInfo() {Title = "MudTransferList", IsUnique = true, Description = "A component that has 2 lists that transfer items to another."},
            new MudExtensionComponentInfo() {Title = "MudWatch", IsUnique = true, Description = "A performance optimized watch to show current time or show stopwatch or countdown."},
            new MudExtensionComponentInfo() {Title = "MudWheel", IsUnique = true, Description = "Smoothly changes values in a wheel within defined ItemCollection."},
        };

        public List<MudExtensionComponentInfo> GetAllComponentInfo()
        {
            return _components;
        }
    }
}
