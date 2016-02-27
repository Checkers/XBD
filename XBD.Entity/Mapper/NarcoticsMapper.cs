using Swift.Net.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBD.Entity.Mapper
{
    public class NarcoticsMapper : BaseMap<Narcotics>
    {
        public override void Init()
        {
            ToTable("Narcotics");
            HasKey(m => m.Id);
        }
    }
}
