using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace Abbey_Trading_Store.UI
{
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
        }
        Transactions Ts = new Transactions();
        

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            DataTable dt = Ts.DisplayAllTransactions();
            dgv_transactions.DataSource = dt;

        }

        private void Cateory_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = "Dealer";
            if (Cateory_combobox.Text == "Sales")
            {
                type = "Customer";

            }
            else if (Cateory_combobox.Text == "Purchase")
            {
                type = "Dealer";
            }
            DataTable dt = Ts.DisplayTransactionsBasedOnType(type);
            dgv_transactions.DataSource = dt;
        }

        private void Show_all_Click(object sender, EventArgs e)
        {
            DataTable dt = Ts.DisplayAllTransactions();
            dgv_transactions.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
