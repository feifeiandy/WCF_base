using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2wcf
{
    public class HelloService:IHelloService
    {
        public string sayHello(string say)
        {
            return "来自WCF服务："+say;
        }
    }
}
