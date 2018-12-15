using System.Collections.Generic;
using System.Threading.Tasks;
using CheckMed.MedClient;
using CheckMed.Models;

namespace CheckMed
{
    public class CheckMedService
    {
        private readonly string _uri;

        public CheckMedService(string hospitalUri)
        {
            _uri = hospitalUri + "/cgi-bin/tcgi1.exe";
        }
        
        public async Task<List<Specialty>> GetSpecialtiesAsync()
        {
            return await Client.GetSpecialitiesAsync(_uri);
        }

        public async Task<List<Doctor>> GetDoctorsBySpec(string specKey)
        {
            var spec = new Specialty {Key = specKey};
            return await GetDoctorsBySpec(spec);
        }
        
        public async Task<List<Doctor>> GetDoctorsBySpec(Specialty spec)
        {
            return await Client.GetDoctorsBySpec(_uri, spec);
        }

        public async Task<List<Ticket>> GetTicketsByDoc(string docKey)
        {
            var doc = new Doctor {Key = docKey};
            return await GetTicketsByDoc(doc);
        }
        
        public async Task<List<Ticket>> GetTicketsByDoc(Doctor doc)
        {
            return await Client.GetTicketsByDoc(_uri, doc);
        }
    }
}