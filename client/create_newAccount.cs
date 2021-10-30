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
    public partial class create_newAccount : Form
    {
        IPEndPoint IP;
        Socket client;

        void connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("192.168.56.1"), 1111);
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
        void recevie()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);
                    if (message == "Invalid")
                    {
                        MessageBox.Show("Sign up is faild", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (message == "Success")
                        MessageBox.Show("Sign up is success", "OK", MessageBoxButtons.OK);
                }
            }
            catch
            {
                Close();
            }
        }
        public create_newAccount()
        {
            InitializeComponent();
            connect();
        }
        public static byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
            return stream.ToArray();// stream tra ra 1 day byte
        }
        // gom manh
        public static object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(pass.Text) && !string.IsNullOrEmpty(re_pass.Text))
            {
                if (pass.Text.ToString() == re_pass.Text.ToString())
                {
                    string send_string = "";
                    send_string = "Sign_up" + userName.Text.ToString() + "*" + pass.Text.ToString();
                    client.Send(Serialize(send_string));
                }
                else
                    MessageBox.Show("Re_pass and Pass is not same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("String input is null or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
