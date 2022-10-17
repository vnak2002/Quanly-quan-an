using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_quan_an
{
    public partial class Main : Form
    {
        private Form activeForm = null;
        public void FormLoad(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(childForm);
            childForm.Visible = true;
        }
        public Main()
        {
            InitializeComponent();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad(new Account());
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad(new Income());
        }

        private void thựcĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad(new FoodMenu());
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad(new Category());
        }

        private void bànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad(new Table());
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad(new AccounProfile());
            AccounProfile acc = new AccounProfile();
            
            
        }
    }
}
