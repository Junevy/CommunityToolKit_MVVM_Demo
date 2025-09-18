using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IoC_WPF_Demo.Services
{
    class WebClient : IWebClient
    {
        private HttpClient httpClient = new();

        public async Task<string> GetStringAsync(string url)
        {
            return await httpClient.GetStringAsync(url);
        }
    }
}
