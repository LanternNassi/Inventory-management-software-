using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;

namespace Abbey_Trading_Store.UI
{
    public partial class frmDealerAndCustomer : Form
    {
        public frmDealerAndCustomer()
        {
            InitializeComponent();
        }

        private void clear()
        {
            id.Text = "";
            name.Text = "";
            email.Text = "";
            contact.Text = "";
            address.Text = "";
            type_comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmDealerAndCustomer_Load(object sender, EventArgs e)
        {
            DealerAndCustomer D_cust = new DealerAndCustomer();
            DataTable dt = D_cust.Select();
            dgv_dcust.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DealerAndCustomer DC = new DealerAndCustomer();
            //DC.Id = Convert.ToInt32(id.Text);
            DC.Type = type_comboBox1.Text;
            DC.Name = name.Text;
            DC.Email = email.Text;
            DC.Contact = contact.Text;
            DC.Address = address.Text;
            DC.Added_by = Login_form.user;
            bool check = DC.Insert();
            if (check == true)
            {
                MessageBox.Show(name.Text + " successfully added.");
                clear();
                DataTable dt = DC.Select();
                dgv_dcust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to add " + name.Text);
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox6.Text;
            DealerAndCustomer DC = new DealerAndCustomer();
            DataTable dt = DC.Search(keyword);
            dgv_dcust.DataSource = dt;
        }

        private void dgv_dcust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            id.Text = dgv_dcust.Rows[row].Cells[0].Value.ToString();
            type_comboBox1.Text = dgv_dcust.Rows[row].Cells[1].Value.ToString();
            name.Text = dgv_dcust.Rows[row].Cells[2].Value.ToString();
            email.Text = dgv_dcust.Rows[row].Cells[3].Value.ToString();
            contact.Text = dgv_dcust.Rows[row].Cells[4].Value.ToString();
            address.Text = dgv_dcust.Rows[row].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DealerAndCustomer DC = new DealerAndCustomer();
            DC.Id = Convert.ToInt32(id.Text);
            DC.Type = type_comboBox1.Text;
            DC.Name = name.Text;
            DC.Email = email.Text;
            DC.Contact = contact.Text;
            DC.Address = address.Text;
            bool check = DC.Update();
            if (check == true)
            {
                DataTable dt = DC.Select();
                dgv_dcust.DataSource = dt;
                MessageBox.Show(name.Text + " successfully updated.");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to update" + name.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DealerAndCustomer DC = new DealerAndCustomer();
            DC.Id = Convert.ToInt32(id.Text);
            bool check = DC.Delete();
            if (check == true)
            {
                
                DataTable dt = DC.Select();
                dgv_dcust.DataSource = dt;
                MessageBox.Show(name.Text + " successfully deleted.");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to delete " + name.Text);
            }

        }
    }
}
