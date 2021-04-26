using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sea.Core.Entity.Sys.View
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public partial class ViewUser
    {
        ///// <summary>
        ///// 对应的主表
        ///// </summary>
        //[ForeignKey("CustomerId")]
        //public virtual CY19Entity CY19 { get; set; }

        ///// <summary>
        ///// 对应的从表
        ///// </summary>
        //public virtual ICollection<CY60Entity> CY59s { get; set; }
    }

    /// <summary>
    ///用户信息表配置
    /// </summary>
    public class ViewUserConfiguration : IEntityTypeConfiguration<ViewUser>
    {
        /// <summary>
        /// builder的配置类
        /// </summary>
        /// <param name="builder">数据库的build</param>
        public void Configure(EntityTypeBuilder<ViewUser> builder)
        {
           
            //builder.HasNoKey().ToView("View_Sys_User");
        }
    }
}
