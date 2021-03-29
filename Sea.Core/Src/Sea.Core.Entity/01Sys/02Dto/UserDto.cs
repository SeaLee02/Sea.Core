using Sea.Core.Entity.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Entity.Sys.Dto
{
    /// <summary>
    /// 用户信息Dto
    /// </summary>
    public partial class UserDto: BaseDto
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; set; }


        /// <summary>
        /// 登录名
        /// </summary>
        public int? Status { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 年纪
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birth { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Addr { get; set; }
    }

    /// <summary>
    /// 新增
    /// </summary>
    public partial class UserCreateDto : _Entity
    {

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; set; }


        /// <summary>
        /// 登录名
        /// </summary>
        public int? Status { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 年纪
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birth { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Addr { get; set; }
    }


    /// <summary>
    /// 新增
    /// </summary>
    public partial class UserUpdateDto : _Entity
    {

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; set; }


        /// <summary>
        /// 登录名
        /// </summary>
        public int? Status { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 年纪
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birth { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Addr { get; set; }
    }
}
