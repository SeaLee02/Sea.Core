using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Api.Controllers
{
    /// <summary>
    /// 控制器基础类
    /// </summary>
    [ApiController]
    [Route("api/[area]/[controller]/[action]")]
    [Authorize(Permissions.Name)]
    public abstract class ControllerAbstract : ControllerBase
    { 
        


    }
}
