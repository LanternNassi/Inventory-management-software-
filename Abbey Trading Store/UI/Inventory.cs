using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using DGVPrinterHelper;


namespace Abbey_Trading_Store.UI
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        product product = new product();
        Categories category = new Categories();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            DataTable dt = product.select();
            dgv_Inventory.DataSource = dt;

            // adding categories to the combo box
            DataTable cdt = category.select();
            Category_combobox.DataSource = cdt;

            // adding the rows to be displayed
            Category_combobox.DisplayMember = "title";
            Category_combobox.ValueMember = "title";

        }

        private void Category_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = Category_combobox.Text;
            DataTable dt = product.DisplayProductsBasedOnCategory(category);
            dgv_Inventory.DataSource = dt;
        }

        private void Show_all_inventory_Click(object sender, EventArgs e)
        {
            DataTable dt = product.select();
            dgv_Inventory.DataSource = dt;

        }

        private void Show_all_Click(object sender, EventArgs e)
        {
            DGVPrinter Printer = new DGVPrinter();
            Printer.Title = "\r\n\r\n\r\n ABBEY TRADING STORE \r\n\r\n";
            Printer.SubTitle = "Masaka Buddu Street \r\n Phone: 0758989094\r\n\r\n";
            Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            Printer.PageNumbers = true;
            Printer.PageNumberInHeader = false;
            Printer.PorportionalColumns = false;
            Printer.HeaderCellAlignment = StringAlignment.Near;
            Printer.Footer = "\r\n\r\n Report for All Inventory";
            Printer.FooterSpacing = 15;
            Printer.PrintDataGridView(dgv_Inventory);
        }
    }
}
