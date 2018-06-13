using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace EchoLogger
{
    public class Server
    {
        public static void Main()
        { 
            TcpListener server = null;   
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // the listening loop.
                while(true)
                {
                    Console.Write("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();            
                    Console.WriteLine("Connected!");
                    NetworkStream stream = client.GetStream();
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (client.Connected)
                        {
                            string line = reader.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                    client.Close();
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
      
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }   
    }
}