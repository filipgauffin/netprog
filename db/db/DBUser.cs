using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

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

            String select_query = "SELECT * FROM [user] WHERE [personalnumber] IN (SELECT [UserRole].[user_pn] FROM [UserRole], [KursOmgang] "+
                                    "WHERE [UserRole].[kursomgang_id] = [KursOmgang].[id] AND "+
                                    "[UserRole].[role_id] = 1 AND [KursOmgang].[kurskod] = '"+courseCode+"')";
            connect();
            SqlCommand query = new SqlCommand(select_query, connection);

            try
            {
                SqlDataReader reader = query.ExecuteReader();
                Student student;
                while (reader.Read())
                {
                    student = new Student(
                        new String[] {
                            reader["personalnumber"].ToString(),
                            reader["programreg"].ToString(),
                            reader["account"].ToString(),
                            reader["lastname"].ToString(),
                            reader["firstname"].ToString(),
                            reader["email"].ToString() 
                    });
                    students.Add(student);
                }
                reader.Close();
                query.Dispose();
            }
            catch (SqlException e)
            {
                String error = "Could not fetch students \n" + query.CommandText + "\n";
                MessageBox.Show(error + "\n" + e.ToString());
            }

            close();

            return students;

        }
    }
}
