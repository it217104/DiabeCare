using DiabeCare.Models;
using System.Text.RegularExpressions;

namespace DiabeCare.Utilities
{
    public static class Utility
    {
        public static UserDetail mUserDetail { get; set; }
        
        public static Regex EmailRegex = new(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

        public static bool IsNullOrEmptyOrWhiteSpace(this string txt)
        {
            return string.IsNullOrEmpty(txt) && string.IsNullOrWhiteSpace(txt);
        }

        public static bool IsNotNullOrEmptyOrWhiteSpace(this string txt)
        {
            return !string.IsNullOrEmpty(txt) && !string.IsNullOrWhiteSpace(txt);
        }

        public static async Task BounceButton(Button button)
        {
            await button.ScaleTo(0.75, 100);
            await button.ScaleTo(1, 100);
        }

        public static async Task BounceBorder(Border border)
        {
            await border.ScaleTo(0.75, 100);
            await border.ScaleTo(1, 100);
        }

        public static async Task BounceImage(Image image)
        {
            await image.ScaleTo(0.75, 100);
            await image.ScaleTo(1, 100);
        }

        public static async Task BounceHorizontalSL(HorizontalStackLayout hsl)
        {
            await hsl.ScaleTo(0.75, 100);
            await hsl.ScaleTo(1, 100);
        }
    }
}
