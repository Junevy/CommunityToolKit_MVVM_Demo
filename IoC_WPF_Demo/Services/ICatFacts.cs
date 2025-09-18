using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_WPF_Demo.Services
{
    interface ICatFacts
    {
        Task<IEnumerable<string>> GetCatFactsAsync(int limit);
    }
}
