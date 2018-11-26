using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckMed.Doctors;
using CheckMed.MedClient;
using CheckMed.Specialties;

namespace CheckMed
{
    public class Hospital
    {
        private readonly Client _client;
        public string Url { get; }
        public DoctorsList Doctors { get; }
        public SpecialtiesList Specs { get; private set; }
        public List<DoctorsList> AllDocs = new List<DoctorsList>();

        public Hospital(string url)
        {
            Url = url;
            _client = new Client(url);
        }
        
        public async Task syncDoctors()
        {
            
            var tasks = new List<Task>();
            
            foreach(var spec in Specs._list)
            {
                tasks.Add(writeBySpec(spec));
            }
            Task.WaitAll(tasks.ToArray());
        }

        private async Task writeBySpec(Specialty spec)
        {
            AllDocs.Add(await _client.GetDoctorsBySpec(spec));
        }

        public async Task syncSpecs()
        {
            Specs = await _client.GetSpecialties();
        }
    }
}