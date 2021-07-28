using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SeleniumSpecFlow.Classes
{
    public static class TableRowExtensions
    {
        public static bool ContainsNonEmptyKey(this TableRow row, string key)
        {
            return row.ContainsKey(key) && !string.IsNullOrEmpty(row[key]);
        }

        public static bool IsEmpty(this TableRow row)
        {
            return row.Values.All(x => x.IsNullOrEmpty());
        }
    }
}
