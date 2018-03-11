using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymousExcel
{
  
   public class GetConfigPath
    {
     
      
        public static string sharedOutputFilePath()
        {
            return ReadSetting("sharedOutputFilePath");
        }
        public static string connectionString()
        {
            return ReadSetting("connectionString");
        }
     
        static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                return "Error reading app settings";
            }
        }
    }
}
