using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Framework.Entity.Extend
{
    /// <summary>
    /// 包含指定类型主键的软删除实体
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TDeletedByKey">删除人主键类型</typeparam>
    public class EntityWithSoftDelete<TKey> : Entity<TKey>
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column("IsDelete")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Column("DeleteTime")]
        public DateTime? DeleteTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 删除人
        /// </summary>
        [NotMapped]
        public Guid DeleteName { get; set; }

        /// <summary>
        /// 删除人名称
        /// </summary>
        [NotMapped]
        public string Deleter { get; set; }
    }

    /// <summary>
    /// 主键类型GUID的软删除实体
    /// </summary>
    public class EntityWithSoftDelete : EntityWithSoftDelete<Guid>
    {

    }
}
