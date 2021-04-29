using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sea.Core.Util.Helper.ExmailModel
{

    //    {
    //   	"userid": "zhangsan@gzdev.com",
    //   	"name": "张三",
    //   	"department": [1, 2],
    //   	"position": "产品经理",
    //   	"mobile": "15913215XXX",
    //   	"tel": "123456",
    //   	"extid": "01",
    //   	"gender": "1",
    //　 	"slaves": ["zhangsan@gz.com", "zhangsan@bjdev.com"],
    //	"password":"******",
    //	"cpwd_login":0
    //}
    /// <summary>
    /// 创建用户
    /// </summary>
    public class CreateUserModel
    {
        /// <summary>
        /// 成员UserID。企业邮帐号名，邮箱格式
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public List<long> Department { get; set; }

        /// <summary>
        /// 职位信息，长度不可超过32个汉字或者64个字符
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        ///手机号，新版本企业邮箱中为选填项，密码和手机号至少填写一项
        /// </summary>
        public string Mobile { get; set; }


        /// <summary>
        ///座机号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        ///编号
        /// </summary>
        public string ExtId { get; set; }


        /// <summary>
        ///性别。1表示男性，2表示女性
        /// </summary>
        public int? Gender { get; set; }


        /// <summary>
        ///别名列表1.Slaves 上限为5个2.Slaves 为邮箱格式
        /// </summary>
        public List<string> Slaves { get; set; }


        /// <summary>
        ///密码，必须同时包含大小写字母和数字，长度6-32位，不包含账户信息。
        /// </summary>
        public string PassWord { get; set; }


        /// <summary>
        ///用户重新登录时是否重设密码, 登陆重设密码后，该标志位还原。0表示否，1表示是，缺省为0
        /// </summary>
        public string Cpwd_Login { get; set; }


        /// <summary>
        ///设定创建的用户是否为VIP账户。0表示普通账号，1表示VIP账号
        /// </summary>
        public string SetVip { get; set; }

    }

    /// <summary>
    /// 用户详情
    /// </summary>
    public class UserModel :ExmailModel
    {
        /// <summary>
        /// 成员UserID。企业邮帐号名，邮箱格式
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public List<long> Department { get; set; }

        /// <summary>
        /// 职位信息，长度不可超过32个汉字或者64个字符
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        ///手机号，新版本企业邮箱中为选填项，密码和手机号至少填写一项
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        ///座机号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        ///编号
        /// </summary>
        public string ExtId { get; set; }

        /// <summary>
        ///性别。1表示男性，2表示女性
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        ///别名列表1.Slaves 上限为5个2.Slaves 为邮箱格式
        /// </summary>
        public List<string> Slaves { get; set; }    

        /// <summary>
        ///用户重新登录时是否重设密码, 登陆重设密码后，该标志位还原。0表示否，1表示是，缺省为0
        /// </summary>
        public string Cpwd_Login { get; set; }

        /// <summary>
        /// 启用/禁用成员。1表示启用成员，0表示禁用成员
        /// </summary>
        public int Enable { get; set; }
    }
}
