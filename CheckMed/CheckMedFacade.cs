using System.Collections.Generic;
using System.Threading.Tasks;
using CheckMed.MedClient;
using CheckMed.Models;

namespace CheckMed
{
    public class CheckMedFacade
    {
        public async Task<List<Specialty>> GetSpecialtiesAsync(string hospitalUri)
        {
            return await Client.GetSpecialitiesAsync(hospitalUri);
        }

        public async Task<List<Doctor>> GetDoctorsBySpec(string hospitalUri, string specKey)
        {
            var spec = new Specialty {Key = specKey};
            return await GetDoctorsBySpec(hospitalUri, spec);
        }
        
        public async Task<List<Doctor>> GetDoctorsBySpec(string hospitalUri, Specialty spec)
        {
            return await Client.GetDoctorsBySpec(hospitalUri, spec);
        }

//        public async Task<List<Ticket>> GetTicketsByDoc(string hospitalUri, string docKey)
//        {
//            var doc = new Doctor {Key = docKey};
//            return await GetTicketsByDoc(hospitalUri, doc);
//        }
        
        public async Task GetTicketsByDoc(string hospitalUri, Doctor doc)
        {
            await Client.GetTicketsByDoc(hospitalUri, doc);
        }
    }
}