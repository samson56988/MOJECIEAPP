using MOJECIEAPP.Config;
using MOJECIEAPP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOJECIEAPP.Controllers
{
    public class MOJECIEController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        OleDbConnection Econ;

        List<KYCRecords> _kycs = new List<KYCRecords>();

        // GET: MOJECIE
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder/"), filename));
            InsertExceldate(filepath, filename);
            return View();
        }

        private void ExcelConn(string FilePath)
        {
            string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", FilePath);
            Econ = new OleDbConnection(constr);
        }

        private void InsertExceldate(string fileepath, string filename)
        {
            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);
            string Query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);

            Econ.Open();

            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);

            DataTable dt = ds.Tables[0];

            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "KYCEXCEL";
            objbulk.ColumnMappings.Add("S/N", "SN");
            objbulk.ColumnMappings.Add("Date Shared", "DateShared");
            objbulk.ColumnMappings.Add("Batch", "Batch");
            objbulk.ColumnMappings.Add("A/C No", "ACNo1");
            objbulk.ColumnMappings.Add("A/C No", "ACNo2");
            objbulk.ColumnMappings.Add("SBCs MAIN", "SBCsMAIN");
            objbulk.ColumnMappings.Add("SBCs", "SBCs");
            objbulk.ColumnMappings.Add("OPERATOR", "OPERATOR");
            objbulk.ColumnMappings.Add("ARN", "ARN");
            objbulk.ColumnMappings.Add("Customer Name", "Customer");
            objbulk.ColumnMappings.Add("CIS Name", "CIS");
            objbulk.ColumnMappings.Add("Email", "Email");
            objbulk.ColumnMappings.Add("Phone Number", "PhoneNumber");
            objbulk.ColumnMappings.Add("Address", "Address");
            objbulk.ColumnMappings.Add("CIS Address", "CISAddress");
            objbulk.ColumnMappings.Add("Landmark", "Landmark");
            objbulk.ColumnMappings.Add("BU", "BU");
            objbulk.ColumnMappings.Add("UT", "UT");
            objbulk.ColumnMappings.Add("Feeder", "Feeder");
            objbulk.ColumnMappings.Add("DT", "DT");
            objbulk.ColumnMappings.Add("Tariff", "Tariff");
            objbulk.ColumnMappings.Add("Metered Status", "MeteredStatus");
            objbulk.ColumnMappings.Add("Ready To Pay (Yes/No)", "ReadyToPay");
            objbulk.ColumnMappings.Add("Occupier Phone No", "OccupierPhone");
            objbulk.ColumnMappings.Add("Type of Apartment", "TypeofApartment");
            objbulk.ColumnMappings.Add("Existing Meter Type (1phase/3phase/NA)", "ExistingMeterType");
            objbulk.ColumnMappings.Add("Existing Meter No", "ExistingMeterNo");
            objbulk.ColumnMappings.Add("Does Customer bill match data in column 3-10 (Yes/No/NA)", "Customerbillmatchdataincolumn310");
            objbulk.ColumnMappings.Add("Est Customer Total Load (Amps)", "EstCustomerTotalLoadAmps");
            objbulk.ColumnMappings.Add("Recommended Meter Type (1phase/3phase/Nil)", "RecommendedMeterType");
            objbulk.ColumnMappings.Add("Installation Mode (High wall/ Pole mounted)", "InstallationModePolemounted");
            objbulk.ColumnMappings.Add("LOAD wire separation required? (Yes/No)", "LOADwireseparation");
            objbulk.ColumnMappings.Add("Account Separation Required? (Yes/No)", "AccountSeparation");
            objbulk.ColumnMappings.Add("If Yes, number of 1Q required for Account Separation", "numberof1QrequiredforAccountSeparation");
            objbulk.ColumnMappings.Add("If Yes, number of 3Q required for Account Separation", "numberof3QrequiredforAccountSeparation");
            objbulk.ColumnMappings.Add("Installation/ Survey Company", "InstallationSurveyCompany");
            objbulk.ColumnMappings.Add("Installer/ Survey staff", "InstallerSurveystaff");
            objbulk.ColumnMappings.Add("Survey Date", "RemarkMeterReadyNotMeterReady");
            objbulk.ColumnMappings.Add("Remark (Meter Ready/ Not Meter Ready)", "MAP");
            objbulk.ColumnMappings.Add("Additional Comment", "AdditionalComment");

            ViewBag.Result = "Data Imported Successfully";



            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();

        }


        public ActionResult KYCRecords()
        {
            _kycs = new List<KYCRecords>();
            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {

                SqlCommand cmd = new SqlCommand("GetKYCRecords", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    KYCRecords kyc = new KYCRecords();
                    kyc.SN = Convert.ToInt32(rdr["SN"].ToString());
                    kyc.DateShared = rdr["DateShared"].ToString();
                    kyc.Batch = rdr["Batch"].ToString();
                    kyc.ACNo1 = rdr["ACNo1"].ToString();
                    kyc.ACNo2 = rdr["ACNo2"].ToString();
                    kyc.SBCsMAIN = rdr["SBCsMAIN"].ToString();
                    kyc.SBCs = rdr["SBCs"].ToString();
                    kyc.OPERATOR = rdr["OPERATOR"].ToString();
                    kyc.ARN = rdr["ARN"].ToString();
                    kyc.AdditionalComment = rdr["AdditionalComment"].ToString();
                    _kycs.Add(kyc);
                }
                rdr.Close();
            }
 
            return View(_kycs);
        }

        public ActionResult PaymentRecord()
        {
            return View();
        }

    }
}