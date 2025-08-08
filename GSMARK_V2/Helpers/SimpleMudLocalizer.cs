using MudBlazor;

namespace GSMARK_V2.Helpers
{
    public class SimpleMudLocalizer : MudLocalizer
    {
        public string this[string key, params object[] arguments] => string.Format(key, arguments);

        public IEnumerable<string> Keys => Enumerable.Empty<string>();



    }
}
