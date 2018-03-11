using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymousExcel
{
 public   class GetalltheTable
    {
        public List<string> GetDatabaseList()
        {
            List<string> list = new List<string>();

            // Open connection to the database
            string conString = GetConfigPath.connectionString();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    //List<string> tables = new List<string>();
                    DataTable dt = con.GetSchema("Tables");
                    foreach (DataRow row in dt.Rows)
                    {
                        string tablename = (string)row[1]+"."+(string)row[2];
                        list.Add(tablename);
                    }
                    
                }
            }
            return list;

        }
    }
}
