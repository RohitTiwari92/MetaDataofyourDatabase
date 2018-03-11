using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymousExcel
{
   public class GetTheDataFromTable
    {
        public model Getdata(string tablename)
        {
            model datamodel=new model();
            datamodel.tablename = tablename;

            IEnumerable<string> col = GetColumnNames( GetConfigPath.connectionString(), tablename);
            GetTableData(tablename, col, datamodel);
            return datamodel;
        }
        private IEnumerable<string> GetColumnNames(string conStr, string tableName)
        {
            var result = new List<string>();
            using (var sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                var sqlCmd = sqlCon.CreateCommand();
                sqlCmd.CommandText = "select * from " + tableName + " where 1=0";  // No data wanted, only schema
                sqlCmd.CommandType = CommandType.Text;

                var sqlDR = sqlCmd.ExecuteReader();
                var dataTable = sqlDR.GetSchemaTable();

                foreach (DataRow row in dataTable.Rows) result.Add(row.Field<string>("ColumnName"));
            }

            return result;
        }
        private void GetTableData( string tableName, IEnumerable<string> col,model datamodel)
        {
            var result = new List<string>();
            string column = "";
            string data = "";
            string conString = GetConfigPath.connectionString();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT top 1  * from "+tableName, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        for (int i = 0; i < col.Count(); i++)
                        {
                            column = column+","   + Convert.ToString(col.ElementAt(i));
                        }
                        while (dr.Read())
                        {
                            for (int i = 0; i < col.Count(); i++)
                            {
                               
                                   // column = ","+column + Convert.ToString(col.ElementAt(i));
                                    data = data+","  + Convert.ToString(dr[i]);
                                
                            }
                            
                        }
                    }
                }
            }
            datamodel.Columnname = column;
            datamodel.Data = data;
           
        }
      
    }
    public class model
    {
        public string tablename { get; set; }
        public string Columnname { get; set; }
        public string Data { get; set; }
    }
}
