using System;
using System.ComponentModel;
using Swift.Net.Base;

namespace XBD.Entity
{
    public class Admin:BaseEntity
    {
        /// <summary>
        ///     编号
        /// </summary>
        public int Id { set; get; }


        /// <summary>
        ///     用户名
        /// </summary>
        public string Name { set; get; }


        /// <summary>
        ///     密码
        /// </summary>
        public string Pwd { set; get; }

    }
}