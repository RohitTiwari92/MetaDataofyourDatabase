using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymousExcel
{
   public class AppendFile
    {
       public void AppendCSVFile(model data)
       {
            File.AppendAllText(GetConfigPath.sharedOutputFilePath(), data.tablename);
            File.AppendAllText(GetConfigPath.sharedOutputFilePath(),Environment.NewLine);
            File.AppendAllText(GetConfigPath.sharedOutputFilePath(), data.Columnname);
            File.AppendAllText(GetConfigPath.sharedOutputFilePath(), Environment.NewLine);
            File.AppendAllText(GetConfigPath.sharedOutputFilePath(), data.Data);
            File.AppendAllText(GetConfigPath.sharedOutputFilePath(), Environment.NewLine);
            File.AppendAllText(GetConfigPath.sharedOutputFilePath(), Environment.NewLine);

        }
    }
}
