using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

namespace SimpleIT
{
    public class Utils
    {
        public static int RandomPort()
        {
            Random randGen = new Random((int)(DateTime.UtcNow.Ticks));
            int randomPort = (randGen.Next() % (65536 - 1024)) + 1024;

            return randomPort;
        }

        public static void RandomTcpChannel(out TcpChannel tcpChannel)
        {
            bool isClientOn = false;

            tcpChannel = null;

            while (false == isClientOn)
            {
                try
                {
                    // http://stackoverflow.com/questions/839577/the-channel-tcp-is-already-registered
                    IDictionary props = new Hashtable();

                    props["port"] = RandomPort();
                    props["name"] = Guid.NewGuid().ToString();

                    tcpChannel = new TcpChannel(props, null, null);

                    isClientOn = true;
                }
                catch (Exception e)
                {
                    isClientOn = false;
                    Console.WriteLine("Error creating new TcpChannel: " + e.Message);
                }
            }
        }

        public static TcpChannel RandomTcpChannel()
        {
            TcpChannel tcpChannel = null;

            RandomTcpChannel(out tcpChannel);

            return tcpChannel;
        }
    }
}
