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
    public partial class Client : Form
    {
        public static string data_ofTable = "";
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            send();
            addMessage(userName.Text);
        }
        /*
         * socket
         * ip
         * 
         */

        IPEndPoint IP;
        private static Socket client;
        
        //send byte
        void connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("192.168.56.1"), 1111);
            client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.IP);

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
            if (!string.IsNullOrEmpty(userName.Text)) {
                client.Send(Serialize(userName.Text));
            }
        } 
        void return_dataStringForResult(string message)
        {
            data_ofTable = "";
            //client.Send(Serialize("All_result"));
            data_ofTable = message;
            listBox1.Items.Add(data_ofTable);
        }
        void recevie()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string messaga = (string)Deserialize(data);
                    if(messaga.Contains("All_result") ==true)
                    {
                        return_dataStringForResult(messaga);
                        //listBox1.Items.Add(messaga);
                        //userName.Clear();
                        //guna2TextBox1.Clear();
                        show_result f = new show_result();
                        f.ShowDialog();
                    }
                    else if(messaga == "Invalid")
                    {
                        MessageBox.Show("Username or password is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //addMessage(messaga);
                }
            }
            catch
            {
                MessageBox.Show("Server is out", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();
            }
        }
        void addMessage(string messaga)
        {
            listBox1.Items.Add(new ListViewItem() { Text = messaga });
            userName.Clear();
        }
        void close()
        {
            client.Close();
        }
        //phan manh 
        public static byte[] Serialize(object obj) {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();  

            formatter.Serialize(stream, obj);
            return stream.ToArray();// stream tra ra 1 day byte
        }
        // gom manh
        public static object Deserialize(byte[] data) {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }
        void send_list(List<string> send_list)
        {
            foreach (string item in send_list)
            {
                client.Send(Client.Serialize(item));
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                List<string> send_listString = new List<string>();
                send_listString.Add("check_login");
                send_listString.Add(userName.Text);
                send_listString.Add(guna2TextBox1.Text);
                string s = "";
                foreach (string item in send_listString)
                {
                    s += item;
                    s+="*";
                }
                client.Send(Serialize(s));
            }
            else
            {
                MessageBox.Show("Username or Pass is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userName.Clear();
                guna2TextBox1.Clear();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            create_newAccount f = new create_newAccount();
            f.ShowDialog();
        }
    }
}
