using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace server
{
    public partial class change_result : Form
    {
        private string conStr = @"Data Source=LAPTOP-DI57MUOG;Initial Catalog=socket_account;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter myAdapter;
        private SqlCommand comm;
        private DataSet ds;
        private DataTable dt;

        private SqlDataAdapter myAdapter1;
        private DataSet ds1;
        private DataTable dt1;

        public change_result()
        {
            InitializeComponent();
        }

        private void change_result_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGridView();
            LoadComboBox();
        }
        private void LoadData()
        {
            DateTime today = DateTime.Today;
            datetime.Text = today.ToString("yyyy-MMM-dd");
        }
        private void LoadGridView()
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "exec select_result N'','"+guna2DateTimePicker1.Text+"'";
            myAdapter = new SqlDataAdapter(sqlString, conn);
            ds = new DataSet();
            myAdapter.Fill(ds, "id");
            dt = ds.Tables["id"];
            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }
        
        private void LoadComboBox()
        {
            guna2ComboBox1.Items.Clear();
            guna2ComboBox1.Refresh();
            List<string> temp_string = new List<string>();
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "exec select_allresult";
            myAdapter1 = new SqlDataAdapter(sqlString, conn);
            ds1 = new DataSet();
            myAdapter1.Fill(ds1, "id");
            dt1 = ds1.Tables["id"];
            for(int i = 0; i < dt1.Rows.Count; i++)
            {
                string temp = dt1.Rows[i]["name_country"].ToString();
                temp_string.Add(temp);
            }

            foreach(string item in temp_string)
            {
                guna2ComboBox1.Items.Add(item);
            }
            guna2ComboBox1.Text = dt1.Rows[0]["name_country"].ToString();
            conn.Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(add_country.Text))
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                string sqlString = "insert into country (name_country) values (N'" +add_country.Text.ToString()+"')";
                comm = new SqlCommand(sqlString, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                LoadComboBox();LoadGridView();
                add_country.Clear();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sqlString = "exec insert_intoCovidTable N'"+guna2ComboBox1.Text.ToString()+"',"+cn_text.Value.ToString()+","+dt_text.Value.ToString()+","+hp_text.Value.ToString()+","+tv_text.Value.ToString();
            comm = new SqlCommand(sqlString, conn);
            comm.ExecuteNonQuery();
            LoadGridView();
            conn.Close();
        }
    }
}
