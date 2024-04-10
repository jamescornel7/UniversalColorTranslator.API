using System;
using System.Collections.Generic;

namespace UniversalColorTranslator.API.Model
{
    public partial class Colors
    {
        public int ColorId { get; set; }
        public string? ColorName { get; set; }
        public string? HexValue { get; set; }
    }
}
