﻿using System;
using Swift.Net.Base;

namespace XBD.Entity.DTO
{
    public class CaseDTO
    {
        /// <summary>
        ///     主键
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        ///     所属客户
        /// </summary>
        public int? CustomerId { set; get; }

        /// <summary>
        ///     案例名称
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        ///     案例图片路径
        /// </summary>
        public string ImgUrl { set; get; }


        /// <summary>
        ///     案例描述
        /// </summary>
        public string Description { set; get; }


        /// <summary>
        ///     网站类型码
        /// </summary>
        public string CodeName { set; get; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? Sort { get; set; }


        public DateTime? AddTime { get; set; }
        public DateTime? EditTime { get; set; }
        public bool Enable { get; set; }
        public string Remark { get; set; }

        public Int64 numid { get; set; }

    }
}