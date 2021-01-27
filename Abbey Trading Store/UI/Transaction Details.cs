using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using DGVPrinterHelper;

namespace Abbey_Trading_Store.UI
{
    public partial class Transaction_Details : Form
    {
        public Transaction_Details()
        {
            InitializeComponent();
        }
        DataTable print = new DataTable();
        DataTable filter = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void Transaction_Details_Load(object sender, EventArgs e)
        {
            TransactionDetail TD = new TransactionDetail();
            lbltop.Text = frmTransactions.lblName;
            lbl2.Text = "( " + frmTransactions.date.ToString() + " )";

            //Creating time value for overlapping conditions where processing time is more than one second
            DateTime overlap_time = frmTransactions.date.AddSeconds(1);

            DataTable dt = TD.GetAllTransactionDetails(lbltop.Text);
            DataTable dts = new DataTable();
            dts.Columns.Add("Product_name");
            dts.Columns.Add("rate");
            dts.Columns.Add("Qty");
            dts.Columns.Add("Total");
            dts.Columns.Add("dea_cust_name");
            dts.Columns.Add("added_date");
            dts.Columns.Add("added_by");
            for (int i = 0; i <= (dt.Rows.Count-1); i++)
            {
                //Getting the date from the data row clicked by the user
                string t = dt.Rows[i][5].ToString();

                //Converting the date got into Date Time for the expected query 
                DateTime target_time = DateTime.Parse(t);

                //Checking if the transaction details satisfy one of the conditions where we give a deviation of one second(overlap_time)
                bool check_real_time = overlap_time == target_time || target_time == frmTransactions.date;

                if (check_real_time)
                {
                    //Getting the values from the Get All Transaction Details Data table
                    string p_name = dt.Rows[i][0].ToString();
                    string rate = dt.Rows[i][1].ToString();
                    string Qty = dt.Rows[i][2].ToString();
                    string Total = dt.Rows[i][3].ToString();
                    string dea_cust_name = dt.Rows[i][4].ToString();
                    string added_date = dt.Rows[i][5].ToString();
                    string added_by = dt.Rows[i][6].ToString();

                    //Adding the row filtered to the data table for display
                    dts.Rows.Add(p_name, rate, Qty, Total, dea_cust_name, added_date, added_by);
                }
                else
                {
                    
                    
                }

            }
            print = TD.GetAllTransactionDetails(lbltop.Text);
            filter = dts;
            dgv_TD.DataSource = dts;

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
            Printer.Footer = "\r\n\r\n Report for '"+lbltop.Text+"'";
            Printer.FooterSpacing = 15;
            Printer.PrintDataGridView(dgv_TD);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgv_TD.DataSource = print;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv_TD.DataSource = filter;

        }
    }
}
