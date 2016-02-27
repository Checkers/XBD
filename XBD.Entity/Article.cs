using System;
using Swift.Net.Base;

namespace XBD.Entity
{
    public class Article : BaseEntity
    {
        /// <summary>
        ///     主键id
        /// </summary>
        public int Id { set; get; }


        /// <summary>
        ///     所属类目
        /// </summary>
        public int? TypeId { set; get; }


        /// <summary>
        ///     文章标题
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        ///     文章内容
        /// </summary>
        public string Content { set; get; }


        /// <summary>
        ///     文章描述
        /// </summary>
        public string Description { set; get; }


        /// <summary>
        ///     关键词
        /// </summary>
        public string KeyWord { set; get; }

        /// <summary>
        ///     排序
        /// </summary>
        public int? Sort { set; get; }

       

    }
}