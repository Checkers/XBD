using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace XBD.Entity.Mapper
{
    public class AdminMapper:BaseMap<Admin>
    {
        public override void Init()
        {
            ToTable("Admin");
            HasKey(m => m.Id);
        }
    }
}
