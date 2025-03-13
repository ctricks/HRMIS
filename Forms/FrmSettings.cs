using HRMIS.clsFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMIS.Forms
{
    public partial class FrmSettings : Form
    {
        public bool DatabaseStatus;

        clsFunctions.clsFunctions cfunc = new clsFunctions.clsFunctions();
        clsDatabase cdata = new clsDatabase();

        private string defaultPathIni = Environment.CurrentDirectory + "\\Settings.ini"; 
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[1].Hide();            
            if(!cdata.CheckIniFile())
            {
                MessageBox.Show("Warning: Setting file was not found. Please configure it first.","Setting file is missing",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                tabControl1.SelectedIndex = 0;
            }
            if(cdata.CheckDBConnection(true))
            {
                lblStatus.Text = "Connected";
            }else
            {
                lblStatus.Text = "Disconnected";
            }
            if(cdata.CheckIniFile())
            {
                iniFile iniFile = new iniFile(defaultPathIni);
                tbServername.Text = iniFile.Read("Servername", "Database");
                tbDatabasename.Text = iniFile.Read("Databasename", "Database");
                tbUsername.Text = iniFile.Read("Username", "Database");
                tbPassword.Text = iniFile.Read("Password", "Database");
                cdata.CheckDBConnection(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            tbFileIni.Text = cfunc.GetBrowsePath(defaultPathIni);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(cdata.SaveIniFile(tbServername.Text,tbDatabasename.Text,tbUsername.Text,tbPassword.Text))
            {
                lblStatus.Text = "CONNECTED";
                pbDB.Image = Properties.Resources.DBGreen;

            }else
            {
                lblStatus.Text = "DISCONNECTED";
                pbDB.Image = Properties.Resources.DBRed;
            }
            DatabaseStatus = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Disconnect the database?","Disconnect Database?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DatabaseStatus = false;
            }
        }
    }
}
