using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YohandaMandala.Model
{
    public class APIVersionModel
    {
        public string APIName { set; get; }
        public string APIVersion { set; get; }
        public string APICoreName { set; get; }
        public string APICoreVersion { set; get; }
        public string MobordAndroidMinVersion { set; get; }
        public string MobordIOSMinVersion { set; get; }
        public string EquipMinVersion { set; get; }
        public string DBName { set; get; }
        public bool IsDBConnected { set; get; }
    }
}
