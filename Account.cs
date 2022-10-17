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


namespace Quan_ly_quan_an
{
    public partial class Account : Form
    {
        SqlConnection Connection;
        SqlCommand Command;
        String str = @"Data Source=LAPTOP-TV4TO026\HAOADULOVE;Initial Catalog=QLQA;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            Command = Connection.CreateCommand();
            Command.CommandText = "select [Tên đăng nhập],[Tên hiển thị],[Loại tài khoản] from [Tài khoản]";
            adapter.SelectCommand = Command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Account()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Connection = new SqlConnection(str);
            Connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Thiếu thông tin", " thông báo", MessageBoxButtons.OK);
                }
                else
                {

                    Command = Connection.CreateCommand();
                    Command.CommandText = "insert into [Tài khoản]([Tên đăng nhập],[Tên hiển thị],[Loại tài khoản]) values('" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + comboBox1.Text + "')";
                    Command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Thêm thành công", " thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Command = Connection.CreateCommand();
                    Command.CommandText = "delete from [Tài khoản] where [Tên đăng nhập] = '" + textBox1.Text + "'";
                    Command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Xóa thành công", " thông báo", MessageBoxButtons.OK);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Command = Connection.CreateCommand();
            Command.CommandText = "update [Tài khoản] set [Tên hiển thị] = N'" + textBox2.Text + "',[Loại tài khoản] = N'" + comboBox1.Text + "' where [Tên đăng nhập] = '" + textBox1.Text + "'";
            Command.ExecuteNonQuery();
        }
    }
}
