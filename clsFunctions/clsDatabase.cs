using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMIS.clsFunctions
{
    public class clsDatabase
    {
        string IniFile = Environment.CurrentDirectory + "\\Settings.ini";
        public string Servername { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }



        public clsDatabase() {
            iniFile ini = new iniFile(IniFile);
            this.Servername = ini.Read("Servername", "Database");
            this.DatabaseName = ini.Read("Databasename", "Database");
            this.Username = ini.Read("Username", "Database");
            this.Password = ini.Read("Password", "Database");
        }
        public bool CheckIniFile()
        {
            clsFunctions clsFunc = new clsFunctions();
            return clsFunc.CheckFileExists(IniFile);
        }
        public bool CheckDBConnection(bool hasMessage)
        {
            string SQLConnString = "Server = " + this.Servername + "; Database = " + this.DatabaseName + "; User Id = " + this.Username + "; Password = " + this.Password + ";";

            SqlConnection sqlConnection = new SqlConnection(SQLConnString);

            bool IsConnected = false;

            try {
                sqlConnection.Open();
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    IsConnected = true;
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if(hasMessage)
                    MessageBox.Show("Error: " + ex.Message, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return IsConnected;
        }
        public bool SaveIniFile(string ServerName, string Databasename, string Username, string Password)
        {
            bool Result = false; 

            if(string.IsNullOrEmpty(ServerName) || string.IsNullOrEmpty(Databasename) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)) {
                MessageBox.Show("Error: Please fill up all fields","Data missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return Result;
            }

            this.Servername = ServerName;
            this.DatabaseName = Databasename;
            this.Username = Username;
            this.Password = Password;

            Result = CheckDBConnection(true);

            if (Result)
            {
                iniFile ini = new iniFile(IniFile);
                ini.Write("Servername", this.Servername, "Database");
                ini.Write("Databasename", this.DatabaseName, "Database");
                ini.Write("Username", this.Username, "Database");
                ini.Write("Password", this.Password, "Database");              
            }

            return Result;
        }
        
    }
}
