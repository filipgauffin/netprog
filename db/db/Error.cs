using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db
{
    static class Error
    {
        public static void showError(String error){
            MessageBox.Show(error);
        }
    }
}
