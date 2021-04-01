using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea.Core.Extensions.AOP
{
    /// <summary>
    /// AOP拦截器
    /// </summary>
    public class LogAOP : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Intercept before,Method:{invocation.Method.Name}");
            invocation.Proceed();
            Console.WriteLine($"Intercept after,Method:{invocation.Method.Name}");
        }


    }
}
