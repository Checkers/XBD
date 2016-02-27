using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace XBD.Entity.Mapper
{
    public class ArticleMapper : BaseMap<Article>
    {
        public override void Init()
        {
            ToTable("Article");
            HasKey(m => m.Id);
        }
    }
}
