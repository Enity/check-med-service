using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace CheckMed.MedClient
{
    public static class Parser
    {
        /*
         * На 15.12.18г все списки лежат строкой в инпуте LISTRETURN, вроде даже консистентно.
         * Ищем его и парсим
         */
        public static IEnumerable<(string key, string data)> GetDataFromInput(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var valueToParse = doc.DocumentNode
                .SelectSingleNode("//input[@name='LISTRETURN']")
                .Attributes["value"].Value;
     
            return valueToParse.Split(';')
                .Select(el =>
                {
                    var m = el.Split('-');
                    return (m[0], m[1]);
                })
                .ToArray();
        }
    }
}