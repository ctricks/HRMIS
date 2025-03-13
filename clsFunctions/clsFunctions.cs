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
    }
}
