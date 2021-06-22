using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace netconsole_test
{
    public class Sms
    {
        /// <summary>
        /// Export Data To Excel
        /// </summary>
        /// <param name="FromDate">From date condition</param>
        /// <param name="ToDate">To date condition</param>
        /// <param name="whereCondition">Condition of query</param>
        /// <returns>All records SmsService in DataSet</returns>
        public static DataSet ExportDataToExcel(DateTime? FromDate, DateTime? ToDate, string whereCondition)
        {
            const string spName = "[dbo].[p_SmsSentLog_ExportDataExcel]";
            var db = new DatabaseProviderFactory().CreateDefault();
            SqlCommand dbCommand = (SqlCommand)db.GetStoredProcCommand(spName);
            db.AddInParameter(dbCommand, "@FromDate", DbType.DateTime, FromDate);
            db.AddInParameter(dbCommand, "@ToDate", DbType.DateTime, ToDate);
            db.AddInParameter(dbCommand, "@WhereCondition", DbType.String, whereCondition);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}