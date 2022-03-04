using System;
using System.Text.Json;

namespace WebClient3 // Note: actual namespace depends on the project name.
{
    public class Position
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Station
    {
        public int number { get; set; }
        public string contract_name { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        public int bike_stands { get; set; }
        public int available_bike_stands { get; set; }
        public int available_bikes { get; set; }
        public string status { get; set; }
        public object last_update { get; set; }
    }

    internal class Program2
    {

        static async Task Main(string[] args)
        {
            string contractName = args[0];
            string api_key = "11fc45a179fbeb0110b569140531ba209a7ef115";
            using var client = new HttpClient();

            string responseBody = await client.GetStringAsync($"https://api.jcdecaux.com/vls/v3/stations/{station_number}?contract={contractName}&apiKey={api_key}");

            var stations = JsonSerializer.Deserialize<List<Station>>(responseBody);

            foreach (Station station in stations)
            {
                Console.WriteLine(station.number);
                Console.WriteLine(station.contract_name);
                Console.WriteLine(station.name);
                Console.WriteLine(station.address);
                Console.WriteLine(station.position.lat);
                Console.WriteLine(station.position.lng);
                Console.WriteLine(station.banking);
                Console.WriteLine(station.bonus);
                Console.WriteLine(station.bike_stands);
                Console.WriteLine(station.available_bike_stands);
                Console.WriteLine(station.available_bikes);
                Console.WriteLine(station.status);
                Console.WriteLine(station.last_update);
            }

            Console.ReadLine();
        }
    }
}

https://api.jcdecaux.com/vls/v3/stations/{station_number}?contract={contract_name}
