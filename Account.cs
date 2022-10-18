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
        String str = @"Data Source=AESIR\SQLEXPRESS08;Initial Catalog=QLQA;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            Command = Connection.CreateCommand();
            Command.CommandText = "select [Tên đăng nhập],[Tên hiển thị],[Loại tài khoản] from [Tài khoản]";
            adapter.SelectCommand = Command;
            table.Clear();
            adapter.Fill(table);
            dgvAccount.DataSource = table;
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
            i = dgvAccount.CurrentRow.Index;
            txbUserName.Text = dgvAccount.Rows[i].Cells[0].Value.ToString();
            txbDisplayName.Text = dgvAccount.Rows[i].Cells[1].Value.ToString();
            cmbAccountType.Text = dgvAccount.Rows[i].Cells[2].Value.ToString();
        }

       

       

        

        private void Account_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLQADataSet.Tài_khoản' table. You can move, or remove it, as needed.
            this.tài_khoảnTableAdapter.Fill(this.qLQADataSet.Tài_khoản);
            Connection = new SqlConnection(str);
            Connection.Open();
            loaddata();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txbUserName.Text == "" || txbDisplayName.Text == "")
                {
                    MessageBox.Show("Thiếu thông tin", " thông báo", MessageBoxButtons.OK);
                }
                else
                {

                    Command = Connection.CreateCommand();
                    Command.CommandText = "insert into [Tài khoản]([Tên đăng nhập],[Tên hiển thị],[Loại tài khoản]) values('" + txbUserName.Text + "',N'" + txbDisplayName.Text + "',N'" + cmbAccountType.Text + "')";
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "YES/NO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Command = Connection.CreateCommand();
                    Command.CommandText = "delete from [Tài khoản] where [Tên đăng nhập] = '" + txbUserName.Text + "'";
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Command = Connection.CreateCommand();
            Command.CommandText = "update [Tài khoản] set [Tên hiển thị] = N'" + txbDisplayName.Text + "',[Loại tài khoản] = N'" + cmbAccountType.Text + "' where [Tên đăng nhập] = '" + txbUserName.Text + "'";
            Command.ExecuteNonQuery();
        }
    }
}