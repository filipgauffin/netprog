using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace db
{
    class DBCourse : Connection
    {
        public void insert(String code, String name)
        {
            String insert = "INSERT INTO [Course] " +
                "VALUES " +
                "(" +
                    "'" + code + "'," +
                    " " + name + " " +
                ")";
            db_insert(insert);
        }
    }
}
