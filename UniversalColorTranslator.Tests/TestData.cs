using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniversalColorTranslator.API.Model;

namespace UniversalColorTranslator.Tests
{
    [ExcludeFromCodeCoverage]
    public class TestData
    {
        public static List<Colors> GetColors()
        {
            List<Colors> colors = new List<Colors>()
            {
                new Colors
                {
                    ColorId = 1,
                    ColorName = "Red",
                    HexValue = "#FF0000"
                },
                new Colors
                {
                    ColorId = 1,
                    ColorName = "Blue",
                    HexValue = "#000FFF"
                },
                new Colors
                {
                    ColorId = 1,
                    ColorName = "Green",
                    HexValue = "#008000"
                },
            };

            return colors;
        }
    }
}
