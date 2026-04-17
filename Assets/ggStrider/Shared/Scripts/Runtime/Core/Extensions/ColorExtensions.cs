using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class ColorExtensions
    {
        #region Public API

        #region Red

        public static Color WithRed01(this Color color, float value)
        {
            return ChangeColor(color, Colors.Red, value);
        }

        public static Color WithRed0(this Color color)
        {
            return color.WithRed01(0);
        }

        public static Color WithRed1(this Color color)
        {
            return color.WithRed01(1);
        }

        #endregion

        #region Green

        public static Color WithGreen01(this Color color, float value)
        {
            return ChangeColor(color, Colors.Green, value);
        }

        public static Color WithGreen0(this Color color)
        {
            return color.WithGreen01(0);
        }

        public static Color WithGreen1(this Color color)
        {
            return color.WithGreen01(1);
        }

        #endregion

        #region Blue

        public static Color WithBlue01(this Color color, float value)
        {
            return ChangeColor(color, Colors.Blue, value);
        }

        public static Color WithBlue0(this Color color)
        {
            return color.WithBlue01(0);
        }

        public static Color WithBlue1(this Color color)
        {
            return color.WithBlue01(1);
        }

        #endregion

        #region Alpha

        public static Color WithAlpha01(this Color color, float targetAlpha)
        {
            return ChangeColor(color, Colors.Alpha, targetAlpha);
        }

        public static Color WithAlpha0(this Color color)
        {
            return color.WithAlpha01(0);
        }

        public static Color WithAlpha1(this Color color)
        {
            return color.WithAlpha01(1);
        }

        #endregion

        #endregion

        #region Internal API

        private enum Colors
        {
            Red = 0,
            Green = 1,
            Blue = 2,
            Alpha = 3
        };

        private static Color ChangeColor(Color color, Colors colorToAffect, float newValue01)
        {
            color[(int)colorToAffect] = newValue01;
            return color;
        }

        #endregion
    }
}