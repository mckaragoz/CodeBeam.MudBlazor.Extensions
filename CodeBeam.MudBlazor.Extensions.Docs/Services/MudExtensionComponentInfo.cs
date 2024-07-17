using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudExtensions.Docs.Services
{
    public class MudExtensionComponentInfo
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsUnique { get; set; }
        public bool IsMaterial3 { get; set; }
        public bool IsUtility { get; set; }
    }
}
