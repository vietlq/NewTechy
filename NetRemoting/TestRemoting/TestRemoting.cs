using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

namespace TestRemoting
{
    class TestRemoting
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter to start");
            Console.ReadLine();

            ClientUsingTcp();

            ClientUsingHttp();
        }

        static void ClientUsingTcp()
        {
            // http://generally.wordpress.com/2007/05/31/a-simple-remoting-example-in-c/
            TcpChannel tcpChannel = new TcpChannel();

            ChannelServices.RegisterChannel(tcpChannel, true);

            SimpleIT.RemoteHello remHello =
                Activator.GetObject(typeof(SimpleIT.RemoteHello), "tcp://127.0.0.1:8234/RemoteHello")
                as SimpleIT.RemoteHello;

            Console.WriteLine("ClientUsingTcp(): remHello.SayHello() = " + remHello.SayHello());
        }

        static void ClientUsingHttp()
        {
            HttpChannel httpChannel = new HttpChannel();

            ChannelServices.RegisterChannel(httpChannel, true);

            SimpleIT.RemoteHello remHello =
                Activator.GetObject(typeof(SimpleIT.RemoteHello), "http://127.0.0.1:8235/RemoteHello")
                as SimpleIT.RemoteHello;

            Console.WriteLine("ClientUsingHttp(): remHello.SayHello() = " + remHello.SayHello());
        }
    }
}
