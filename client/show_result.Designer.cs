
namespace client
{
    partial class show_result
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.search_string = new Guna.UI2.WinForms.Guna2TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(474, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search";
            // 
            // search_string
            // 
            this.search_string.BorderColor = System.Drawing.Color.Black;
            this.search_string.BorderRadius = 11;
            this.search_string.BorderThickness = 2;
            this.search_string.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search_string.DefaultText = "";
            this.search_string.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.search_string.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.search_string.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_string.DisabledState.Parent = this.search_string;
            this.search_string.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.search_string.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search_string.FocusedState.Parent = this.search_string;
            this.search_string.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.search_string.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.search_string.HoverState.Parent = this.search_string;
            this.search_string.Location = new System.Drawing.Point(554, 46);
            this.search_string.Name = "search_string";
            this.search_string.PasswordChar = '\0';
            this.search_string.PlaceholderForeColor = System.Drawing.Color.Black;
            this.search_string.PlaceholderText = "";
            this.search_string.SelectedText = "";
            this.search_string.ShadowDecoration.Parent = this.search_string;
            this.search_string.Size = new System.Drawing.Size(133, 36);
            this.search_string.TabIndex = 37;
            this.search_string.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightCoral;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.cn,
            this.ddt,
            this.hp,
            this.tv});
            this.dataGridView1.Location = new System.Drawing.Point(46, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(683, 344);
            this.dataGridView1.TabIndex = 38;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Width = 90;
            // 
            // name
            // 
            this.name.HeaderText = "Quốc Gia";
            this.name.Name = "name";
            this.name.Width = 150;
            // 
            // cn
            // 
            this.cn.HeaderText = "Ca Nhiễm";
            this.cn.Name = "cn";
            // 
            // ddt
            // 
            this.ddt.HeaderText = "Đang Điều Trị";
            this.ddt.Name = "ddt";
            // 
            // hp
            // 
            this.hp.HeaderText = "Hồi Phục";
            this.hp.Name = "hp";
            // 
            // tv
            // 
            this.tv.HeaderText = "Tử Vong";
            this.tv.Name = "tv";
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.BorderThickness = 2;
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.CheckedState.Parent = this.guna2DateTimePicker1;
            this.guna2DateTimePicker1.CustomFormat = "yyyy-MMM-dd";
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker1.HoverState.Parent = this.guna2DateTimePicker1;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(46, 33);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.ShadowDecoration.Parent = this.guna2DateTimePicker1;
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(215, 36);
            this.guna2DateTimePicker1.TabIndex = 39;
            this.guna2DateTimePicker1.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 11;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.DisabledState.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.Cyan;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Image = global::client.Properties.Resources.searching;
            this.guna2Button2.Location = new System.Drawing.Point(693, 46);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(44, 35);
            this.guna2Button2.TabIndex = 9;
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // show_result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(771, 487);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.search_string);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.label2);
            this.Name = "show_result";
            this.Text = "show_result";
            this.Load += new System.EventHandler(this.show_result_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox search_string;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddt;
        private System.Windows.Forms.DataGridViewTextBoxColumn hp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tv;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
    }
}