using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace SortsVisualisation.Models
{
    public static class ColorPalette
    {
        public static Color LightCoral => GetSolidColorBrush("#F07F83");
        public static Color QueenBlue => GetSolidColorBrush("#456990");
        public static Color Keppel => GetSolidColorBrush("#49BEAA");
        public static Color MediumAquamarine => GetSolidColorBrush("#49DCB1");
        public static Color Sunray => GetSolidColorBrush("#EEB868");


        private static Color GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            //byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));

            return Color.FromArgb(255, r, g, b);
        }

    }
}
