using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Amazon.Util;

namespace service2.Controllers
{
    [Route("")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            var instanceId = Amazon.Util.EC2InstanceMetadata.InstanceId;
            var response = String.Format("It's SERVICE 2. I'm working on instance: {0}", instanceId);
            return response;
        }

    }
}
