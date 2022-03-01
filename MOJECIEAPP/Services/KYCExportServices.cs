using MOJECIEAPP.IServices;
using MOJECIEAPP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOJECIEAPP.Services
{
    public class KYCExportServices : IKYCExport
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        public string CreateKYCCSV(IDataReader reader)
        {
            string file = HttpContext.Current.Server.MapPath("/CSV/ExportedKYCcsv.csv");
            List<string> lines = new List<string>();

            string headerLine = "";
            if (reader.Read())
            {
                string[] columns = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    columns[i] = reader.GetName(i);

                }

                headerLine = string.Join(",", columns);
                lines.Add(headerLine);
            }


            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                reader.GetValues(values);
                lines.Add(string.Join(",", values));

            }

            System.IO.File.WriteAllLines(file, lines);

            return file;
        }

        public string CreateKYCCSVQuery(IDataReader reader)
        {
            string file = HttpContext.Current.Server.MapPath("/CSV/ExportedPaymentQuery.csv");
            List<string> lines = new List<string>();

            string headerLine = "";
            if (reader.Read())
            {
                string[] columns = new string[reader.FieldCount];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    columns[i] = reader.GetName(i);

                }

                headerLine = string.Join(",", columns);
                lines.Add(headerLine);
            }


            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                reader.GetValues(values);
                lines.Add(string.Join(",", values));

            }

            System.IO.File.WriteAllLines(file, lines);

            return file;
        }

        public string GetkycCSV()
        {
            con.Open();
            return CreateKYCCSV(new SqlCommand("SELECT *  FROM KYCEXCEL", con).ExecuteReader());
        }

        public string GetKYCCSVQuery(KYCDate date)
        {
            con.Open();
            return CreateKYCCSVQuery(new SqlCommand("select * from KYCEXCEL where SurveyDate BETWEEN  ' " + date.Date1 + " ' and ' " + date.Date2 + " '", con).ExecuteReader());
        }
    }
}