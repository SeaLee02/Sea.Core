using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sea.Core.Util.Helper.ExmailModel
{
    /// <summary>
    /// 部门列表
    /// </summary>
    public class DepartmentListModel: ExmailModel
    {
        /// <summary>
        /// 部门集合
        /// </summary>
        public List<DepartmentModel> Department { get; set; }

    }

    /// <summary>
    /// 部门列表
    /// </summary>
    public class DepartmentModel 
    {
        /// <summary>
        /// 部门ID id
        /// </summary>
        
        public long Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父部门id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 在父部门中的次序值.order值小的排序靠前
        /// </summary>
        public int Order { get; set; }

        
    }

    /// <summary>
    /// 创建部门成功返回Id
    /// </summary>
    public class CreateDepartmentModel : ExmailModel
    {
        /// <summary>
        /// 部门ID id
        /// </summary>

        public long Id { get; set; }
    }


    /// <summary>
    /// 创建部门
    /// </summary>
    public class CreateDepartmentDto 
    {

        /// <summary>
        /// 部门名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 父部门id
        /// </summary>
        [Required]
        public long ParentId { get; set; }

        /// <summary>
        /// 在父部门中的次序值.order值小的排序靠前
        /// </summary>
        public int Order { get; set; } = 0;

    }


    public class UpdateDepartmentDto: CreateDepartmentDto
    {  
        /// <summary>
        /// 部门id
        /// </summary>
        [Required]
        [JsonPropertyName("id")]
        public long Id { get; set; }

    }
}
