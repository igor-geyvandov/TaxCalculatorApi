using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxService.Helpers
{
    /// <summary>
    /// Converts flat object with key valye pairs to query string format.
    /// </summary>
    public static class ObjectToQueryStringConverter
    {
        public static string Convert(object o, string[] excludeFields)
        {
            if (o != null)
            {
                var dictionary = HtmlHelper.ObjectToDictionary(o);
                var stringDictionary = new Dictionary<string, string>();
                foreach (var item in dictionary)
                {
                    if (item.Value != null && item.Value.ToString() != "" && !excludeFields.Contains(item.Key))
                    {
                        stringDictionary.Add(item.Key, item.Value.ToString());
                    }                    
                }
                return QueryHelpers.AddQueryString("", stringDictionary);
            }
            return string.Empty;
        }
    }
}
