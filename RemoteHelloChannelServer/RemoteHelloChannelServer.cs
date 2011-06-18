using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

namespace SimpleIT
{
    class RemoteHelloChannelServer
    {
        static void Main(string[] args)
        {
            // http://www.codeproject.com/KB/IP/Net_Remoting.aspx
            TcpChannel tcpChannel = new TcpChannel(8234);
            HttpChannel httpChannel = new HttpChannel(8235);

            ChannelServices.RegisterChannel(tcpChannel, true);
            ChannelServices.RegisterChannel(httpChannel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteHello), "RemoteHello", WellKnownObjectMode.Singleton
            );

            Console.WriteLine("Started the server RemoteHelloServer.");
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
    }
}
