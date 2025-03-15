using HRMIS.clsFunctions;
using HRMIS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMIS
{
    public partial class frmSplashScreen : Form
    {
        clsDatabase dbFunc = new clsDatabase();

        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbSplash.Value += 10;

            //Checking Setting file (Setting.ini)
            if (pbSplash.Value == 10)
            {
                tssStatusLabel.Text = "Checking Settings.ini File";
                if (!dbFunc.CheckIniFile())
                {
                    timer1.Stop();
                    string ErrMessage = "Error: Settings not found. Would you like to create first?";
                    tssStatusLabel.Text = ErrMessage;
                    DialogResult drResult = MessageBox.Show(ErrMessage, "Setting file is missing", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (drResult == DialogResult.No)
                    {
                        Application.Exit();
                    }

                    Forms.FrmSettings frmSettings = new Forms.FrmSettings();
                    frmSettings.ShowDialog();
                    timer1.Start();
                    tssStatusLabel.Text = "Settings Done...";
                }
            }
            else if (pbSplash.Value == 40) {
                tssStatusLabel.Text = "Checking Database connection";
                timer1.Stop();                    
                //if (dbFunc.CheckDBConnection())
                //{
                //    timer1.Start();
                //    tssStatusLabel.Text = "Database Connected";
                //}
                //else
                //{
                //    tssStatusLabel.Text = "Database Disconnected";
                //    FrmSettings frmSettings = new FrmSettings();
                //    frmSettings.ShowDialog();                    
                //}
                while (!dbFunc.CheckDBConnection(false))
                {
                    tssStatusLabel.Text = "Database Disconnected";
                    FrmSettings frmSettings = new FrmSettings();
                    frmSettings.ShowDialog();
                    if (frmSettings.DatabaseStatus == false)
                    {
                        clsDatabase dbFunc = new clsDatabase();
                        if (dbFunc.CheckDBConnection(false))
                        {
                            timer1.Start();
                            tssStatusLabel.Text = "Database Connected";
                            break;
                        }
                    }else
                    {
                        timer1.Start();
                        tssStatusLabel.Text = "Database Connected";
                        break;
                    }
                }
                timer1.Start();
            }
            else if(pbSplash.Value == 50)
            {
                tssStatusLabel.Text = "Database Connected";
            }
            else if(pbSplash.Value == 60)
            {
                tssStatusLabel.Text = "Preparing...";
            }
            if (pbSplash.Value == 100)
            {
                timer1.Enabled = false;
                tssStatusLabel.Text = "Ready...";
                lblPowered.Visible = false;
                pbSplash.Visible = false;
                gpLogin.Visible = true;
                tbUsername.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUsers cuser = new clsUsers();
            if(cuser.validatedUser(tbUsername.Text, tbPassword.Text))
            {
                this.Hide();
                MainForm mform = new MainForm();
                mform.ShowDialog();
                this.Show();
            }
        }

        private void frmSplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult drRes = MessageBox.Show("Are you sure you want to exit the application?", "Close Program?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drRes == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
