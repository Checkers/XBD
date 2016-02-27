using Swift.Net.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBD.Entity
{
    public class Narcotics : BaseEntity
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 别名
        /// </summary>
        public string SubName { set; get; }

        /// <summary>
        /// CAS号
        /// </summary>
        public string CASNo { set; get; }
    }
}
