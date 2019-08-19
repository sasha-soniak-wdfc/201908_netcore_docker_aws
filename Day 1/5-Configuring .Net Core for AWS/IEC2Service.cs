using System.Threading.Tasks;
using System.IO;
using System;
using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon;
using Amazon.Extensions.NETCore;

namespace webapp.services
{
    public interface IEC2Service 
    {
        Task<List<string>> EC2Instances();
    }
}
