using AutoMapper;
using Sea.Core.Entity.Sys;
using Sea.Core.Entity.Sys.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Extensions.AutoMapper
{
    public partial class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap(); ;
            //CreateMap<BlogViewModels, BlogArticle>();
        }
    }
}

