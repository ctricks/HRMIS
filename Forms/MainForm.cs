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
    public partial class MainForm : Form
    {
        clsFunctions.clsFunctions cfunc = new clsFunctions.clsFunctions();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            lblDisplayName.Text = "DASHBOARD";
            tabControl1.SelectTab(0);
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            if (pnlRecruitment.Height == 135)
            {
                pnlRecruitment.Height = 0;
            }
            else
            {
                pnlRecruitment.Height = 135;
            }
        }

        private void gunaAdvenceButton2_Click_1(object sender, EventArgs e)
        {
            cfunc.CollapsePanel(gunaAdvenceButton2, pnlRecruitment, lblDisplayName, gunaPanel3);
            tabControl1.SelectTab(1);
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            cfunc.CollapsePanel(gunaAdvenceButton3, pnlEmloyeeManagement, lblDisplayName, gunaPanel3);
        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            cfunc.CollapsePanel(gunaAdvenceButton4, pnlAttendanceManagement, lblDisplayName, gunaPanel3);
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            cfunc.CollapsePanel(gunaAdvenceButton5, pnlWorkForce, lblDisplayName, gunaPanel3);
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            cfunc.CollapsePanel(gunaAdvenceButton6, pnlPayrollManagement, lblDisplayName, gunaPanel3);
        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            cfunc.CollapsePanel(gunaAdvenceButton7, pnlEmployeeDevelopment, lblDisplayName, gunaPanel3);
        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            cfunc.CollapsePanel(gunaAdvenceButton9, pnlEmployeeExit, lblDisplayName, gunaPanel3);
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            cfunc.CollapsePanel(gunaAdvenceButton9, pnlReferenceExit, lblDisplayName, gunaPanel3);
        }

        private void gunaAdvenceButton10_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to Logout your System?", "Log-out User", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();                
            }
        }

        private void gunaLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
