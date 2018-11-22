using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_race_levan
{
    class Network
    {
        NetPeerConfiguration config;
        public NetClient client { get; set; }
        public NetServer server { get; set; }

        public string MessageFromClient { get; set; }
        List<NetPeer> clients = new List<NetPeer>();

        public Network()
        {

        }

        public void StartClient()
        {
            var config = new NetPeerConfiguration("hej");
            config.AutoFlushSendQueue = false;
            client = new NetClient(config);
            client.Start();

            string ServerIp = "localhost";
            int port = 14242;
            client.Connect(ServerIp, port); // client or Server IP? 
        }

        public void StartClient(String ip)
        {
            var config = new NetPeerConfiguration("hej");
            config.AutoFlushSendQueue = false;
            client = new NetClient(config);
            client.Start();

            string ServerIp = ip;
            int port = 14242;
            client.Connect(ServerIp, port);
        }

        public void SendMessage(String msg)
        {
            NetOutgoingMessage message = client.CreateMessage(msg);
            client.SendMessage(message, NetDeliveryMethod.ReliableOrdered);
            client.FlushSendQueue();
        }


        public void StartServer()
        {
            var config = new NetPeerConfiguration("hej")
            { Port = 14242 };
            server = new NetServer(config);
            server.Start();

            if (server.Status == NetPeerStatus.Running)
            {
                Console.WriteLine("Server is running on port " + config.Port);
            }
            else
            {
                Console.WriteLine("Server not started...");
            }

        }

        public string ReadMessages() 
        {
            NetIncomingMessage message;
            while ((message = server.ReadMessage()) != null)
            {
                string data = message.ReadString();
                MessageFromClient = data;
                server.Recycle(message);
                return MessageFromClient;

            }
            server.Recycle(message);
            return "";
        }

        public string GetMessageFromClient()
        {
            Console.WriteLine("Return MSG " + MessageFromClient);
            return MessageFromClient;
        }

    }
}
