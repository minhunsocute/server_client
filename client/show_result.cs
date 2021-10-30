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
    public partial class show_result : Form
    {
        IPEndPoint IP;
        Socket client;
        public show_result()
        {
            InitializeComponent();
            connect();
        }
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
                MessageBox.Show("Cannot connect to server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Thread listen = new Thread(receive);
            listen.IsBackground = true;
            listen.Start();
        }
        private void LoadData(int h,string check_string)
        {
            List<result> resultList = resultInstance.Instance.load(h,check_string);
            int i = 0;
            /*DataGridViewRow rowFirst = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            rowFirst.Cells[0].Value = "ID";
            rowFirst.Cells[1].Value = "Quốc Gia";
            rowFirst.Cells[2].Value = "Ca Nhiễm";
            rowFirst.Cells[3].Value = "Đang Điều Trị";
            rowFirst.Cells[4].Value = "Hồi Phục";
            rowFirst.Cells[5].Value = "Tử Vong";*/
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (result item in resultList)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = item.ID.ToString();
                row.Cells[1].Value = item.Name;
                row.Cells[2].Value = item.Cn.ToString();
                row.Cells[3].Value = item.Ddt.ToString();
                row.Cells[4].Value = item.Hp.ToString();
                row.Cells[5].Value = item.Tv.ToString();
                dataGridView1.Rows.Add(row);
            }

            dataGridView1.Columns["id"].DefaultCellStyle.BackColor = Color.Cyan;
            dataGridView1.Columns["name"].DefaultCellStyle.BackColor = Color.Cyan;
            dataGridView1.Columns["ddt"].DefaultCellStyle.BackColor = Color.Cyan;
            dataGridView1.Columns["tv"].DefaultCellStyle.BackColor = Color.Cyan;
            dataGridView1.Columns["cn"].DefaultCellStyle.BackColor = Color.Cyan;
            dataGridView1.Columns["hp"].DefaultCellStyle.BackColor = Color.Cyan;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 88, 255);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
        }
        void receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string messaga = (string)Deserialize(data);
                    if (messaga.Contains("1.show")){

                    }
                    else if (messaga.Contains("show2") == true)
                    {
                        LoadData(6, messaga);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Server is out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void show_result_Load(object sender, EventArgs e)
        {
            LoadData(11,Client.data_ofTable);
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
        private void searchString(string values)
        {
            
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string send_string = "show2*";
            send_string += search_string.Text.ToString() + "|";
            send_string += guna2DateTimePicker1.Text.ToString();
            client.Send(Serialize(send_string));
        }
    }
}
