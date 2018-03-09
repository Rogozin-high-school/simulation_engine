using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SatProt
{
    class Server
    {
        public Action<InMsg> MessageHandler;
        public Action<TcpClient> OnClientConnected;

        public int Port;
        bool _Work;

        UdpClient client;

        public Server(int port)
        {
            Port = port;
        }

        public void Stop()
        {
            _Work = false;
        }

        // public void Send(byte[] b)
        // {
        //     client.GetStream().Write(b, 0, b.Length);
        // }

        public void Start()
        {
            _Work = true;

            while (_Work)
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 14944);
                client = new UdpClient(ipep);
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

                byte[] data = client.Receive(ref sender);

                InMsg msg = new InMsg(data, 4);
                MessageHandler(msg);

                client.Close();
            }          
        }
    }
}
