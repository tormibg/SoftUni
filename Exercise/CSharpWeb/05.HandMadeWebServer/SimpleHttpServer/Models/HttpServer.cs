using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleHttpServer.Models
{
    public class HttpServer
    {
        public TcpListener Listener { get; private set; }

        public int Port { get; private set; }

        public bool IsActive { get; private set; }

        public HttpProcessor Processor { get; private set; }

        public HttpServer(int port, IEnumerable<Route> routes)
        {
            this.Port = port;
            this.Processor = new HttpProcessor(routes);
            this.IsActive = true;
        }

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any, this.Port);
            this.Listener.Start();

            while (this.IsActive)
            {
                Console.Write("Waiting for a connection... ");

                TcpClient client = this.Listener.AcceptTcpClient();
                Console.WriteLine("Connected!");

                Thread thread = new Thread(() => { this.Processor.HandleClient(client); });

                thread.Start();
                Thread.Sleep(1);
            }
        }
    }
}