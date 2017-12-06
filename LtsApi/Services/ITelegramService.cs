using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtsApi.Services
{
    public interface ITelegramService
    {
         Task<string> SendAndonMessageAsync(string function, string station);
    }
}
