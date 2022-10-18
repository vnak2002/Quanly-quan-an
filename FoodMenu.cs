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
        String str = @"Data Source=AESIR\SQLEXPRESS08;Initial Catalog=QLQA;Integrated Security=True";
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

        private void FoodMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLQADataSet2.Món_ăn' table. You can move, or remove it, as needed.
            //this.món_ănTableAdapter2.Fill(this.qLQADataSet2.Món_ăn);
            // TODO: This line of code loads data into the 'qLQADataSet1.Món_ăn' table. You can move, or remove it, as needed.
            //this.món_ănTableAdapter1.Fill(this.qLQADataSet1.Món_ăn);
            //this.món_ănTableAdapter.Fill(this.qLQADataSet.Món_ăn);
            Connection = new SqlConnection(str);
            Connection.Open();
            loaddata();
            //cbCategory.SelectedIndex = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dataGridView1.CurrentRow.Index;
            txtID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtFoodName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cbCategory.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "" || txtFoodName.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("Thiếu thông tin", " thông báo", MessageBoxButtons.OK);
                }
                else
                {

                    Command = Connection.CreateCommand();
                    Command.CommandText = "insert into [Món ăn] values('" + txtID.Text + "',N'" + txtFoodName.Text + "',N'" + cbCategory.Text + "','" + txtPrice.Text + "')";
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
                    Command.CommandText = "delete from [Món ăn] where [Mã món ăn] = '" + txtID.Text + "'";
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
            Command.CommandText = "update [Món ăn] set [Tên món ăn] = N'" + txtFoodName.Text + "',[Giá] = '" + txtPrice.Text + "',[Loại món ăn] = N'" + cbCategory.Text + "' where [Mã món ăn] = '" + txtID.Text + "'";
            Command.ExecuteNonQuery();
            loaddata();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "[Tên món ăn]", "*" + txbSearch.Text + "*");
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }
    }
}