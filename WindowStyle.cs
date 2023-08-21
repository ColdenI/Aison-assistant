using System.Drawing;

namespace WindowStyle
{
    public enum WindowTheme
    {
        Light = 0,
        Dark = 1,
        Blue = 2,
        Green,
        Red
    }
    public static class WindowColors
    {
        public static Color BG_Light = Color.White;
        public static Color FG_Light = Color.Black;

        public static Color BG_Dark = Color.FromArgb(32, 32, 32);
        public static Color FG_Dark = Color.White;

        public static Color BG_Blue = Color.FromArgb(150, 224, 255);
        public static Color FG_Blue = Color.Black;

        public static Color BG_Green = Color.FromArgb(150, 255, 168);
        public static Color FG_Green = Color.Black;

        public static Color BG_Red = Color.FromArgb(255, 186, 186);
        public static Color FG_Red = Color.Black;
    }
}
