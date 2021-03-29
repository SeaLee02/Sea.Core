using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Framework.Entity.Abstractions
{
    /// <summary>
    /// 多租户
    /// </summary>
    public interface ITenant
    {
        Guid? TenantId { get; set; }
    }
}
