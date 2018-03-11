using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymousExcel
{
   public class Getallthetablenameswithrowcount
    {
        public void 	GetallthetablenameswithrowcountNumber()
        {
            // Open connection to the database
            string conString = GetConfigPath.connectionString();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand(@"DECLARE @QueryString NVARCHAR(MAX) ;
                                                        SELECT @QueryString = COALESCE(@QueryString + ' UNION ALL ','')
                                                                              + 'SELECT '
                                                                              + '''' + QUOTENAME(SCHEMA_NAME(sOBJ.schema_id))
                                                                              + '.' + QUOTENAME(sOBJ.name) + '''' + ' AS [TableName]
                                                                              , COUNT(*) AS [RowCount] FROM '
                                                                              + QUOTENAME(SCHEMA_NAME(sOBJ.schema_id))
                                                                              + '.' + QUOTENAME(sOBJ.name) + ' WITH (NOLOCK) '
                                                        FROM sys.objects AS sOBJ
                                                        WHERE
                                                              sOBJ.type = 'U'
                                                              AND sOBJ.is_ms_shipped = 0x0
                                                        ORDER BY SCHEMA_NAME(sOBJ.schema_id), sOBJ.name ;
                                                        EXEC sp_executesql @QueryString", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        
                        while (dr.Read())
                        {
                            Console.WriteLine(dr[0]+ "  "+ dr[1]);
                        }
                    }

                }
            }
           

        }
    }
}
