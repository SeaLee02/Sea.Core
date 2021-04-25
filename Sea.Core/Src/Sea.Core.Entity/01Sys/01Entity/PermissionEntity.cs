using Sea.Core.Entity.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Sys
{
    /// <summary>
    /// 基础-路由菜单表,菜单表
    /// </summary>
    [Table("Sys_Permission")]
    public partial class PermissionEntity : EntityBaseWithSoftDelete
    {
        /// <summary>
        /// 菜单执行的Action
        /// </summary>
        [Column("Code")]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary
        [Column("IsHide")]
        public bool IsHide { get; set; }


        /// <summary>
        /// 是否保持
        /// </summary>
        [Column("IskeepAlive")]
        public bool? IskeepAlive { get; set; }


        /// <summary>
        /// 按钮事件
        /// </summary>
        [Column("Func")]
        public string Func { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("OrderSort")]
        public int OrderSort { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        [Column("Icon")]
        public string Icon { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 激活状态
        /// </summary>
        [Column("IsEnabled")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        /// 上一级菜单（0表示上一级无菜单）
        /// </summary>
        [Column("Pid")]
        public string Pid { get; set; }

        /// <summary>
        /// 接口api
        /// </summary>
        [Column("Mid")]
        public string Mid { get; set; }

    }
}
