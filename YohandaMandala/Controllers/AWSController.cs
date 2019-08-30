using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        public ResultModel Execute([FromBody]AWSInputModel input)
        {
            ResultModel data = new ResultModel();

            try
            {
                data.Data = input;
                var cmdResult = new List<string>();
                foreach (var line in input.CommandList)
                {
                    var escapedArgs = line.Replace("\"", "\\\"");

                    var process = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "/bin/bash",
                            Arguments = $"-c \"{escapedArgs}\"",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true,
                        }
                    };
                    process.Start();
                    string res = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    cmdResult.Add(res);
                }
                data.Message = string.Join(Environment.NewLine, cmdResult);
            }
            catch (Exception ex)
            {
                data.Message = ex.Message;
            }

            return data;
        }
    }
}