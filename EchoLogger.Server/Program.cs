﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace EchoLogger
{
    public class Server
    {
        public static void Main()
        { 
            TcpListener server=null;   
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
      
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();
         
                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data;

                // Enter the listening loop.
                while(true)
                {
                    Console.Write("Waiting for a connection... ");
        
                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
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
         
                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

      
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }   
    }
}