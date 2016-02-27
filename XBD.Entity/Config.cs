using System;
using Swift.Net.Base;

namespace XBD.Entity
{
    public class Config : BaseEntity
    {
        /// <summary>
        ///     编号
        /// </summary>
        public int Id { set; get; }


        /// <summary>
        ///     键名称
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        ///     键值
        /// </summary>
        public string Value { set; get; }


        /// <summary>
        ///     网站类型码
        /// </summary>
        public string CodeName { set; get; }

    }
}