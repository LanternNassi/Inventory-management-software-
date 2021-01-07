using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Abbey_Trading_Store.DAL
{
    class LoginDAL
    {
        // fields
        private string username;
        private string password;
        private string usertype;

        // properties
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Usertype { get { return usertype; } set { usertype = value; } }

        public bool login()
        {
            bool isSuccess = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            conn.Open();
            string cmds = "SELECT * FROM `Users` WHERE `User` = @User AND `Usertype` = @Usertype AND `Contact` = @Password ";
            OleDbCommand cmd = new OleDbCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@User", username);
            cmd.Parameters.AddWithValue("@Usertype", usertype);
            cmd.Parameters.AddWithValue("@Password", password);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;

            }
            conn.Close();
 
            
            return isSuccess;
        }
    }
}
