using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace db
{
    class DBUser : Connection
    {
        public void insert(String personalnumber, String programreg, 
            String account, String lastname, String firstname, String email, String password)
        {
            if (password == null) { password = "null"; }
            else { password = "'" + password + "'"; }
            String insert = "INSERT INTO [User] (personalnumber, programreg, account, lastname, firstname, email, password) " +
                "VALUES "+
                "(" +
                    "'" + personalnumber + "'," +
                    "'" + programreg + "'," +
                    "'" + account + "'," +
                    "'" + lastname + "'," +
                    "'" + firstname + "'," +
                    "'" + email + "'," +
                    " "+ password +" " +
                ")";
            db_insert(insert);
        }
        public ArrayList getStudents(String courseCode)
        {
            ArrayList students = new ArrayList();

            String select_query = "SELECT * FROM [user] WHERE

        }
    }
}
