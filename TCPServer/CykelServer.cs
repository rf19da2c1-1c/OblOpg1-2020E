using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using CykelLib.model;
using Newtonsoft.Json;

namespace TCPServer
{
    public class CykelServer
    {
        private const int PORT = 4444;

        // statisk liste til data
        private readonly static List<Cykel> Cykler = new List<Cykel>()
        {
            new Cykel(1, "rød", 3400, 10),
            new Cykel(2, "sort", 2800, 3),
            new Cykel(3, "sort", 4300, 12),
            new Cykel(4, "blå", 2700, 5),
            new Cykel(5, "lyseblå", 3600, 5),
            new Cykel(6, "rød", 13400, 18),

        };


        public CykelServer()
        {
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, PORT);
            server.Start();

            while (true) // håndtere flere clienter
            {
                TcpClient socket = server.AcceptTcpClient();

                // håndtere samtidigt
                Task.Run(() =>
                    {
                        TcpClient tmpSocket = socket;
                        DoClient(socket);
                    }
                );

            }

        }

        private void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                String cmdStr = sr.ReadLine();
                String data = sr.ReadLine();

                switch (cmdStr)
                {
                    case "HentAlle":
                        String json = JsonConvert.SerializeObject(Cykler);
                        sw.WriteLine(json);
                        break;

                    case "Hent":
                        int id = Int32.Parse(data);
                        Cykel cykel = Cykler.Find(c => c.Id == id);
                        String jsonEnCykel = JsonConvert.SerializeObject(cykel);
                        sw.WriteLine(jsonEnCykel);
                        break;

                    case "Gem":
                        Cykel nyCykel = JsonConvert.DeserializeObject<Cykel>(data);
                        Cykler.Add(nyCykel);
                        break;

                    default:
                        sw.WriteLine("Ikke en tilladt kommando");
                        break;
                }


            } // med using implicit close af sr og sw

            socket?.Close();
        }
    }
}