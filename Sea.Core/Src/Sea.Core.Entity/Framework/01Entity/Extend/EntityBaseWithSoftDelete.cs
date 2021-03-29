using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Framework.Entity.Extend
{
    /// <summary>
    /// 软删除基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class EntityBaseWithSoftDelete<TKey> : EntityWithSoftDelete<TKey>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        [Column("CreateId")]
        public Guid CreateId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("ModifyTime")]
        public DateTime? ModifyTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改人
        /// </summary>
        [Column("ModifyId")]
        public Guid ModifyId { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        [NotMapped]
        public string CreateName { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [NotMapped]
        public string ModifyName { get; set; }
    }

    /// <summary>
    /// 包含软删除功能的实体基类
    /// </summary>
    public class EntityBaseWithSoftDelete : EntityBaseWithSoftDelete<Guid>
    {

    }
}
