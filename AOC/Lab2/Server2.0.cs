using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static bool CheckWin(int[,] xo,int wxo)
        {
            for (int i = 0; i < 3; i++) if (xo[i, 0] == wxo && xo[i, 1] == wxo && xo[i, 2] == wxo) return true;
            for (int i = 0; i < 3; i++) if (xo[0, i] == wxo && xo[1, i] == wxo && xo[2, i] == wxo) return true;
            if ((xo[0, 0] == wxo && xo[1, 1] == wxo && xo[2, 2] == wxo) || (xo[0, 2] == wxo && xo[1, 1] == wxo && xo[2, 0] == wxo)) return true;
            return false;
        }

        static int port = 8005;
        static void Main(string[] args)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            int draw = 1;
            int[,] xo = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            Random rnd = new Random();

            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(9);

                Console.WriteLine("The server is running. Waiting for connections ...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];

                    void Terminal(string outStr)
                    {
                        string message = outStr;
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);

                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);


                    int cellX = Convert.ToInt32(builder.ToString());
                    int i, j;
                    xo[cellX / 10 - 1, cellX % 10 - 1] = 1;


                    if (CheckWin(xo, 1))
                    {
                        Terminal("###YOU WIN###");
                        break;
                    }
                    if (draw == 5)
                    {
                        Terminal("###DRAW###");
                        break;
                    }
                    while (true)
                    {
                        i = rnd.Next(0, 3);
                        j = rnd.Next(0, 3);
                        if (xo[i, j] == 0)
                        {
                            xo[i, j] = 2;
                            break;
                        }
                    }
                    if (CheckWin(xo, 2))
                    {
                        Terminal("###YOU WIN###");
                        break;
                    }
                    draw++;
                    Terminal(Convert.ToString(i+1)+ Convert.ToString(j+1));   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}