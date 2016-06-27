using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2wcf
{
    class Program
    {
        static void Main(string[] args)
        {
            //HelloServiceHost host = new HelloServiceHost();
            //host.Open();

            HelloServiceproxy ser = new HelloServiceproxy();
            Console.WriteLine(ser.say("李四"));
            Console.Read();
        }
    }

    public class HelloServiceHost : IDisposable
    {
        ServiceHost host;
        public const string baseAddress = "net.pipe://localhost";
        public const string sayAddress = "Hello";

        Type serviceType = typeof(HelloService);
        Type contractType = typeof(IHelloService);
        NetNamedPipeBinding bind = new NetNamedPipeBinding();
        public void CreateHost()
        {
            host = new ServiceHost(serviceType, new Uri[] { new Uri(baseAddress) });
            host.AddServiceEndpoint(contractType, bind, sayAddress);

        }

        public HelloServiceHost()
        {
            this.CreateHost();
        }

        public void Open()
        {
            Console.WriteLine("服务启动中.......");
            this.host.Open();
            Console.WriteLine("服务已启动.......");
        }

        public void Dispose()
        {
            if (host != null)
            {
                (host as IDisposable).Dispose();
            }
        }
    }


    [ServiceContract]
    interface Iservice
    {
        [OperationContract]
        string say(string say);
    }

    public class HelloServiceproxy:ClientBase<IHelloService>,Iservice
    {
        public static readonly Binding bind = new NetNamedPipeBinding();
        public static readonly EndpointAddress endpoint = new EndpointAddress(new Uri("net.pipe://localhost/Hello"));
        public HelloServiceproxy() : base(bind, endpoint) { }

        public string say(string say)
        {
            return Channel.sayHello(say);
        }
    }
}
