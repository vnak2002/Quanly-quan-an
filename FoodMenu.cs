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
    public partial class FoodMenu : Form
    {
        SqlConnection Connection;
        SqlCommand Command;
        String str = @"Data Source=LAPTOP-TV4TO026\HAOADULOVE;Initial Catalog=ThueVanPhong;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            Command = Connection.CreateCommand();
            Command.CommandText = "select * from [Món ăn]";
            adapter.SelectCommand = Command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public FoodMenu()
        {
            InitializeComponent();
        }

        private void pnFoodMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FoodMenu_Load(object sender, EventArgs e)
        {
            SqlConnection Connection;
            SqlCommand Command;
            String str = @"Data Source=LAPTOP-TV4TO026\HAOADULOVE;Initial Catalog=ThueVanPhong;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            void loaddata()
            {
                Command = Connection.CreateCommand();
                Command.CommandText = "select * from [Món ăn]";
                adapter.SelectCommand = Command;
                table.Clear();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Thiếu thông tin", " thông báo", MessageBoxButtons.OK);
                }
                else
                {

                    Command = Connection.CreateCommand();
                    Command.CommandText = "insert into [Món ăn] values(N'" + textBox1.Text + "',N'" + textBox4.Text + "',N'" + textBox2.Text + "',N'" + comboBox1.Text + "')";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Command = Connection.CreateCommand();
                    Command.CommandText = "delete from [Món ăn] where [Mã món ăn] = '" + textBox1.Text + "'";
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Command = Connection.CreateCommand();
            Command.CommandText = "update [Món ăn] set [Tên món] = N'" + textBox4.Text + "',[Giá] = N'" + textBox2.Text + "',[Mã loại món ăn] = '" + comboBox1.Text + "' where MaThietBi = '" + textBox1.Text + "'";
            Command.ExecuteNonQuery();
            loaddata();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "[Món ăn]", "*" + comboBox1.Text + "*");
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
    }
}
