using System;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            CykelServer server = new CykelServer();
            server.Start();

            Console.WriteLine("Press return-button to close the program");
            Console.ReadLine();
        }
    }
}
