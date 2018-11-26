using System.Collections.Generic;
using CheckMed.Specialties;
using HtmlAgilityPack;

namespace CheckMed.Doctors
{
    public class DoctorsList
    {
        private readonly List<Doctor> _list = new List<Doctor>(15); 
        
        public DoctorsList AddFromHtmlString(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            foreach (var specTuple in Parser.GetDataFromInput(htmlDoc, "LISTRETURN"))
            {
                _list.Add(new Doctor
                {
                    Name = specTuple.data,
                    Key = specTuple.key
                });
            }

            return this;
        }
    }
}