using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace db
{
    public class Connection
    {
        public static String XML_CONNECTION_STRING = "db.Properties.Settings.course_leader";
        public static String CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings[XML_CONNECTION_STRING].ToString();
        public SqlConnection connection;

        protected SqlConnection connect()
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                String error;
                error = "**** Connection error *****";
                error += "\nCould not connect to db.";
                error += "\n\n" + e.Message;
                Console.WriteLine(error);
                //Error.showError(error);
                return null;
            }
            this.connection = connection;
            return connection;
        }
        protected void close()
        {
            connection.Close();
        }
        protected void executeInsert(SqlCommand query)
        {
            try
            {
                SqlDataReader reader = query.ExecuteReader();

                reader.Close();
                query.Dispose();
            }
            catch (SqlException e)
            {
                String error = "Could not execute query \n" + query.CommandText + "\n";
                //Error.showError(error + "\n" + e.ToString());
            }
        }
        public void db_insert(String string_query)
        {
            connect();
            SqlCommand query = new SqlCommand(string_query, connection);

            executeInsert(query);
            close();
        }
        protected void executeSelect(SqlCommand query)
        {
            try
            {
                Error.showError("test");
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show(reader["email"].ToString());
                }
                Error.showError("test2");
                reader.Close();
                query.Dispose();
            }
            catch (SqlException e)
            {
                String error = "Could not execute query \n" + query.CommandText + "\n";
                Error.showError(error + "\n" + e.ToString());
            }
        }
        public void db_select(String string_query)
        {
            connect();
            SqlCommand query = new SqlCommand(string_query, connection);

            executeSelect(query);
            close();
        }
    }
}
