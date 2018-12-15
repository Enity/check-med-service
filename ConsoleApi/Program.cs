using System;
using System.Threading.Tasks;
using CheckMed;

namespace ConsoleApi
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Check().GetAwaiter().GetResult();
        }

        private static async Task Check()
        {
            var service = new CheckMedService("http://94.19.37.202:3008");
            var specs = await service.GetSpecialtiesAsync();
            var docs = await service.GetDoctorsBySpec(specs[2]);
            var tickets = await service.GetTicketsByDoc(docs[0]);
            Console.ReadKey();
        }
    }
}