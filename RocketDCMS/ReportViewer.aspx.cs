using Microsoft.Reporting.WebForms;
using RamsoftBD.Models;
using RamsoftBD.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using RamsoftBD.ReportDataHelper.Invoice;


namespace RamsoftBD
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        ReportViewModelDC _reportOptions;
        String ReportFilePath, DataSourceName,query;

        protected void Page_Load(object sender, EventArgs e)
        {
            InvoiceReportDataHelper InvoiceReportDataHelper = new InvoiceReportDataHelper();





            if (Request.HttpMethod == "GET")

            {
                var obj = Request.QueryString;
                var json = obj.Get("parameters");
                var serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                _reportOptions = (ReportViewModelDC)serializer.Deserialize(json, typeof(ReportViewModelDC));

                GetReportFilePathAndDatasourceName(_reportOptions.ReportName);

                using (var _context = new ApplicationDbContext())
                {

                    ReportViewerDC.LocalReport.ReportPath = Server.MapPath(ReportFilePath);
                    ReportViewerDC.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource(DataSourceName, InvoiceReportDataHelper.GetInvoiceReportData(query, _reportOptions.OrderNumber.ToString()));
                    ReportViewerDC.LocalReport.DataSources.Add(rdc);
                    ReportViewerDC.LocalReport.Refresh();
                    ReportViewerDC.DataBind();
                }

            }
        }


        void GetReportFilePathAndDatasourceName(string ReportName) {
                

                switch (ReportName) {
                    case "Invoice":
                        ReportFilePath = "~/Report/Invoice/Invoice.rdlc";
                        DataSourceName = "InvoiceDatasetDC";
                        query = "Proc_GetInvoiceReportForDS";
                        break;

                                  }

               
            }







        }
    }
