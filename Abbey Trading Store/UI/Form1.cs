using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI
{
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abbey_Trading_Store.UI.registrationForm form = new Abbey_Trading_Store.UI.registrationForm();
            form.Show();
        }

        private void Admin_dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login_form form = new Login_form();
            form.Show();
            this.Hide();
        }

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {
            
            user.Text = Login_form.user;
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts product = new frmProducts();
            product.Show();
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDealerAndCustomer D_cust = new frmDealerAndCustomer();
            D_cust.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registrationForm form = new registrationForm();
            form.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmCategory category = new frmCategory();
            category.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmProducts product = new frmProducts();
            product.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDealerAndCustomer form = new frmDealerAndCustomer();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventory form = new Inventory();
            form.Show();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransactions form = new frmTransactions();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmTransactions form = new frmTransactions();
            form.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory form = new Inventory();
            form.Show();
        }
    }
}
