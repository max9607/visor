using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLVISORTELERIK.Helpers
{
    public static class NavigationManagerExtensions
    {
        public static Dictionary<string, string> ObtenerQueryStrings(this NavigationManager navigationManager, string url)
        {
            if (string.IsNullOrWhiteSpace(url) || !url.Contains("?") || url.Substring(url.Length - 1) == "?")
            {
                return null;
            }

            // https://dominio.com?llave1=valor1&llave2=valor2

            var queryStrings = url.Split(new string[] { "?" }, StringSplitOptions.None)[1];
            Dictionary<string, string> dicQueryString =
                                                    queryStrings.Split('&')
                                                         .ToDictionary(c => c.Split('=')[0],
                                                                       c => Uri.UnescapeDataString(c.Split('=')[1]));

            return dicQueryString;
        }

        public static string ObtenerUrlSinParametro(this NavigationManager navigationManager, string parametro)
        {
            var url = navigationManager.Uri;
            var dicQueryString = navigationManager.ObtenerQueryStrings(url);

            if (dicQueryString == null)
            {
                return url;
            }

            if (dicQueryString.ContainsKey(parametro))
            {
                dicQueryString.Remove(parametro);
            }

            var urlSinParametro = dicQueryString.Aggregate(url.Split('?')[0] + "?", (current, item) => current + (item.Key + "=" + item.Value + "&"));

            return urlSinParametro.Substring(0, urlSinParametro.Length - 1);
        }
    }
}
