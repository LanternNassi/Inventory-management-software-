using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL
{
    class DealerAndCustomer
    {
        //fields
        private int id;
        private string type;
        private string name;
        private string email;
        private string contact;
        private string address;
        private string added_by;

        // properties
        public int Id { get { return id; } set { id = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Contact { get { return contact; } set { contact = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }

        #region Select
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            const string cmd = "SELECT * FROM DealerCust";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
            try
            {
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

        #region Insert
        public bool Insert()
        {
            
            bool isSuccess = false;
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            string command = "INSERT INTO DealerCust(`type`,`Name`,`Email`,`Contact`,`address`,`added_by`)VALUES(@type,@Name,@Email,@Contact,@address,@added_by)";

            try
            {
                OleDbCommand cmd = new OleDbCommand(command, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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
             
            return isSuccess;
        }
        #endregion

        #region Search
        public DataTable Search(string keywords)
        {
            DataTable dt = new DataTable();
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            string cmd = "SELECT * FROM DealerCust WHERE ID LIKE '%"+keywords+"%' OR Name LIKE '%"+keywords+"%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
            try
            {
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

        #region Update
        public bool Update()
        {
            bool isSuccess = false;
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            string command = "UPDATE DealerCust SET type = @type , Name = @Name , Email = @Email , Contact = @Contact , address = @address WHERE ID = @id";

            try
            {
                OleDbCommand cmd = new OleDbCommand(command, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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

            return isSuccess;
        }
        #endregion

        #region Delete
        public bool Delete()
        {
            bool isSuccess = false;
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            string command = "DELETE * FROM DealerCust WHERE ID = @id";

            try
            {
                OleDbCommand cmd = new OleDbCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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

            return isSuccess;
        }
        #endregion

        #region Search customer or dealer during purchase 
        public string[] search(string keywords)
        {
            string[] results = new string[4];
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            try
            {
                DataTable dt = new DataTable();
                string cmdstring = "SELECT Name , Email , Contact , address FROM DealerCust WHERE ID LIKE '%" + keywords + "%' OR Name LIKE '%" + keywords + "%' ";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmdstring, conn);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count >0){
                     //Filling in the values into the array for returning
                    results[0] = dt.Rows[0]["Name"].ToString();
                    results[1] = dt.Rows[0]["Email"].ToString();
                    results[2] = dt.Rows[0]["Contact"].ToString();
                    results[3] = dt.Rows[0]["address"].ToString();
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

        #region Method to check whether the dealer exists
        public bool checker(string name)
        {
            bool check = false;
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            DataTable dt = new DataTable();
            try
            {
                string cmds = "SELECT * FROM DealerCust WHERE Name = @Name ";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                conn.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
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

            return check;
        }
#endregion

    }
}
