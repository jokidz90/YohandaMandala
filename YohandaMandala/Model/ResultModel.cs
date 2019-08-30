using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YohandaMandala.Model
{
    public class ResultModel
    {
        public int? ResultCode { set; get; }
        public string Status { set; get; }
        public string Message { set; get; }
        public int? DataLength { set; get; }
        public object Data { set; get; }
        public object DataSummary { set; get; }
        public string PrevID { set; get; }
        public string NextID { set; get; }
    }
}
