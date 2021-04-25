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
    /// 基础-接口表
    /// </summary>
    [Table("Sys_Module")]
    public partial class ModuleEntity : EntityBaseWithSoftDelete
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 菜单链接地址
        /// </summary>
        [Column("LinkUrl")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        [Column("Area")]
        public string Area { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        [Column("Controller")]
        public string Controller { get; set; }

        /// <summary>
        /// Action名称
        /// </summary>
        [Column("Action")]
        public string Action { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Column("Icon")]
        public string Icon { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        [Column("Code")]
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("OrderSort")]
        public int? OrderSort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 是否是右侧菜单
        /// </summary>
        [Column("IsMenu")]
        public bool? IsMenu { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        [Column("IsEnabled")]
        public bool? IsEnabled { get; set; }
    }
}
