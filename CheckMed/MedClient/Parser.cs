using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CheckMed.Models;
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

        public static IEnumerable<Ticket> GetTicketsFromHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // На 12.02.18г номера находятся тут. Легко могут изменить.
            var ticketsNodes = doc.DocumentNode
                .SelectNodes("//form[@id='f1']//button/span");

            return ticketsNodes.Select(node => ExtractTicketFromText(node.InnerText));
        }
        
        // Тут супер ансейф парсинг строчек внутри кнопок
        private static Ticket ExtractTicketFromText(string text)
        {
            var ticket = new Ticket
            {
                Reserved = false,
                Available = false,
            };
            
            var dateRegex = new Regex(@"\d+[-.\/]\d+[-.\/]\d+");
            var timeRegex = new Regex(@"\d+[:]\d+");
            var isAvailableRegex = new Regex(@"\((\w)\)");
            
            var date = dateRegex.Match(text).Value;
            var time = timeRegex.Match(text).Value;

            ticket.DateTime = date + " " + time;
            
            var isAvailableFlag = isAvailableRegex.Match(text);

            if (isAvailableFlag.Success)
            {
                var flag = isAvailableFlag.Groups[1].Value;
                if (flag[0] == 'R') ticket.Reserved = true;
            }
            else
            {
                ticket.Available = true;
            }

            return ticket;
        }
    }
}