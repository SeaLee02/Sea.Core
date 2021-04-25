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
    /// 用户角色表
    /// </summary>
    [Table("Sys_User2Role")]
    public partial class User2RoleEntity : EntityBaseWithSoftDelete
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("UserId")]
        public string UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("RoleId")]
        public string RoleId { get; set; }
    }
}
