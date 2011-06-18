using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

namespace SimpleIT
{
    class RemoteHelloServer
    {
        [STAThread]
        static void Main(string[] args)
        {
            // http://www.murrayhilltech.com/articles/articles.aspx?key=2
            RemotingConfiguration.Configure("RemoteHelloServer.exe.config", true);

            Console.WriteLine("Started the server RemoteHelloServer.");
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
    }
}
