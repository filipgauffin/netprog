using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace db
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            DBUser user = new DBUser();
            ArrayList list = user.getStudents("test");

            //user.insert("xx12xx-xx22", "D-09", "qwefq234", "Karlsson", "pa taket", "kpt@karlsson.se", "test");
        }
    }
}
