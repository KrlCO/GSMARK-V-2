using MudBlazor;

namespace GSMARK_V2.Helpers
{
    public class DefaultLocalizer 
    {
        public string this[string key, params object[] arguments]
        {
            get
            {
                if (arguments == null || arguments.Length == 0)
                    return key;
                return string.Format(key, arguments);
            }
        }
    }

}
