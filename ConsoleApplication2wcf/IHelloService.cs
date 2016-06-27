using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ConsoleApplication2wcf
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        string sayHello(string say);
    }
}
