using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace client
{
    public partial class login : Form
    {
        IPEndPoint IP;
        Socket client;
        public login()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
        }

        void connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("192.168.56.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Cannot connect to server", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Thread listen = new Thread(recevie);
            listen.IsBackground = true;
            listen.Start();
        }
        void send()
        {
            if (!string.IsNullOrEmpty(userName.Text))
            {
                client.Send(Client.Serialize(userName.Text));
            }
        }
        void send_listString(List<string> send_list)
        {
            foreach(string item in send_list)
            {
                client.Send(Client.Serialize(item));
            }
        }
        void recevie()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string messaga = (string)Client.Deserialize(data);
                }
            }
            catch
            {
                Close();
            }
        }
        
        void close()
        {
            client.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                List<string> send_listString = new List<string>();
                send_listString.Add("check_login");
                send_listString.Add(userName.Text);
                send_listString.Add(userName.Text);
            }
            else
            {
                MessageBox.Show("Username or Pass is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
