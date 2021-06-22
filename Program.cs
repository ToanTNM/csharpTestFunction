using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace netconsole_test
{
    class Program
    {

        static void Main(string[] args)
        {
            QueryData();

            Console.ReadLine();
        }

        public static void QueryData()
        {
            var from = new DateTime(2019, 01, 01);
            // var to = new DateTime(2019, 02, 01);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            var ds = Sms.ExportDataToExcel(from, null, "");

            watch.Stop();
            Console.WriteLine("{0} - Execute Sms.ExportDataToExcel() in: {1}ms - Query: {2} rows",
                DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]"),
                watch.ElapsedMilliseconds,
                ds.Tables[0].Rows.Count
            );
        }

    }
}
