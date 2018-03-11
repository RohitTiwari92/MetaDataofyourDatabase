using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymousExcel
{
   public class GetallthedatabaseNmaeandsize
    {
        public void GetDatabaseListwithsizeinMB()
        {
           

            // Open connection to the database
            string conString = GetConfigPath.connectionString();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand(@"with fs
                    as
                    (
                        select database_id, type, size* 8.0 / 1024 size
                        from sys.master_files
                    )
                    select
                                name,
                    (select sum(size) from fs where type = 0 and fs.database_id = db.database_id) DataFileSizeMB,
                    (select sum(size) from fs where type = 1 and fs.database_id = db.database_id) LogFileSizeMB
                    from sys.databases db
                    ", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        
                        while (dr.Read())
                        {
                            Console.WriteLine(dr[0]+ "  "+ dr[1]+ "  "+ dr[2]);
                        }
                    }

                }
            }
           

        }
    }
}
