using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YohandaMandala.Model;

namespace YohandaMandala.Controllers
{
    [Route("API/[controller]/[action]/{id?}")]
    [ApiController]
    public class AWSController : ControllerBase
    {
        [HttpPost]
        public async Task<ResultModel> Execute([FromBody]AWSInputModel input)
        {
            ResultModel data = new ResultModel();

            try
            {
                data.Data = input;

                string apiKey = "";
                string apiSecret = "";
                using (var client = new AmazonAPIGatewayClient(apiKey, apiSecret, RegionEndpoint.USWest2))
                {
                    var req = new CreateDomainNameRequest();
                    req.DomainName = input.DomainName;
                    req.RegionalCertificateArn = "arn:aws:acm:us-west-2:982503114711:certificate/01f19db5-daed-4ba0-bb43-ea32ebcf3c27";
                    req.SecurityPolicy = SecurityPolicy.TLS_1_2;
                    req.EndpointConfiguration = new EndpointConfiguration { Types = { "REGIONAL" } };
                    var res = await client.CreateDomainNameAsync(req);

                    if (res.HttpStatusCode != System.Net.HttpStatusCode.Created)
                        throw new Exception("Cannot create domain name "+req.DomainName);

                    var basePathReq = new CreateBasePathMappingRequest();
                    basePathReq.DomainName = input.DomainName;
                    basePathReq.RestApiId = "8fvfjctqr0";
                    basePathReq.Stage = "Prod";

                    var basePathRes = await client.CreateBasePathMappingAsync(basePathReq);
                    data.Data = basePathRes;
                }
            }
            catch (Exception ex)
            {
                data.Message = ex.Message;
            }

            return data;
        }
    }
}