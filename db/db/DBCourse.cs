using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace db
{
    class DBCourse : Connection
    {
        public void insert(String kurskod, String name)
        {
            String insert = "INSERT INTO [Kurs] " +
                "VALUES " +
                "(" +
                    "'" + kurskod + "'" +
                ")";
            db_insert(insert);
        }
        public ArrayList getStudents(String courseCode)
        {
            ArrayList kurser = new ArrayList();

            String select_query = "SELECT * FROM [Kurs]";
            connect();
            SqlCommand query = new SqlCommand(select_query, connection);

            try
            {
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    kurser.Add(reader["kurskod"].ToString());
                }
                reader.Close();
                query.Dispose();
            }
            catch (SqlException e)
            {
                String error = "Could not fetch courses \n" + query.CommandText + "\n";
                MessageBox.Show(error + "\n" + e.ToString());
            }

            close();

            return kurser;
        }
        public void populateAdminCourse(AdminCourse course)
        {
            DBUser user = new DBUser();
            course.Students = user.getStudents(course.CourseName);
        }
    }
}
