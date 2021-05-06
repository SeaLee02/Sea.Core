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
    /// 基础-角色接口菜单关系表
    /// </summary>
    [Table("Sys_Role2Module2Permission")]
    public partial class Role2Module2PermissionEntity : EntityBaseWithSoftDelete
    {
        /// <summary>
        /// 菜单
        /// </summary>
        [Column("ModuleId")]
        public string ModuleId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("RoleId")]
        public string RoleId { get; set; }

        /// <summary>
        /// 接口
        /// </summary>
        [Column("PermissionId")]
        public string PermissionId { get; set; }


    }
}
