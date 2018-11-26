using System.Linq;
using HtmlAgilityPack;

namespace CheckMed
{
    public static class Parser
    {
        public static (string key, string data)[] GetDataFromInput(HtmlDocument doc, string inputName)
        {
            var valueToParse = doc.DocumentNode
                .SelectSingleNode($"//input[@name='{inputName}']")
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