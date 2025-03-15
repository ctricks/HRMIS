using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMIS.clsFunctions
{
    public class clsFunctions
    {
        public bool CheckFileExists(string Filename)
        {
            return File.Exists(Filename);  
        }
        public string GetBrowsePath(string defaultPath)
        {                        
            if(string.IsNullOrEmpty(defaultPath))            
            {
                FolderBrowserDialog fdb = new FolderBrowserDialog();
                fdb.ShowDialog();
                return fdb.SelectedPath.ToString();
            }
            else
            {
                return defaultPath;
            }            
        }
        public void CollapsePanel(GunaAdvenceButton btn, Panel pnl,Label lblDisplay,Panel motherPanel)
        {
            lblDisplay.Text = btn.Text.ToString();

            if (pnl.Height == 0)
            {
                while (pnl.Height <= 135)
                {
                    pnl.Height += 10;
                }
            }
            else
            {
                while (pnl.Height > 0)
                {
                    pnl.Height -= 10;
                }
            }
            foreach (Control control in motherPanel.Controls)
            {
                if (control is Panel)
                {
                    if (control.Name != pnl.Name)
                    {                        
                        while (control.Height > 0)
                        {
                            control.Height -= 10;
                        }
                    }
                }
            }
        }
        public void LogoutUser(Form frmName,Form LoginScreen)
        {
        
        }
    }
}
