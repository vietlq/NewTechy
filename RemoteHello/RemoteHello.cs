using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleIT
{
    public class RemoteHello : MarshalByRefObject
    {
        public string SayHello()
        {
            Console.WriteLine("RemoteHello.SayHello() got called!");

            return "Hello World!";
        }
    }
}
