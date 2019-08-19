using System;
using System.Threading.Tasks;
using System.Net;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace parameterstoreapp
{
    class Program
    {
        private static string param1Name = "Name-Bucket1"; //bucket name
        private static string param2Name = "SQSURL-Queue1"; //queue url
        private static string secretParamName = "MySecretParam";
        private static string secretParamValue = "MySecretValue";
        
        
        static async Task Main(string[] args)
        {
            var param1 = await readParameter(param1Name, false);
            Console.WriteLine(string.Format("Param 1 value: {0}", param1));
            var param2 = await readParameter(param2Name, false);
            Console.WriteLine(string.Format("Param 2 value: {0}", param2));
            
            Console.WriteLine(await putParameter(secretParamName, secretParamValue, true));
            
            var param3 = await readParameter(secretParamName, true);
            Console.WriteLine(string.Format("My secret parameter value: {0}", param3));
        }
        
        private static async Task<string> readParameter(string parameterName, bool withEncryption = false)
        {
            var ssmClient = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.EUWest1);
            try
            {
                var response = await ssmClient.GetParameterAsync(new GetParameterRequest
                {
                    Name = parameterName,
                    WithDecryption = withEncryption
                });
                return response.Parameter.Value;
            }
            catch (Amazon.SimpleSystemsManagement.Model.ParameterNotFoundException)
            {
                return null;
            }
        }

        private static async Task<HttpStatusCode> putParameter(string parameterName, string parameterValue, bool withEncryption = false)
        {
            var ssmClient = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.EUWest1);
            var response = await ssmClient.PutParameterAsync(new PutParameterRequest
            {
                Name = parameterName,
                Overwrite = true,
                Value = parameterValue,
                Type = withEncryption ? ParameterType.SecureString : ParameterType.String
            });
            return response.HttpStatusCode;
        }
    }
}
