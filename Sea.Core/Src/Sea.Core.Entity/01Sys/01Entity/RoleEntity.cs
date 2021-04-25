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
    /// 角色表
    /// </summary>
    [Table("Sys_Role")]
    public partial class RoleEntity : EntityBaseWithSoftDelete
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("OrderSort")]
        public int? OrderSort { get; set; }


        /// <summary>
        /// 是否启动
        /// </summary>
        [Column("IsEnabled")]
        public bool IsEnabled { get; set; } = false;       

    }
}
