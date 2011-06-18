using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

namespace ClientUsingConfig
{
    class ClientUsingConfig
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter to start");
            Console.ReadLine();

            ClientFromConfig();

            CallServerUsingConfig();
        }

        static void ClientFromConfig()
        {
            RemotingConfiguration.Configure("ClientConfig.config", true);

            SimpleIT.RemoteHello remHello = new SimpleIT.RemoteHello();

            Console.WriteLine("ClientFromConfig(): remHello.SayHello() = " + remHello.SayHello());
        }

        static void CallServerUsingConfig()
        {
            // http://generally.wordpress.com/2007/05/31/a-simple-remoting-example-in-c/
            //TcpChannel tcpChannel = SimpleIT.Utils.RandomTcpChannel();
            TcpChannel tcpChannel = null;
            SimpleIT.Utils.RandomTcpChannel(out tcpChannel);

            ChannelServices.RegisterChannel(tcpChannel, true);

            SimpleIT.RemoteHello remHello =
                Activator.GetObject(typeof(SimpleIT.RemoteHello), "tcp://127.0.0.1:8123/RemoteHello")
                as SimpleIT.RemoteHello;

            Console.WriteLine("CallServerUsingConfig(): remHello.SayHello() = " + remHello.SayHello());
        }
    }
}
