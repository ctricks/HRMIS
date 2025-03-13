using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMIS.clsFunctions
{
    public class clsUsers
    {
        public bool validatedUser(string Username,string Password)
        {
            bool Result = false;

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                    MessageBox.Show("Error: Invalid User. Please check your credential.", "Unable to Login User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
            }
            Result = true;

            return Result;
        }
    }
}
