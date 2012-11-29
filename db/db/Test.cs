using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace db
{
    public class Test : Connection
    {
        public void insertAll(String[] values)
        {
            connect();
            String insert_query = "INSERT INTO test_course_leader (Weight, Name, Breed) VALUES (@weight, @name, @breed)";
            SqlCommand query = new SqlCommand(insert_query, connection);
            query.Parameters.AddWithValue("@weight", values[0]);
            query.Parameters.AddWithValue("@name", values[1]);
            query.Parameters.AddWithValue("@breed", values[2]);

            try
            {
                SqlDataReader reader = query.ExecuteReader();
                reader.Close();
                query.Dispose();
                
            }
            catch (SqlException e)
            {
                String error = "Could not execute query \n";
                MessageBox.Show(e.ToString());
            }
            close();
        }
    }
}
