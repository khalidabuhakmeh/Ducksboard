using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Ducksboard.TypeExtensions
{
    /// <summary>
    /// Although color is marked as serializable, it doesn't serialize anything.. 
    /// these helpers are here to work with colors as the ducksboard api sees them.
    /// </summary>
    public static class ColorExtensions
    {
        public static string ToDucksboardColor(this Color color)
        {
            return String.Format("rgba({0},{1},{2},{3})",
                color.R,
                color.G, 
                color.B, 
                (color.A/255).ToString("0.00", CultureInfo.InvariantCulture));
        }
    }
}
