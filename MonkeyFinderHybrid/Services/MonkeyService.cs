using MonkeyFinderHybrid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinderHybrid.Services
{
    public class MonkeyService
    {
        private List<Monkey> monkeyList = new();
        private readonly HttpClient httpClient;

        public MonkeyService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Monkey>> GetMonkeys()
        {
            if (monkeyList.Count > 0)
            {
                return monkeyList;
            }

            var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
            if (response.IsSuccessStatusCode) 
            {
                var resultMonkeys = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);

                if (resultMonkeys is not null) 
                {
                    monkeyList = resultMonkeys;
                }
            }
            return monkeyList;
        }
    }

}
