using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YohandaMandala.Model;

namespace YohandaMandala.Controllers
{
    [Route("API/[controller]/[action]/{id?}")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public ResultModel Version()
        {
            ResultModel result = new ResultModel();

            try
            {
                var data = new APIVersionModel();
                var asmName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                data.APIName = asmName.Name;
                data.APIVersion = asmName.Version.ToString();

                result.Data = data;
                result.Status = "SUCCESS";
                result.ResultCode = 200;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}