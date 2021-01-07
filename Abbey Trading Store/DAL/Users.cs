using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL
{
    class Users
    {
        //declaring fields

        private string User;
        private string Password;
        private string Gender;
        private string Added_by;
        private string Type;

        // declaring properties for the fields 

        public string user { get { return User; } set { User = value; } }
        public string password { get { return Password; } set { Password = value; } }
        public string gender { get { return Gender; } set { Gender = value; } }
        public string added_by { get { return Added_by; } set { Added_by = value; } }
        public string type { get { return Type; } set { Type = value; } }

        public DataTable select()
        {
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                const string command = "SELECT * FROM Users";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, conn);
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


        public bool insert()
        {
            bool isSuccess = true;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "INSERT INTO `Users` (`User`, `Contact`, `Gender`, `Added_by`, `Type`) VALUES (@User, @Password, @Gender, @Added_by, @Type)";
            cmd.Parameters.AddWithValue("@User", User);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Added_by", Added_by);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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

        public DataTable search(string keywords)
        {
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                string command = "SELECT * FROM Users WHERE id LIKE '%" + keywords + "%' OR User LIKE '%" + keywords + "%'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, conn);
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


        public bool update(string id)
        {
            bool isSuccess = true;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE `Users` SET `User` = @User, `Contact` = @Password, `Gender` = @Gender, `Added_by` = @Added_by, `Type` = @Type WHERE `ID` = @id ";
            cmd.Parameters.AddWithValue("@User", User);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Added_by", Added_by);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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


        public bool delete(string id)
        {
            bool isSuccess = true;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE * FROM `Users` WHERE `ID` = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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

    }
}
