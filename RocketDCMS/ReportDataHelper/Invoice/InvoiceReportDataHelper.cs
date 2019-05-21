using RamsoftBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RamsoftBD.ReportDataHelper.Invoice
{
    public class InvoiceReportDataHelper
    {



        ApplicationDbContext db = new ApplicationDbContext();



        public DataTable GetInvoiceReportData(string sql,string OrderNumber)
        {

            var conn = new SqlConnection(db.GetconnectionString());
            var reportCommand = new SqlCommand(sql, conn) { CommandTimeout = 900 };
            reportCommand.CommandType = CommandType.StoredProcedure;
            reportCommand.Parameters.AddWithValue("@OrderNumber",OrderNumber);
            SqlDataReader dr;
            DataTable dt = new DataTable();           
            conn.Open();
            dr = reportCommand.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }


    }
}