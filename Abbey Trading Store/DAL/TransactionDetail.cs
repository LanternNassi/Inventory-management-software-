using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace Abbey_Trading_Store.DAL
{
    class TransactionDetail
    {
        //Fields
        private int ID;
        private string product_name;
        private decimal rate;
        private decimal Qty;
        private decimal total;
        private string dea_cust_name;
        private DateTime added_date;
        private string added_by;
        private int Invoice_id;
        private int Profit;

        //Properties
        public int id { get { return ID;} set {ID = value;} }
        public string Product_name { get { return product_name; } set { product_name = value;} }
        public decimal Rate { get { return rate; } set { rate = value;} }
        public decimal qty { get { return Qty; } set { Qty = value;} }
        public decimal Total { get { return total; } set { total = value;} }
        public string Dea_Cust_name { get { return dea_cust_name; } set { dea_cust_name = value; } }
        public DateTime Added_date { get { return added_date; } set { added_date = value;} }
        public string Added_by { get { return added_by; } set { added_by = value; } }
        public int invoice_id {get{return Invoice_id;}set{Invoice_id = value;}}
        public int profit { get { return Profit; } set { Profit = value; } }

#region Insert Transaction Details
        public bool Insert()
        {
            bool isSuccess = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            string cmdstring = "INSERT INTO `Transaction Details`(`product_name`,`rate`,`Qty`,`total`,`dea_cust_name`,`added_by`,`Invoice_id`,`Profit`)VALUES(@product_name,@rate,@Qty,@total,@dea_cust_name,@added_by,@Invoice_id,@Profit)";


            try
            {
                OleDbCommand cmd = new OleDbCommand(cmdstring, conn);
                //cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@product_name",product_name);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@dea_cust_name", dea_cust_name);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                cmd.Parameters.AddWithValue("@Invoice_id", Invoice_id);
                cmd.Parameters.AddWithValue("@Profit", Profit);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"TD");

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
#endregion

        #region Getting transaction Details
       

        #region Returning all transaction details
        public DataTable GetAllTransactionDetails(string Name)
        {
            DataTable dt = new DataTable();
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            string cmdstring = "SELECT product_name,rate,Qty,Total,dea_cust_name,added_date,added_by,Profit FROM `Transaction Details` WHERE `dea_cust_name` = @dea_cust_name";
            try
            {
                OleDbCommand cmd = new OleDbCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@dea_cust_name", Name);
                
                OleDbDataAdapter adapter = new OleDbDataAdapter() { SelectCommand = cmd };
                conn.Open();
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
        #endregion





    }
}
