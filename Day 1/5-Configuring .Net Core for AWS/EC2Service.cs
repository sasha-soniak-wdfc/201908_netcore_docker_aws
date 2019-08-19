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
    public class EC2Service : IEC2Service
    {
        private readonly IAmazonEC2 _client;
        public EC2Service(IAmazonEC2 client)
        {
             _client = client;
        }

        public async Task<List<string>> EC2Instances()
        {
            var val = await getEc2Instances();
            return val;
        }
        private async Task<List<string>> getEc2Instances()
        {
            var request = new DescribeInstancesRequest();
            var response = await _client.DescribeInstancesAsync(request);
            var instanceIds = new List<string>();
            foreach (var reservation in response.Reservations)
            {
                foreach (var instance in reservation.Instances)
                {
                    instanceIds.Add(instance.InstanceId);
                }
            }
            return instanceIds;
        }
    }
}
