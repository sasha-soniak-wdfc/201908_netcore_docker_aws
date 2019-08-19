using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapp.services;

namespace webapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstancesController : ControllerBase
    {
        private readonly IEC2Service _ec2Service;

        public InstancesController(IEC2Service ec2Service)
        {
            _ec2Service = ec2Service;
        }

        // GET api/instances
        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            return await _ec2Service.EC2Instances();
        }

    }
}
