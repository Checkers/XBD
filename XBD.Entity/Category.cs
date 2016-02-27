using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Net.Base;

namespace XBD.Entity
{
    public class Category : BaseEntity
    {
        /// <summary>
        ///     主键id
        /// </summary>
        public int Id { set; get; }


        /// <summary>
        ///     标题名称
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        ///     代码
        /// </summary>
        public string CodeName { set; get; }


        /// <summary>
        ///     父级id
        /// </summary>
        public int? Pid { set; get; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWord { set; get; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Link { set; get; }

        /// <summary>
        /// 链接
        /// </summary>
        public int? Sort { set; get; }
        
    }
}
