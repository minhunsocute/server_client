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
using System.Data.SqlClient;

namespace server
{
    public partial class Server : Form
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=socket_account;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            connect();
        }
        void connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 1111);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);
            Thread Listen = new Thread(()=>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);

                        Thread rec = new Thread(receive);
                        rec.IsBackground = true;
                        rec.Start(client);
                    }
                }
                catch {
                    IP = new IPEndPoint(IPAddress.Any, 1111);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        void send(Socket cliet)
        {
            if (!string.IsNullOrEmpty(userName.Text))
            {
                cliet.Send(Serialize(userName.Text));
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Socket item in clientList)
                {
                    send(item);
                }
                userName.Clear();
            }
            catch
            {
                MessageBox.Show("Don't connect to client", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void addMessage(string messaga)
        {
            listBox1.Items.Add(new ListViewItem() { Text = messaga });
        }
        void close()
        {
            server.Close();
        }
        void sendResultLogin(string user_pas)
        {

        }
        //check username and password is correct in database
        int checkStringInData(string user,string pass)
        {
            try
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString = "SELECT * FROM account";
                myAdapter = new SqlDataAdapter(sqlString, conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "username");
                dt = ds.Tables["username"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["username"].ToString() == user && dt.Rows[i]["pass"].ToString() == pass)
                        return -1;
                }
                conn.Open();
            }
            catch { }
            //catch { MessageBox.Show("Cannot open database", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error); }
            return 0;
        }
        void check_stringAndSign_up(string user,string pass,Socket client)
        {
            try
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString = "SELECT COUNT(*) FROM account WHERE username = '"+user+"'";
                comm = new SqlCommand(sqlString, conn);
                Int32 count = (Int32)comm.ExecuteScalar();
                listBox1.Items.Add(count.ToString());
                if (count != 0)
                {
                    //MessageBox.Show("Username is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    client.Send(Serialize("Invalid"));
                }
                else
                {
                    //MessageBox.Show("Sign up is success", "OK", MessageBoxButtons.OK);
                    string sqlString1 = "INSERT INTO account VALUES ('" + user + "','" + pass + "')";
                    comm = new SqlCommand(sqlString1, conn);
                    comm.ExecuteNonQuery();
                    client.Send(Serialize("Success"));
                }
                conn.Close();
            }
            catch { }
        }
        string bult_string(DataTable dt,string header)
        {
            string result = "";
            result += header;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string check_null = "";
                result += dt.Rows[i]["id"].ToString() + "|";
                result += dt.Rows[i]["name_country"].ToString() + "|";
                check_null = dt.Rows[i]["sum_cn"].ToString();
                if (check_null != "")
                {   
                    result += dt.Rows[i]["sum_cn"].ToString() + "|";
                }
                else
                    result += "0" + "|";
                check_null = "";
                check_null += dt.Rows[i]["sum_ddt"].ToString();
                if (check_null != "")
                    result += check_null + "|";
                else
                    result += "0" + "|";
                check_null = "";
                check_null += dt.Rows[i]["sum_hp"].ToString();
                if (check_null != "")
                    result += check_null + "|";
                else
                    result += "0" + "|";
                check_null = "";
                check_null += dt.Rows[i]["sum_tv"].ToString();
                if (check_null != "")
                    result += check_null + "*";
                else
                    result += "0" + "*";
            }
            return result;
        }
        void checkString(string string_check,Socket client)
        {
            Boolean check = string_check.Contains("check_login");
            if (string_check.Contains("check_login") == true )
            {
                //MessageBox.Show("Success", "OK", MessageBoxButtons.OK);
                sendResultLogin(string_check);

                int n = 0;
                for(int i = 12; i < string_check.Length; i++)
                {
                    if (string_check[i] == '*') break;
                    n++;
                }
                string user = "";
                string pass = "";
                for (int i = 12; i < 12+n; i++)
                    user += string_check[i];
                for (int i = 12 + n + 1; i < string_check.Length-1; i++)
                    pass += string_check[i];
                listBox1.Items.Add(user);
                listBox1.Items.Add(pass);
                if (checkStringInData(user,pass)==-1)
                {
                    //MessageBox.Show("Successs", "OK", MessageBoxButtons.OK);
                    conn = new SqlConnection(conStr);
                    conn.Open();
                    string sqlString = "exec select_allresult";
                    myAdapter = new SqlDataAdapter(sqlString, conn);
                    ds = new DataSet();
                    myAdapter.Fill(ds, "id");
                    dt = ds.Tables["id"];
                    string send_result = bult_string(dt, "All_result*");
                    listBox1.Items.Add(send_result);
                    conn.Close();
                    client.Send(Serialize(send_result));
                }
                else
                {
                    //MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    client.Send(Serialize("Invalid"));
                }
            }
            else if (string_check.Contains("Sign_up") == true)
            {
                int n = 0;
                for(int i = 7; i < string_check.Length; i++)
                {
                    if (string_check[i] == '*')
                        break;
                    n++;
                }

                string user = "";
                string pass = "";
                for (int i = 7; i < 7 + n; i++)
                    user += string_check[i];
                for (int i = 7 + n+1; i < string_check.Length; i++)
                    pass += string_check[i];
                listBox1.Items.Add(user);
                listBox1.Items.Add(pass);
                check_stringAndSign_up(user, pass,client);
            }
            else if (string_check.Contains("All_result") == true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString = "exec select_allresult";
                myAdapter = new SqlDataAdapter(sqlString,conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "id");
                dt = ds.Tables["id"];
                string send_result = bult_string(dt, "All_result*");
                listBox1.Items.Add(send_result);
                conn.Close();
            }
            else if (string_check.Contains("show2") == true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                int i = 6;
                string name = "";
                while (string_check[i] !='|')
                {
                    name += string_check[i];
                    i++;
                }
                i++;
                string date_time = "";
                for (; i < string_check.Length; i++)
                {
                    date_time += string_check[i];
                }
                string sqlString = "exec select_result N'"+name+"','"+date_time+"'";
                myAdapter = new SqlDataAdapter(sqlString, conn);
                ds = new DataSet();
                myAdapter.Fill(ds, "id");
                dt = ds.Tables["id"];
                string send_result = bult_string(dt,"show2*");
                listBox1.Items.Add(name + " " + date_time + " " + send_result);
                client.Send(Serialize(send_result));
                conn.Close();
            }
        }
        void receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string messaga = (string)Deserialize(data);
                    /*if(messaga== "check_login")
                    {
                        string user = "";string pass = "";
                        for(int i = 0; i < 2; i++)
                        {
                            byte[] data1 = new byte[1024 * 5000];
                            client.Receive(data1);
                            string mess = (string)Deserialize(data1);
                            if (i == 0) user = mess;
                            else if (i == 1)
                                pass = mess;
                        }
                        if (check_loign(user, pass) == -1)
                            MessageBox.Show("Success", "OK", MessageBoxButtons.OK);
                        else
                            MessageBox.Show("Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/
                    checkString(messaga,client);
                    addMessage(messaga);
                }
            }
            catch
            {
                userName.Text = "Wait for Client";
            }
        }
        //phan manh 
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);
            return stream.ToArray();// stream tra ra 1 day byte
        }
        // gom manh
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            change_result f = new change_result();
            f.ShowDialog();
        }
    }
}
