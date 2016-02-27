using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace XBD.Entity.Mapper
{
    public class CustomerMapper : BaseMap<Customer>
    {
        public override void Init()
        {
            ToTable("Customer");
            HasKey(m => m.Id);
        }
    }
}
