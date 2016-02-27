using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace XBD.Entity.Mapper
{
    public class ConfigMapper:BaseMap<Config>
    {
        public override void Init()
        {
            ToTable("Config");
            HasKey(m => m.Id);
        }
    }
}
