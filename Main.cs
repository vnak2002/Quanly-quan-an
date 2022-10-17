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
        public Main()
        {
            InitializeComponent();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account account = new Account() {  TopLevel = false, TopMost = true };
            panel1.Controls.Add(account);
            account.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Income income = new Income() { TopLevel = false, TopMost = true };
            panel1.Controls.Add((income));
            income.Show();
        }
    }
}
