using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymousExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllTheDatabaseName dbnames=new GetAllTheDatabaseName();
            //dbnames.GetDatabaseList();
            //GetallthedatabaseNmaeandsize dbnames = new GetallthedatabaseNmaeandsize();
            //dbnames.GetDatabaseListwithsizeinMB();
            Getallthetablenameswithrowcount dbnames = new Getallthetablenameswithrowcount();
            dbnames.GetallthetablenameswithrowcountNumber();
            //GetalltheTable tablesobj=new GetalltheTable();
            //List<string> tables = tablesobj.GetDatabaseList();
            //GetTheDataFromTable dataobj=new GetTheDataFromTable();
            //foreach (var tb in tables)
            //{
            //    model data = dataobj.Getdata(tb);
            //    AppendFile ap =new AppendFile();
            //    ap.AppendCSVFile(data);
            //}
            Console.ReadKey();
        }
    }
}
