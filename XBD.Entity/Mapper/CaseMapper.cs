using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace XBD.Entity.Mapper
{
    public class CaseMapper:BaseMap<Case>
    {
        public override void Init()
        {
            ToTable("Case");
            HasKey(m => m.Id);
        }
    }
}
