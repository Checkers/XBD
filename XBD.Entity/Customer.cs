using System;
using Swift.Net.Base;

namespace XBD.Entity
{
    public class Customer : BaseEntity
    {
        /// <summary>
        ///     主键
        /// </summary>
        public int Id { set; get; }


        /// <summary>
        ///     客户名称
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        ///     客户图片
        /// </summary>
        public string ImgUrl { set; get; }


        /// <summary>
        ///     客户链接
        /// </summary>
        public string Link { set; get; }


        /// <summary>
        ///     网站类型码
        /// </summary>
        public string CodeName { set; get; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? Sort { get; set; }

    }
}