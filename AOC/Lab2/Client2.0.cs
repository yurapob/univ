using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static bool CheckCell(int c,ref int[] cc)
        {
            
            for (int i = 0; i < 9; i++)
            {
                if (c == cc[i])
                {
                    cc[i] = 0;
                    return true;
                }
            }
            return false;
        }
        static int port = 8005;
        static string address = "127.0.0.1";
        static void Main(string[] args)
        {
            int[] cc = new int[9] { 11, 12, 13, 21, 22, 23, 31, 32, 33 };
            string[,] xo = new string[5, 5] { {"   ","|","   ","|","   "},
                                              {"---","|","---","|","---"},
                                              {"   ","|","   ","|","   "},
                                              {"---","|","---","|","---"},
                                              {"   ","|","   ","|","   "}};


            Console.WriteLine("#EXAMPLE" + "\n" +
                              "#To select the cell that is in the first row and in the second column, write 12" + "\n" +
                              "#[ROW][COLUMN]" + "\n");

            try
            {
                while (true)
                {
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipPoint);

                    string message;
                    int cellX;
                    while (true)
                    {
                        Console.Write("Select a cell: ");
                        message = Console.ReadLine();
                        if (!int.TryParse(message, out cellX)) Console.WriteLine("Error, please try again!");
                        else
                        {
                            cellX = Convert.ToInt32(message);
                            if (!CheckCell(cellX,ref cc)) Console.WriteLine("Error, please try again!");
                            else break;
                        }
                    }

                    xo[2 * (cellX / 10 - 1), 2 * (cellX % 10 - 1)] = " x ";
                    void XO()
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Console.Write(xo[i, j]);
                            }
                            Console.WriteLine();
                        }
                    }
                    XO();
                    
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);
                   
                    data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);


                    int cellO;
                    if (!int.TryParse(builder.ToString(), out cellO))
                    {
                        Console.WriteLine(builder.ToString());
                        break;
                    }
                    cellO = Convert.ToInt32(builder.ToString());
                    Console.WriteLine("Server response: " + cellO + "\n");
                    CheckCell(cellO,ref cc);
                    xo[2 * (cellO / 10 - 1), 2 * (cellO % 10 - 1)] = " o ";
                    XO();


                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
