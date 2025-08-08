using Microsoft.Extensions.Localization;

namespace GSMARK_V2.Helpers
{
    public class DummyStringLocalizer<T> : IStringLocalizer<T>
    {
        public LocalizedString this[string name]
              => new LocalizedString(name, name);

        public LocalizedString this[string name, params object[] arguments]
            => new LocalizedString(name, string.Format(name, arguments));

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
            => Enumerable.Empty<LocalizedString>();

        public IStringLocalizer WithCulture(System.Globalization.CultureInfo culture)
            => this;
    }
}
