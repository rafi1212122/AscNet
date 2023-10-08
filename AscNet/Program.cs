using System.Runtime.InteropServices;
using AscNet.Common.Util;

namespace AscNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.c.Log("Starting...");
            SDKServer.SDKServer.Main(args);
        }
    }
}