using Sea.Core.Entity.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Sys.View
{

    /// <summary>
    /// 用户信息
    /// </summary>
    [Table("View_Sys_User2Role")]
    public partial class ViewUser2Role : EntityBaseWithSoftDelete
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
