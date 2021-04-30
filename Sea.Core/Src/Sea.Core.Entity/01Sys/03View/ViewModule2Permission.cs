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
    [Table("View_Sys_Module2Permission")]
    public partial class ViewModule2Permission : EntityBaseWithSoftDelete
    {

        /// <summary>
        /// api ID
        /// </summary>
        [Column("ModuleId")]
        public string ModuleId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        [Column("PermissionId")]
        public string PermissionId { get; set; }
    }
}
