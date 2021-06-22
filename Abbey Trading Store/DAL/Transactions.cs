using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL
{
    class Transactions
    {
        // Fields
        private int ID;
        private string type;
        private string dea_cust_name;
        private int grandTotal;
        private DateTime transaction_date;
        private int discount;
        private string added_by;
        private int return_amount;
        private int paid_amount;
        private int total_profit;

        // properties
        public int id { get { return ID; } set { ID = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Dea_Cust_name { get { return dea_cust_name; } set { dea_cust_name = value; } }
        public int GrandTotal { get { return grandTotal; } set { grandTotal = value; } }
        public DateTime Transaction_date { get { return transaction_date; } set { transaction_date = value; } }
        public int Discount { get { return discount; } set { discount = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }
        public int Return_amount { get { return return_amount; } set { return_amount = value; } }
        public int Paid_amount { get { return paid_amount; } set { paid_amount = value; } }
        public int Total_Profit { get { return total_profit; } set { total_profit = value; } }


        #region Insert Transactions
        public int Insert()
        {
            //TransactionID = -1;
            int transID = 0;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            string cmdstring = "INSERT INTO `Transactions`(`type`,`dea_cust_name`,`grandTotal`,`discount`,`added_by`,`Paid_amount`,`Return_amount`,`Total_Profit`)VALUES(@type,@dea_cust_name,@grandTotal,@discount,@added_by,@Paid_amount,@Return_amount,@Total_Profit)";
            string cmdstring2 = "SELECT @@Identity";
            try
            {
                OleDbCommand cmd = new OleDbCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@dea_cust_name", dea_cust_name);
                cmd.Parameters.AddWithValue("@grandTotal", grandTotal);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                cmd.Parameters.AddWithValue("@Paid_amount", paid_amount);
                cmd.Parameters.AddWithValue("@Return_amount", return_amount);
                cmd.Parameters.AddWithValue("@Total_Profit", total_profit);
                conn.Open();
                // Inserting the data into the database
                cmd.ExecuteNonQuery();
                //returning an id of the input data
                cmd.CommandText = cmdstring2;
                transID = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"Transaction");

            }
            finally
            {
                conn.Close();
            }
            return transID;
        }
        #endregion

        #region Showing all Transactions 
        public DataTable DisplayAllTransactions()
        {
            DataTable dt = new DataTable();
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                string cmds = "SELECT * FROM Transactions";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmds,conn);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            
            return dt;
        }
        #endregion

        #region Showing Transactions based on type
        public DataTable DisplayTransactionsBasedOnType(string type)
        {
            DataTable dt = new DataTable();
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                string cmds = "SELECT * FROM Transactions WHERE type = @type";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@type", type);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                conn.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();

            }

            return dt;
        }
        #endregion

    }
}
