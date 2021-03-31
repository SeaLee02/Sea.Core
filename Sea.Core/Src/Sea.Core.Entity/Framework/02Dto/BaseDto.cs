using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Framework
{
    public abstract class BaseDto<TKey> : _Entity<TKey>
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual bool IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除人
        /// </summary>
        public virtual string DeleteName { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public virtual string CreateId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual string ModifyId { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public virtual string CreateName { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual string ModifyName { get; set; }
    }

    public abstract class BaseDto : BaseDto<string>
    {

    }
}
