using Microsoft.EntityFrameworkCore;
using Sea.Core.Entity.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Sys
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("Sys_User")]
    public partial class UserEntity: EntityBaseWithSoftDelete
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Column("LoginName")]
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Column("LoginPwd")]
        public string LoginPwd { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        [Column("RealName")]
        public string RealName { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        [Column("Status")]
        public int? Status { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Column("Sex")]
        public int? Sex { get; set; }

        /// <summary>
        /// 年纪
        /// </summary>
        [Column("Age")]
        public int? Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Column("Birth")]
        public DateTime? Birth { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Column("Addr")]
        public string Addr { get; set; }

        ///// <summary>
        ///// 测试
        ///// </summary>
        //[Column("CS")]
        ////描述
        //[Comment("测试")]
        ////字段长度
        //[StringLength(200)]
        //public string CS { get; set; }

    }
}
