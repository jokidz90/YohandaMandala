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
            ResultModel data = new ResultModel();

            return data;
        }

        [HttpGet]
        public ResultModel Test(string id)
        {
            ResultModel data = new ResultModel();
            data.Data = id;
            return data;
        }
    }
}