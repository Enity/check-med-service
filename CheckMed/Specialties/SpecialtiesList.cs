using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace CheckMed.Specialties
{
    public class SpecialtiesList
    {
        public List<Specialty> _list = new List<Specialty>(10);

        public SpecialtiesList AddFromHtmlString(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            foreach (var specTuple in Parser.GetDataFromInput(htmlDoc, "LISTRETURN"))
            {
                _list.Add(new Specialty
                {
                    Name = specTuple.data,
                    Key = specTuple.key
                });
            }

            return this;
        }
    }
}