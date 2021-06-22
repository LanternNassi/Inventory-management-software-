
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL
{
    class product
    {
        //Fields
        private int id;
        private string Product;
        private string category;
        private string description;
        private decimal rate;
        private decimal quantity;
        private DateTime added_date;
        private string added_by;

        // properties
        public int Id { get { return id; } set { id = value; } }
        public string products { get { return Product; } set { Product = value; } }
        public string Category { get { return category; } set { category = value; } }
        public string Description { get { return description; } set { description = value; } }
        public decimal Rate { get { return rate; } set { rate = value; } }
        public decimal Quantity { get { return quantity; } set { quantity = value; } }
        public DateTime Added_date { get { return added_date; } set { added_date = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }

        #region SELECT
        public DataTable select (){
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(connection);
            const string cmd = "SELECT * FROM Products";
            try
            {
                
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd,conn);
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

        #region ADD
        public bool add()
        {
            bool checker = true ;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection connector = new OleDbConnection(connection);
            try
            {
                string command = "INSERT INTO Products(Product,Category,Description,Rate,Quantity,Added_by)values(@Product,@Category,@Description,@Rate,@Quantity,@Added_by)";
                OleDbCommand cmd = new OleDbCommand(command,connector);
                cmd.Parameters.AddWithValue("@Product",Product);
                cmd.Parameters.AddWithValue("@Category",category);
                cmd.Parameters.AddWithValue("@Description",description);
                cmd.Parameters.AddWithValue("@Rate",rate);
                cmd.Parameters.AddWithValue("@Quantity",quantity);
                cmd.Parameters.AddWithValue("@Added_by",added_by);
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            
            }
            finally{
                connector.Close();
            
            }

            return checker;
        }
        #endregion

        #region UPDATE
        public bool update()
        {
            bool checker = true;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection connector = new OleDbConnection(connection);
            try
            {
                string command = "UPDATE Products SET Product = @Product , Category = @Category , Description = @Description , Rate = @Rate, Added_by = @Added_by WHERE id = @id ";
                OleDbCommand cmd = new OleDbCommand(command, connector);
                cmd.Parameters.AddWithValue("@Product", Product);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Rate", rate);
                cmd.Parameters.AddWithValue("@Added_by", added_by);
                cmd.Parameters.AddWithValue("@id", id);
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connector.Close();

            }

            return checker;

        }
        #endregion

        #region SEARCH
        public DataTable search(string keywords)
        {
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(connection);
            string cmd = "SELECT * FROM Products WHERE id LIKE '%"+keywords+"%' OR Product LIKE '%"+keywords+"%' OR Category LIKE '%"+keywords+"%' OR Added_by LIKE '%"+keywords+"%'";
            try
            {

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
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

        #region DELETE 
        public bool delete()
        {
            bool checker = true;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection connector = new OleDbConnection(connection);
            try
            {
                string command = "DELETE * FROM Products WHERE id = @id ";
                OleDbCommand cmd = new OleDbCommand(command, connector);
                cmd.Parameters.AddWithValue("@id", id);
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connector.Close();

            }

            return checker;

        }
        #endregion

        #region Search for product in transaction module
        public string[] Search(string keywords)
        {
            string[] results = new string[3];
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            string cmdstring = "SELECT Product , Rate , Quantity FROM Products WHERE id LIKE '%" + keywords + "%' OR Product LIKE '%" + keywords + "%' ";

            try
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmdstring,conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    // Filling in the values into the array
                    results[0] = dt.Rows[0]["Product"].ToString();
                    results[1] = dt.Rows[0]["Rate"].ToString();
                    results[2] = dt.Rows[0]["Quantity"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return results;
        }
        #endregion

        #region Get the product quantity from database
        public decimal GetProduct(string productName)
        {
            decimal qty = 0;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            DataTable dt = new DataTable();
            try
            {
                string cmds = "SELECT Quantity FROM Products WHERE Product = @Product";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Product", productName);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("Quantity not found");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return qty;
        }
        #endregion

        #region Update the product quantity
        public bool QuantityUpdate(decimal quantity ,string productName )
        {
            bool success = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                string cmds = "UPDATE Products SET Quantity = @Quantity WHERE Product = @product";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@product", productName);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
                
            }
            return success;
        }
        #endregion

        #region Increase the product quantity 
        public bool IncreaseProduct(decimal quantity, string Product_name)
        {
            bool success = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                //Getting the product from database
                decimal Qty = GetProduct(Product_name);

                //Calculations
                decimal result = Qty + quantity;

                //Updating the quantity in the database
                bool check = QuantityUpdate(result, Product_name);

                // verification
                if (check == true)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return success;
        }
        #endregion

        #region Decrease the product Quantity
        public bool DecreaseProduct(decimal quantity, string Product_name)
        {
            bool success = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                //Getting the product from database
                decimal Qty = GetProduct(Product_name);

                //Calculations
                decimal result = Qty - quantity;

                //Updating the quantity in the database
                bool check = QuantityUpdate(result, Product_name);

                // verification
                if (check == true)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return success;

        }
        #endregion

        #region Displaying Products in inventory
        public DataTable DisplayProductsBasedOnCategory(string Name)
        {
            DataTable dt = new DataTable();
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                string cmds = "SELECT * FROM Products WHERE Category = @Category ";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Category", Name);
                OleDbDataAdapter adapter = new OleDbDataAdapter() {SelectCommand = cmd};
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





    }
}