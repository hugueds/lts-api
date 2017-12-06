using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net;
using System.IO;

namespace LtsApi.Services
{
    public class TelegramService : ITelegramService
    {
        private static readonly string _api = @"https://api.telegram.org";
        private static readonly string _botToken = @"bot411150962:AAG12zAcc8F2zbWuIVusbMLmDd8SjiYAjnY";
        private static string method = "sendMessage";
        private static string chat_id = "@andon_truck";

        public async Task<string> SendAndonMessageAsync(string function, string station)
        {

            string message = $"🚨 POSTO PRECISANDO DE AJUDA 🚨 \n FUNÇÃO: {function} \n POSTO: {station}";
            string path = $"{_api}/{_botToken}/{method}?chat_id={chat_id}&text={message}";

            using (HttpClient client = new HttpClient(new HttpClientHandler()
            {
                Proxy = new WebProxy(@"http://global%5Cservicelts:America2016@148.148.192.2:8080", false),                
                UseDefaultCredentials = false
            }))
            {

                client.BaseAddress = new Uri(path);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(path);              

                return "Ok";

            }
        }


    }

}