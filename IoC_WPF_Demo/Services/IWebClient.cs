using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_WPF_Demo.Services
{
    interface IWebClient
    {
        Task<string> GetStringAsync(string url);
    }
}
