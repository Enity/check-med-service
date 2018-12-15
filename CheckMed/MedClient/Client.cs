using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckMed.Enums;
using CheckMed.Models;

namespace CheckMed.MedClient
{
    public static class Client
    {
        public static async Task<List<Specialty>> GetSpecialitiesAsync(string uri)
        {
            var body = new ClientCommand()
                .AddMenuCode(Commands.GetSpecs);

            var result = await WebClient.PostAsync(uri, body);
   
            return Parser
                .GetDataFromInput(result)
                .Select(valueTuple => new Specialty
                {
                    Name = valueTuple.data,
                    Key = valueTuple.key
                })
                .ToList();
        }

        public static async Task<List<Doctor>> GetDoctorsBySpec(string uri, Specialty spec)
        {
            var body = new ClientCommand()
                .AddMenuCode(Commands.GetDoctorsBySpec)
                .AddSpecCode(spec.Key);

            var result = await WebClient.PostAsync(uri, body);
         
            return Parser
                .GetDataFromInput(result)
                .Select(valueTuple => new Doctor
                {
                    Name = valueTuple.data,
                    Key = valueTuple.key
                })
                .ToList();

        }
        
        public static async Task<List<Ticket>> GetTicketsByDoc(string uri, Doctor doc)
        {
            var body = new ClientCommand()
                .AddMenuCode(Commands.GetTickets)
                .AddDoctorCode(doc.Key)
                .AddAnyTimeCommand();

            var result = await WebClient.PostAsync(uri, body);

            return Parser
                .GetDataFromInput(result)
                .Select(valueTuple => new Ticket
                {
                    DateTime = valueTuple.key,
                    Available = valueTuple.data.Equals("F"),
                    Reserved = valueTuple.data.Equals("R")
                })
                .ToList();
        }
    }
}