using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var ipAddress = IPAddress.Parse("10.1.18.1");
            var port = 27001;

            var ep = new IPEndPoint(ipAddress, port);

            try
            {
                socket.Connect(ep);

                if (socket.Connected)
                {
                    Console.WriteLine("Connected to server . . .");
                    while (true)
                    {
                        var msg = Console.ReadLine();
                        var bytes = Encoding.UTF8.GetBytes(msg);
                        socket.Send(bytes);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can not connect to the server");
            }

        }
    }
}
