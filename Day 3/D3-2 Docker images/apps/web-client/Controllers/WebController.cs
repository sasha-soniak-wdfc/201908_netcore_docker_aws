using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_client;

namespace web_client.Controllers
{
    [Route("")]
    [Route("api/[controller]")]
    [ApiController]
    public class WebController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            try
            {
                var service1Response = await getService1Response();
                var service2Response = await getService2Response();
                var response = String.Format("Service 1 response: {0} and Service 2 response: {1}", service1Response, service2Response);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "No data";
            }
        }

        private async Task<string> getService1Response()
        {
            web_client.Client client = new Client();
            var response = await client.GetService1Response();
            return response;
        }
        
        private async Task<string> getService2Response()
        {
            web_client.Client client = new Client();
            var response = await client.GetService2Response();
            return response;
        }
    }
}
