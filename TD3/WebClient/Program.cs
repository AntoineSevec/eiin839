using System;
using System.Text.Json;

namespace WebClient1 // Note: actual namespace depends on the project name.
{
    public class Contract
    {
        public string? name { get; set; }
        public string? commercial_name { get; set; }
        public List<string>? cities { get; set; }
        public string? country_code { get; set; }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            string api_key = "11fc45a179fbeb0110b569140531ba209a7ef115";

            using var client = new HttpClient();

            string responseBody = await client.GetStringAsync($"https://api.jcdecaux.com/vls/v3/contracts?apiKey={api_key}");

            var contracts = JsonSerializer.Deserialize<List<Contract>>(responseBody);

            foreach (Contract contract in contracts)
            {
                Console.WriteLine(contract.name);
                Console.WriteLine(contract.commercial_name);
                if(contract.cities != null)
                {
                    foreach (var city in contract.cities)
                    {
                        Console.WriteLine(city);
                    }
                }
                Console.WriteLine(contract.country_code);
            }

            Console.ReadLine();
        }
    }
}
