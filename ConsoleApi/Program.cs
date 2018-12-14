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
            var facade = new CheckMedFacade();
            var specs = await facade.GetSpecialtiesAsync("http://94.19.37.202:3008/cgi-bin/tcgi1.exe");
            var docs = await facade.GetDoctorsBySpec("http://94.19.37.202:3008/cgi-bin/tcgi1.exe", specs[2]);
            await facade.GetTicketsByDoc("http://94.19.37.202:3008/cgi-bin/tcgi1.exe", docs[0]);
            Console.ReadKey();
        }
    }
}