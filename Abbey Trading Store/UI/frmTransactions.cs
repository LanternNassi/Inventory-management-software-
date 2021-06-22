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
using DGVPrinterHelper;


namespace Abbey_Trading_Store.UI
{
    public partial class frmTransactions : Form
    {
        public frmTransactions()
        {
            InitializeComponent();
        }
        Transactions Ts = new Transactions();
        public static string lblName;
        public static DateTime date;
        DataTable flexible = new DataTable();

        
        

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            DataTable dt = Ts.DisplayAllTransactions();         
            flexible = dt;
            dgv_transactions.DataSource = dt;
            int total_holder = 0;
            int profit_holder = 0;
            for (int i = 0; (i <= flexible.Rows.Count - 1); i++)
            {
                total_holder += int.Parse(flexible.Rows[i][3].ToString());
                profit_holder += int.Parse(flexible.Rows[i][9].ToString());
            }
            txtbx_total.Text = "Shs. "+ total_holder.ToString("N0");
            txtbx_discounts.Text = "Shs. "+ profit_holder.ToString("N0");


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
           // Defining a holder table to temporarily hold data during filtering
            DataTable holder = new DataTable();
            holder.Columns.Add("ID");
            holder.Columns.Add("type");
            holder.Columns.Add("dea_cust_name");
            holder.Columns.Add("grandTotal");
            holder.Columns.Add("transaction_date");
            holder.Columns.Add("discount");
            holder.Columns.Add("added_by");
            holder.Columns.Add("Paid_amount");
            holder.Columns.Add("Return_amount");
            holder.Columns.Add("Profit");
            for (int i = 0; i <= (flexible.Rows.Count - 1); i++)
            {

                string kind = flexible.Rows[i][1].ToString();
                if (type == kind)
                {
                    string id = flexible.Rows[i][0].ToString();
                    string types = flexible.Rows[i][1].ToString();
                    string name = flexible.Rows[i][2].ToString();
                    string grandTotal = flexible.Rows[i][3].ToString();
                    string date_time = flexible.Rows[i][4].ToString();
                    string discount = flexible.Rows[i][5].ToString();
                    string added_by = flexible.Rows[i][6].ToString();
                    string paid_amount = flexible.Rows[i][7].ToString();
                    string return_amount = flexible.Rows[i][8].ToString();
                    string profit = flexible.Rows[i][9].ToString();


                    // Add the data to the holder data table
                    holder.Rows.Add(id, types, name, grandTotal, date_time, discount, added_by,paid_amount,return_amount,profit);

                }
                else
                {

                }
            }
    
            flexible = holder;
            dgv_transactions.DataSource = flexible;
            int total_holder = 0;
            int discount_holder = 0;
            for (int i = 0; (i <= flexible.Rows.Count - 1); i++)
            {
                total_holder += int.Parse(flexible.Rows[i][3].ToString());
                discount_holder += int.Parse(flexible.Rows[i][9].ToString());
            }
            txtbx_total.Text = "Shs. " + total_holder.ToString("N0");
            txtbx_discounts.Text = "Shs. " + discount_holder.ToString("N0");
        }

        private void Show_all_Click(object sender, EventArgs e)
        {
            DataTable dt_showAll = Ts.DisplayAllTransactions();    
            flexible = dt_showAll;
            dgv_transactions.DataSource = flexible;
            int total_holder = 0;
            int profit_holder = 0;
            for (int i = 0; (i <= flexible.Rows.Count - 1); i++)
            {
                total_holder += int.Parse(flexible.Rows[i][3].ToString());
                profit_holder += int.Parse(flexible.Rows[i][9].ToString());
            }
            txtbx_total.Text = "Shs. " + total_holder.ToString("N0");
            txtbx_discounts.Text = "Shs. " + profit_holder.ToString("N0");
            Cateory_combobox.Text = "";
            checkBox1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgv_transactions_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            string name = dgv_transactions.Rows[row].Cells[2].Value.ToString();
            DateTime time = Convert.ToDateTime(dgv_transactions.Rows[row].Cells[4].Value.ToString());
            lblName = name;
            date = time;
            //TransactionDetail Td = new TransactionDetail();
            //dts = Td.GetTransactionDetail(name);
            Transaction_Details TD = new Transaction_Details();
            TD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter Printer = new DGVPrinter();
            Printer.Title = "\r\n\r\n\r\n ABBEY TRADING STORE \r\n\r\n";
            Printer.SubTitle = "Masaka Buddu Street \r\n Phone: 0758989094\r\n\r\n";
            Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            Printer.PageNumbers = true;
            Printer.PageNumberInHeader = false;
            Printer.PorportionalColumns = false;
            Printer.HeaderCellAlignment = StringAlignment.Near;
            Printer.Footer = "\r\n\r\n Report for All the Transactions";
            Printer.FooterSpacing = 15;
            Printer.PrintDataGridView(dgv_transactions);
        }

        private void dgv_transactions_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }

        private void dtp_transactions_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Get the date from the date time picker and convert it into the appropriate string
                string initial_date = dtp_transactions.Value.ToString("MM/dd/yyyy");
                DataTable holder = new DataTable();
                holder.Columns.Add("ID");
                holder.Columns.Add("type");
                holder.Columns.Add("dea_cust_name");
                holder.Columns.Add("grandTotal");
                holder.Columns.Add("transaction_date");
                holder.Columns.Add("discount");
                holder.Columns.Add("added_by");
                holder.Columns.Add("Paid_amount");
                holder.Columns.Add("Return_amount");
                holder.Columns.Add("Profits");
                for (int i = 0; i <= (flexible.Rows.Count - 1); i++)
                {
                    DateTime data_date = DateTime.Parse(flexible.Rows[i][4].ToString());
                    string date = data_date.ToString("MM/dd/yyyy");
                    if (initial_date == date)
                    {
                        string id = flexible.Rows[i][0].ToString();
                        string type = flexible.Rows[i][1].ToString();
                        string name = flexible.Rows[i][2].ToString();
                        string grandTotal = flexible.Rows[i][3].ToString();
                        string date_time = flexible.Rows[i][4].ToString();
                        string discount = flexible.Rows[i][5].ToString();
                        string added_by = flexible.Rows[i][6].ToString();
                        string paid_amount = flexible.Rows[i][7].ToString();
                        string return_amount = flexible.Rows[i][8].ToString();
                        string profits = flexible.Rows[i][9].ToString();

                        // Add the data to the holder data table
                        holder.Rows.Add(id, type, name, grandTotal, date_time, discount, added_by,paid_amount,return_amount,profits);

                    }
                    else
                    {

                    }
                }
                if (holder.Rows.Count > 0)
                {
                    flexible = holder;
                    dgv_transactions.DataSource = flexible;
                    int total_holder = 0;
                    int discount_holder = 0;
                    for (int i = 0; (i <= flexible.Rows.Count - 1); i++)
                    {
                        total_holder += int.Parse(flexible.Rows[i][3].ToString());
                        discount_holder += int.Parse(flexible.Rows[i][9].ToString());
                    }
                    txtbx_total.Text = "Shs. " + total_holder.ToString("N0");
                    txtbx_discounts.Text = "Shs. " + discount_holder.ToString("N0");
                    Cateory_combobox.Text = "";
                }
                else
                {

                    dgv_transactions.DataSource = holder;

                }



            }
            else
            {

            }
        }
    }
}
