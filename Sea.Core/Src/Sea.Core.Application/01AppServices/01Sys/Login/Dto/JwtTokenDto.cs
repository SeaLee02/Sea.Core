using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Application.AppServices.Sys.Login.Dto
{
    public class JwtTokenInDto
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [Required(ErrorMessage = "用户名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "用户密码不能为空")]
        public string Pass { get; set; }
    }


    public class JwtTokenOutDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public double Expires_in { get; set; }
        public string Token_Type { get; set; }
    }
}
