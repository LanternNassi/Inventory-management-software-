using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL
{
    class Categories
    {
        //Fields
        private string id;
        private string title;
        private string description;
        private string added_by;

        // properties
        public string ID { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Added_by { get { return added_by; } set { added_by = value; } }

        # region Select method
        public DataTable select()
        {
            DataTable dt = new DataTable();
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            const string command = "SELECT * FROM Categories";
            try
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, conn);
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

        #region Add method
        public bool insert()
        {
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(conns);
            try
            {
                const string cmds = "INSERT INTO Categories(`title`,`description`,`added_by`)VALUES(@title,@description,@added_by)";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("added_by", added_by);
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region Update
        public bool update()
        {
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(conns);
            try
            {
                const string cmds = "UPDATE `Categories` SET `title`=@title , `description`=@description WHERE `id` = @id";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@id", id);
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }
        #endregion

        #region Delete method
        public bool delete()
        {
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(conns);
            const string a = "Nassim";
            try
            {
                const string cmds = "DELETE * FROM `Categories` WHERE `id` = @id";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);    
                cmd.Parameters.AddWithValue("@id", id);           
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }

        #endregion

        # region Search method 
        public DataTable search(string search)
        {
            DataTable dt = new DataTable();
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            string command = "SELECT * FROM Categories WHERE ID LIKE '%"+search +"%' OR title LIKE '%"+search +"%'";
            try
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, conn);
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
