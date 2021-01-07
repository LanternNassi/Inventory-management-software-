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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void clear()
        {
            id.Text = "";
            name.Text = "";
            category_comboBox1.Text = "";
            description.Text = "";
            rate.Text = "";

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            // Values of the category combo box
            Categories category = new Categories();
            category_comboBox1.DataSource = category.select();
            // Specifying value in combobox
            category_comboBox1.DisplayMember = "title";
            category_comboBox1.ValueMember = "title";
            //Loading the datatable
            product product = new product();
            DataTable dt = product.select();
            dgv_product.DataSource = dt;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            product product = new product();
            product.products = name.Text;
            product.Category = category_comboBox1.Text;
            product.Description = description.Text;
            product.Rate = decimal.Parse(rate.Text);
            product.Quantity = 0;
            product.Added_by = Login_form.user;
            try
            {
                bool check = product.add();
                if (check == true)
                {
                    MessageBox.Show("Product successfully inserted");
                    clear();

                }
                else
                {
                    MessageBox.Show("An error occured. Please check your entries");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                DataTable dt = product.select();
                dgv_product.DataSource = dt;
            }
        }

        private void dgv_product_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            id.Text = dgv_product.Rows[row].Cells[0].Value.ToString();
            name.Text = dgv_product.Rows[row].Cells[1].Value.ToString();
            category_comboBox1.Text = dgv_product.Rows[row].Cells[2].Value.ToString();
            description.Text = dgv_product.Rows[row].Cells[3].Value.ToString();
            rate.Text = dgv_product.Rows[row].Cells[4].Value.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            product product = new product();
            product.Id = Convert.ToInt32(id.Text);
            product.products = name.Text;
            product.Category = category_comboBox1.Text;
            product.Description = description.Text;
            product.Rate = decimal.Parse(rate.Text);
            product.Added_by = Login_form.user;
            bool check = product.update();
            if (check == true)
            {
                MessageBox.Show(name.Text+" successfully updated.");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to update "+name.Text+" .Please check your entries");
            }
            DataTable dt = product.select();
            dgv_product.DataSource = dt;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            product product = new product();
            DataTable dt = product.search(keyword);
            dgv_product.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            product product = new product();
            product.Id = Convert.ToInt32(id.Text);
            bool check = product.delete();
            if (check == true)
            {
                MessageBox.Show(name.Text + " successfully deleted.");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to delete " + name.Text + ".");
            }
            DataTable dt = product.select();
            dgv_product.DataSource = dt;
        }
    }
}
