using System;
using System.Threading.Tasks;
using CheckMed;

namespace ConsoleApi
{
    
    // TODO
    static class Program
    {
        private static void Main(string[] args)
        {
            Check().GetAwaiter().GetResult();
        }

        private static async Task Check()
        {
            var service = new CheckMedService();
            service.SetUri("http://94.19.37.202:3008");
            var specs = await service.GetSpecialtiesAsync();
            Console.ReadKey();
        }
    }
}