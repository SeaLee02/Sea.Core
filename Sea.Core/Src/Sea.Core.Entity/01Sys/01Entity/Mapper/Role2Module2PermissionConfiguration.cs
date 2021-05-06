using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Sys
{
    public partial class Role2Module2PermissionEntity
    {
        [ForeignKey("RoleId")]
        public virtual RoleEntity  RoleEntity { get; set; }

        [ForeignKey("ModuleId")]
        public virtual ModuleEntity  ModuleEntity { get; set; }

        [ForeignKey("PermissionId")]
        public virtual PermissionEntity  PermissionEntity { get; set; }
    }
}
