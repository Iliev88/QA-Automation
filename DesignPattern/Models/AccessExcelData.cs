using Dapper;
using SeleniumDesignPatternsDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Models
{
    public class AccessExcelData
    {
        public static string TestDataFileConnection()
        {
            //var path = ConfigurationManager.AppSettings["TestDataSheetPath"];

            //var fileName = "UserData.xlsx";

            var connection = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
                                             Data Source = D:\QA Automation\QA-Automation\DesignPattern\DataDrivenTests\UserData.xlsx;
                                             Extended Properties=Excel 12.0;");
            
            
            return connection;
        }

        public static RegistrateUser GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();

                var query = string.Format("SELECT * FROM [DataSet$] WHERE KEY = '{0}'", keyName);

                var value = connection.Query<RegistrateUser>(query).First();

                connection.Close();

                return value;
            }
        }
    }
}
