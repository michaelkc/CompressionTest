using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace compressiontestserver.Controllers
{
    public class HomeController : ControllerBase
    {
        private void AddOptInHeader()
        {
            this.Response.Headers.Add("Seges-NsCompressable", new StringValues("1"));
        }

        public IActionResult Index()
        {
            return Ok("Nothing to see here");
        }

        public IActionResult TextPlain(bool sendOptInHeader = false)
        {
            if (sendOptInHeader) AddOptInHeader();
            return Content(Lorem.Ipsum, "text/plain");
        }


        public IActionResult ApplicationJson(bool sendOptInHeader = false)
        {
            if (sendOptInHeader) AddOptInHeader();
            return Content(Lorem.Ipsum, "application/json");
        }

        public IActionResult ApplicationSoapXml(bool sendOptInHeader = false)
        {
            if (sendOptInHeader) AddOptInHeader();
            return Content(Lorem.Ipsum, "application/soap+xml");
        }

        public IActionResult ApplicationJsonUtf8(bool sendOptInHeader = false)
        {
            if (sendOptInHeader) AddOptInHeader();
            return Content(Lorem.Ipsum, "application/json; charset=utf-8", Encoding.UTF8);
        }

        public IActionResult ApplicationSoapXmlUtf8(bool sendOptInHeader = false)
        {
            if (sendOptInHeader) AddOptInHeader();
            return Content(Lorem.Ipsum, "application/soap+xml; charset=utf-8",Encoding.UTF8);
        }
    }
}
