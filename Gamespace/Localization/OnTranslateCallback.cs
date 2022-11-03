namespace Gamespace.Localization
{
    public delegate void OnTranslateCallback(string value);
    public class TranslateStack
    {
        public OnTranslateCallback callback;
        public string key;

        public TranslateStack(string key)
        {
            this.key = key;
        }
    }

    public static class LocalizationExtensions
    {
        public static T OnTranslated<T>(this T t, OnTranslateCallback callback) where T : TranslateStack
        {
            if ((object) t == null)
                return t;

            t.callback = callback;

            return t;
        }
    }
}