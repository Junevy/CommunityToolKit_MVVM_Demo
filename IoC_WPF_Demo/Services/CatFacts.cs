using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_WPF_Demo.Services
{
    class CatFacts : ICatFacts
    {
        private IWebClient _webClient;

        public CatFacts(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<IEnumerable<string>> GetCatFactsAsync(int limit)
        {
            var url = $"https://catfact.ninja/facts?limit={limit}";
            var response = await _webClient.GetStringAsync(url);
            var data = JObject.Parse(response);
            return data["data"]!.Select(x => x["fact"]!.ToString());
        }
    }
}
