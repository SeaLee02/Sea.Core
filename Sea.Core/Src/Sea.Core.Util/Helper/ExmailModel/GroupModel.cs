using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Util.Helper.ExmailModel
{
    public class GroupModel:ExmailModel
    {
        public List<string> Invalid_Userlist { get; set; }

        public List<string> Invalid_Departlist { get; set; }

        public List<string> Invalid_Taglist { get; set; }

        public List<string> Invalid_Grouplist { get; set; }
    }




    /// <summary>
    /// 创建邮件组
    /// </summary>
    public class CreateGroupModel 
    {
        /// <summary>
        /// 邮件组Id
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 邮件组名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 成员帐号
        /// </summary>
        public List<string> UserList { get; set; }

        /// <summary>
        /// 标签id
        /// </summary>
        public List<string> TagList { get; set; }

        /// <summary>
        /// 邮件群组账号
        /// </summary>
        public List<string> GroupList { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public List<long> Department { get; set; }

        /// <summary>
        /// 群发权限。0: 企业成员, 1任何人， 2:组内成员，3:自定义成员。
        /// 当值为0、1、2时，不得传入allow_userlist，allow_department，allow_taglist。
        /// 当值为3时，必须传入allow_userlist，allow_department，allow_taglist至少一项。
        /// </summary>
        public int Allow_Type { get; set; }

        /// <summary>
        /// 邮件组名称
        /// </summary>
        public List<string> Allow_UserList { get; set; }

        /// <summary>
        /// 邮件组名称
        /// </summary>
        public List<string> Allow_Department { get; set; }

        /// <summary>
        /// 邮件组名称
        /// </summary>
        public List<string> Allow_Taglist { get; set; }



    }
}
