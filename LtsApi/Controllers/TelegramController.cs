using LtsApi.Models;
using LtsApi.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Telegram.Bot;

namespace LtsApi.Controllers
{


    public class TelegramController : ApiController
    {

        private Uri urlProxy { get; set; }
        private WebProxy proxy { get;set;}

        public TelegramController()
        {
            urlProxy = new Uri(@"http://global%5Cservicelts:America2016@proxybrsa.scania.com:8080");
            proxy = new WebProxy(urlProxy, true);
        }

        [HttpGet]
        [Route("api/telegram/andon")]
        public async Task<IHttpActionResult> GetComplete(string function, string station)
        {           

            TelegramBotClient bot = new TelegramBotClient("411150962:AAG12zAcc8F2zbWuIVusbMLmDd8SjiYAjnY") { WebProxy = proxy };

            await bot.SendTextMessageAsync("@andon_truck", "teste");

            return Ok("SENT");

        }

    }

}





