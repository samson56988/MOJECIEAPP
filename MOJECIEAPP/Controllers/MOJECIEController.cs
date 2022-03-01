using Mailjet.Client;
using Mailjet.Client.Resources;
using MOJECIEAPP.Config;
using MOJECIEAPP.Models;
using MOJECIEAPP.Services;
using MySqlConnector;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MOJECIEAPP.Controllers
{
    public class MOJECIEController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ConnectionString);
        OleDbConnection Econ;
        List<KYCRecords> _kycs = new List<KYCRecords>();
        private readonly KYCExportServices kyc = new KYCExportServices();
        // GET: MOJECIE
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            System.Threading.Thread.Sleep(5000);
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

            string SN = "";
            string Dateshared = "";
            string Batch = "";
            string ACNo1 = "";
            string ACNo2 = "";
            string SBCsMAIN = "";
            string ARN = "";
            string CustomerName = "";
            string CISName = "";
            string Email = "";
            string PhoneNumber = "";
            string Address = "";
            string CISAddress = "";
            string Landmark = "";
            string BU = "";
            string UT = "";
            string Feeder = "";
            string DT = "";
            string Tariff = "";
            string MeteredStatus = "";
            string ReadyToPay = "";
            string OccupierPhone = "";
            string TypeofApartment = "";
            string ExistingMeterType = "";
            string ExistingMeterNo = "";
            string Customerbillmatchdataincolumn310 = "";
            string EstCustomerTotalLoadAmps = "";
            string RecommendedMeterType = "";
            string InstallationModePolemounted = "";
            string LOADwireseparation = "";
            string AccountSeparation = "";
            string numberof1QrequiredforAccountSeparation = "";
            string numberof3QrequiredforAccountSeparation = "";
            string InstallationSurveyCompany = "";
            string InstallationStaffSurvey = "";
            string SurveyDate = "";
            string RemarkMeterReadyNotMeterReady = "";
            string MAP = "";
            string SurveyreportinDate = "";
            string AdditionalComment = "";





            string Query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            OleDbDataReader dr = Ecom.ExecuteReader();

            while (dr.Read())
            {
                SN = dr[0].ToString();
                Dateshared = dr[1].ToString();
                Batch = dr[2].ToString();
                ACNo1 = dr[3].ToString();
                ACNo2 = dr[4].ToString();
                SBCsMAIN = dr[5].ToString();
                ARN = dr[6].ToString();
                CustomerName = dr[7].ToString();
                CISName = dr[8].ToString();
                Email = dr[9].ToString();
                PhoneNumber = dr[10].ToString();
                Address = dr[11].ToString();
                CISAddress = dr[12].ToString();
                Landmark = dr[13].ToString();
                BU = dr[14].ToString();
                UT = dr[15].ToString();
                Landmark = dr[16].ToString();
      
                Feeder = dr[17].ToString();
                DT = dr[18].ToString();
                Tariff = dr[19].ToString();
                MeteredStatus = dr[20].ToString();
                ReadyToPay = dr[21].ToString();
                OccupierPhone = dr[22].ToString();
                TypeofApartment = dr[23].ToString();
                ExistingMeterType = dr[24].ToString();
                ExistingMeterNo = dr[25].ToString();
                Customerbillmatchdataincolumn310 = dr[26].ToString();
                EstCustomerTotalLoadAmps = dr[27].ToString();
                RecommendedMeterType = dr[28].ToString();
                InstallationModePolemounted = dr[31].ToString();
                LOADwireseparation = dr[29].ToString();
                AccountSeparation = dr[30].ToString();
                numberof1QrequiredforAccountSeparation = dr[31].ToString();
                numberof3QrequiredforAccountSeparation = dr[32].ToString();
                InstallationSurveyCompany = dr[33].ToString();
                InstallationStaffSurvey = dr[34].ToString();
                SurveyDate = dr[35].ToString();
                RemarkMeterReadyNotMeterReady = dr[36].ToString();
                MAP = dr[37].ToString();
                SurveyreportinDate = dr[38].ToString();
                AdditionalComment = dr[39].ToString();

                SqlConnection con = new SqlConnection("Data Source=mojecserver.database.windows.net;Initial Catalog=MOJECIE;User ID=mojec;Password=Admin123;");
                con.Open();

                //MySqlCommand cmddelete = new MySqlCommand("truncate table duplicate",con);
                //cmddelete.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("Select * from KYCEXCEL where ARN = @arn", con);
                cmd.Parameters.AddWithValue("@arn", ARN);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    SqlCommand icmmd = new SqlCommand("update KYCEXCEL set AdditionalComment = @Additioncomment where ARN = @arn", con);
                    icmmd.Parameters.AddWithValue("@arn", ARN);
                    icmmd.Parameters.AddWithValue("@Additioncomment", AdditionalComment);
                    ViewBag.Result = "Data Imported Successfully";
                    icmmd.ExecuteNonQuery();
                }
                else
                {
                   
                    SqlCommand icmmd = new SqlCommand("INSERT INTO KYCEXCEL(SN,DateShared,Batch,ACNo1,ACNo2,SBCsMAIN,ARN,Customer,CIS,Email,PhoneNumber,Address,CISAddress,Landmark,BU,UT,Feeder,DT,Tariff,MeteredStatus,ReadyToPay,OccupierPhone,TypeofApartment,ExistingMeterType,ExistingMeterNo,Customerbillmatchdataincolumn310,EstCustomerTotalLoadAmps,RecommendedMeterType ,InstallationModePolemounted,LOADwireseparation,AccountSeparation,numberof1QrequiredforAccountSeparation,numberof3QrequiredforAccountSeparation,InstallationSurveyCompany,InstallerSurveystaff,SurveyDate,RemarkMeterReadyNotMeterReady,MAP,AdditionalComment)VALUES(@SN,@DateShared,@Batch,@ACNo1,@ACNo2,@SBCsMAIN,@ARN,@Customer,@CIS,@Email,@PhoneNumber,@Address,@CISAddress,@Landmark,@BU,@UT,@Feeder,@DT,@Tariff,@MeteredStatus,@ReadyToPay,@OccupierPhone,@TypeofApartment,@ExistingMeterType,@ExistingMeterNo,@Customerbillmatchdataincolumn310,@EstCustomerTotalLoadAmp,@RecommendedMeterType ,@InstallationModePolemounted,@LOADwireseparation,@AccountSeparation,@numberof1QrequiredforAccountSeparation,@numberof3QrequiredforAccountSeparation,@InstallationSurveyCompany,@InstallerSurveystaff,@SurveyDate,@RemarkMeterReadyNotMeterReady,@MAP,@AdditionalComment)", con);
                    icmmd.Parameters.AddWithValue("@SN", SN);
                    icmmd.Parameters.AddWithValue("@DateShared", Dateshared);
                    icmmd.Parameters.AddWithValue("@Batch", Batch);
                    icmmd.Parameters.AddWithValue("@email", Email);
                    icmmd.Parameters.AddWithValue("@ACNo1", ACNo1);
                    icmmd.Parameters.AddWithValue("@ACNo2", ACNo2);
                    icmmd.Parameters.AddWithValue("@SBCsMAIN", SBCsMAIN);
                    icmmd.Parameters.AddWithValue("@ARN", ARN);
                    icmmd.Parameters.AddWithValue("@Customer", CustomerName);
                    icmmd.Parameters.AddWithValue("@CIS", CISName);
                    icmmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    icmmd.Parameters.AddWithValue("@Address", Address);
                    icmmd.Parameters.AddWithValue("@CISAddress", CISAddress);
                    icmmd.Parameters.AddWithValue("@Landmark", Landmark);
                    icmmd.Parameters.AddWithValue("@BU", BU);
                    icmmd.Parameters.AddWithValue("@UT", UT);
                    icmmd.Parameters.AddWithValue("@Feeder", Feeder);
                    icmmd.Parameters.AddWithValue("@DT", DT);
                    icmmd.Parameters.AddWithValue("@Tariff", Tariff);
                    icmmd.Parameters.AddWithValue("@MeteredStatus", MeteredStatus);
                    icmmd.Parameters.AddWithValue("@ReadyToPay", ReadyToPay);
                    icmmd.Parameters.AddWithValue("@OccupierPhone", OccupierPhone);
                    icmmd.Parameters.AddWithValue("@TypeofApartment", TypeofApartment);
                    icmmd.Parameters.AddWithValue("@ExistingMeterType", ExistingMeterType);
                    icmmd.Parameters.AddWithValue("@ExistingMeterNo", ExistingMeterNo);
                    icmmd.Parameters.AddWithValue("@Customerbillmatchdataincolumn310", Customerbillmatchdataincolumn310);
                    icmmd.Parameters.AddWithValue("@EstCustomerTotalLoadAmp", EstCustomerTotalLoadAmps);
                    icmmd.Parameters.AddWithValue("@RecommendedMeterType", RecommendedMeterType);
                    icmmd.Parameters.AddWithValue("@InstallationModePolemounted", InstallationModePolemounted);
                    icmmd.Parameters.AddWithValue("@LOADwireseparation", LOADwireseparation);
                    icmmd.Parameters.AddWithValue("@AccountSeparation", AccountSeparation);
                    icmmd.Parameters.AddWithValue("@numberof1QrequiredforAccountSeparation", numberof1QrequiredforAccountSeparation);
                    icmmd.Parameters.AddWithValue("@numberof3QrequiredforAccountSeparation", numberof3QrequiredforAccountSeparation);
                    icmmd.Parameters.AddWithValue("@InstallationSurveyCompany", InstallationSurveyCompany);
                    icmmd.Parameters.AddWithValue("@InstallerSurveystaff", InstallationStaffSurvey);
                    icmmd.Parameters.AddWithValue("@SurveyDate", SurveyDate);
                    icmmd.Parameters.AddWithValue("@RemarkMeterReadyNotMeterReady", RemarkMeterReadyNotMeterReady);
                    icmmd.Parameters.AddWithValue("@MAP", MAP);
                    icmmd.Parameters.AddWithValue("@AdditionalComment", AdditionalComment);
                    icmmd.ExecuteNonQuery();
                    

                    ViewBag.Result = "Data Imported Successfully";
                }
                con.Close();

            }



            //DataSet ds = new DataSet();
            //OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            //Econ.Close();
            //oda.Fill(ds);
            //DataTable dt = ds.Tables[0];
            //SqlBulkCopy objbulk = new SqlBulkCopy(con);
            //objbulk.DestinationTableName = "KYCEXCEL";
            //objbulk.ColumnMappings.Add("S/N", "SN");
            ////objbulk.ColumnMappings.Add("Date Shared", "DateShared");
            //objbulk.ColumnMappings.Add("Batch", "Batch");
            //objbulk.ColumnMappings.Add("A/C No", "ACNo1");
            //objbulk.ColumnMappings.Add("A/C No", "ACNo2");
            //objbulk.ColumnMappings.Add("SBCs MAIN", "SBCsMAIN");
            ////objbulk.ColumnMappings.Add("SBCs", "SBCs");
            ////objbulk.ColumnMappings.Add("OPERATOR", "OPERATOR");
            //objbulk.ColumnMappings.Add("ARN", "ARN");
            //objbulk.ColumnMappings.Add("Customer Name", "Customer");
            //objbulk.ColumnMappings.Add("CIS Name", "CIS");
            //objbulk.ColumnMappings.Add("Email", "Email");
            //objbulk.ColumnMappings.Add("Phone Number", "PhoneNumber");
            //objbulk.ColumnMappings.Add("Address", "Address");
            //objbulk.ColumnMappings.Add("CIS Address", "CISAddress");
            //objbulk.ColumnMappings.Add("Landmark", "Landmark");
            //objbulk.ColumnMappings.Add("BU", "BU");
            //objbulk.ColumnMappings.Add("UT", "UT");
            //objbulk.ColumnMappings.Add("Feeder", "Feeder");
            //objbulk.ColumnMappings.Add("DT", "DT");
            //objbulk.ColumnMappings.Add("Tariff", "Tariff");
            //objbulk.ColumnMappings.Add("Metered Status", "MeteredStatus");
            //objbulk.ColumnMappings.Add("Ready To Pay (Yes/No)", "ReadyToPay");
            ////objbulk.ColumnMappings.Add("Occupier Phone No", "OccupierPhone");
            //objbulk.ColumnMappings.Add("Type of Apartment", "TypeofApartment");
            //objbulk.ColumnMappings.Add("Existing Meter Type (1phase/3phase/NA)", "ExistingMeterType");
            //objbulk.ColumnMappings.Add("Existing Meter No", "ExistingMeterNo");
            //objbulk.ColumnMappings.Add("Does Customer bill match data in column 3-10 (Yes/No/NA)", "Customerbillmatchdataincolumn310");
            ////objbulk.ColumnMappings.Add("Est Customer Total Load (Amps)", "EstCustomerTotalLoadAmps");
            //objbulk.ColumnMappings.Add("Recommended Meter Type (1phase/3phase/Nil)", "RecommendedMeterType");
            //objbulk.ColumnMappings.Add("Installation Mode (High wall/ Pole mounted)", "InstallationModePolemounted");
            //objbulk.ColumnMappings.Add("LOAD wire separation required? (Yes/No)", "LOADwireseparation");
            //objbulk.ColumnMappings.Add("Account Separation Required? (Yes/No)", "AccountSeparation");
            //objbulk.ColumnMappings.Add("If Yes, number of 1Q required for Account Separation", "numberof1QrequiredforAccountSeparation");
            //objbulk.ColumnMappings.Add("If Yes, number of 3Q required for Account Separation", "numberof3QrequiredforAccountSeparation");
            //objbulk.ColumnMappings.Add("Installation/ Survey Company", "InstallationSurveyCompany");
            //objbulk.ColumnMappings.Add("Installer/ Survey staff", "InstallerSurveystaff");
            //objbulk.ColumnMappings.Add("Survey Date", "SurveyDate");
            //objbulk.ColumnMappings.Add("Remark (Meter Ready/ Not Meter Ready)", "RemarkMeterReadyNotMeterReady");
            //objbulk.ColumnMappings.Add("MAP", "MAP");
            //objbulk.ColumnMappings.Add("Additional Comment", "AdditionalComment");
            //ViewBag.Result = "Data Imported Successfully";
            //con.Open();
            //objbulk.WriteToServer(dt);
            //con.Close();
        }
        public ActionResult KYCRecords(int PageNumber = 1)
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
            ViewBag.TotalPages = Math.Ceiling(_kycs.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
            _kycs = _kycs.Skip((PageNumber - 1) * 10).Take(10).ToList();

            return View(_kycs);
        }
        [HttpPost]
        public ActionResult KYCRecords(string Data)
        {
               _kycs = new List<KYCRecords>();

            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("Searchtable", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", Data);
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
            ViewBag.TotalPages = Math.Ceiling(_kycs.Count() / 10.0);
            return View(_kycs);
        }
        public ActionResult PaymentRecord()
        {
            return View();
        }
        public ActionResult DownloadReport(string start ,string end)
        {
           if(start  == "" && end == "")
               return Redirect("http://mojecdataapi.azurewebsites.net/api/IEKYCFile/Download");
            else
               return Redirect("http://mojecdataapi.azurewebsites.net/api/KYCFileQuery/Download?date1="+start+"&&date2="+end);
        }
        [HttpGet]
        public ActionResult KYCDetails(string id)
        {
           
                KYCRecords kyc = new KYCRecords();
                using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
                {
                    SqlCommand cmd = new SqlCommand("GetKYCByArn", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@ARN", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    kyc.Batch = rdr["Batch"].ToString();
                    kyc.ACNo1 = rdr["ACNo1"].ToString();
                    kyc.ACNo2 = rdr["ACNo2"].ToString();
                    kyc.SBCsMAIN = rdr["SBCsMAIN"].ToString();
                    kyc.ARN = rdr["ARN"].ToString();
                    kyc.Customer = rdr["Customer"].ToString();
                    kyc.CIS = rdr["CIS"].ToString();
                    kyc.Email = rdr["Email"].ToString();
                    kyc.PhoneNumber = rdr["PhoneNumber"].ToString();
                    kyc.Address = rdr["Address"].ToString();
                    kyc.CISAddress = rdr["CISAddress"].ToString();
                    kyc.Landmark = rdr["Landmark"].ToString();
                    kyc.BU = rdr["BU"].ToString();
                    kyc.UT = rdr["UT"].ToString();
                    kyc.Feeder = rdr["Feeder"].ToString();
                    kyc.DT = rdr["DT"].ToString();
                    kyc.Tariff = rdr["Tariff"].ToString();
                    kyc.MeteredStatus = rdr["MeteredStatus"].ToString();
                    kyc.ReadyToPay = rdr["ReadyToPay"].ToString();
                    kyc.OccupierPhone = rdr["OccupierPhone"].ToString();
                    kyc.TypeofApartment = rdr["TypeofApartment"].ToString();
                    kyc.ExistingMeterType = rdr["ExistingMeterType"].ToString();
                    kyc.ExistingMeterNo = rdr["ExistingMeterNo"].ToString();
                    kyc.Customerbillmatchdataincolumn310 = rdr["Customerbillmatchdataincolumn310"].ToString();
                    kyc.EstCustomerTotalLoadAmps = rdr["EstCustomerTotalLoadAmps"].ToString();
                    kyc.RecommendedMeterType = rdr["RecommendedMeterType"].ToString();
                    kyc.InstallationModePolemounted = rdr["InstallationModePolemounted"].ToString();
                    kyc.LOADwireseparation = rdr["LOADwireseparation"].ToString();
                    kyc.AccountSeparation = rdr["AccountSeparation"].ToString();
                    kyc.numberof1QrequiredforAccountSeparation = rdr["numberof1QrequiredforAccountSeparation"].ToString();
                    kyc.numberof3QrequiredforAccountSeparation = rdr["numberof3QrequiredforAccountSeparation"].ToString();
                    kyc.InstallationSurveyCompany = rdr["InstallationSurveyCompany"].ToString();
                    kyc.InstallerSurveystaff = rdr["InstallerSurveystaff"].ToString();
                    kyc.SurveyDate = rdr["SurveyDate"].ToString();
                    kyc.RemarkMeterReadyNotMeterReady = rdr["RemarkMeterReadyNotMeterReady"].ToString();
                    kyc.MAP = rdr["MAP"].ToString();
                    kyc.AdditionalComment = rdr["AdditionalComment"].ToString();
                    }
                rdr.Close();
                }

              
            
            return View(kyc);
        }

        public ActionResult UploadPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPayment(HttpPostedFileBase file)
        {
            System.Threading.Thread.Sleep(5000);
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = "/excelfolder/" + filename;
            file.SaveAs(Path.Combine(Server.MapPath("/excelfolder/"), filename));
            InsertPaymentdata(filepath, filename);
            return View();
        }

        private async Task InsertPaymentdata(string fileepath, string filename)
        {          

            string fullpath = Server.MapPath("/excelfolder/") + filename;
            ExcelConn(fullpath);

            string Acno = "8934034994343";
            string CustomerName = "Samson Ajayi";
            string Email = "samson@mojec.com";
            string Tel = +234+"7069002243";
            string payref = "43898438304343";
            string MAPMeterType = "1phase";

            string Metertype = "";

            


            string Query = string.Format("Select * from [{0}]", "Sheet1$");
            OleDbCommand Ecom = new OleDbCommand(Query, Econ);
            Econ.Open();

            OleDbDataReader dr = Ecom.ExecuteReader();

            while (dr.Read())
            {
                //Acno = dr[3].ToString();
                //CustomerName = dr[5].ToString();
                //Email = dr[6].ToString();
                //Tel = dr[7].ToString();
                //payref = dr[16].ToString();
                //MAPMeterType = dr[13].ToString();

                if (MAPMeterType == "1phase")
                {
                    Metertype = "1 Phase";
                }
                else if (MAPMeterType == "3phase")
                {
                    Metertype = "3 Phase";
                }

                RestClient restClient = new RestClient("https://api.ng.termii.com/api/sms/otp/send");

                //Creating Json object
                JObject objectBody = new JObject();
                objectBody.Add("api_key", "TLEshtuwI3Ie4OEwEC2znYMgZ67bFcV3Nhqpx54QzfjZw2NLExjbRnqBuDMvmn");
                objectBody.Add("message_type", "NUMERIC");
                objectBody.Add("to", Tel);
                objectBody.Add("from", "Mojec");
                objectBody.Add("channel", "generic");
                objectBody.Add("pin_attempts", 10);
                objectBody.Add("pin_time_to_live", 5);
                objectBody.Add("pin_length", 6);
                objectBody.Add("pin_placeholder", "< 1234 >");
                objectBody.Add("message_text", " Dear Sir / Ma, Your meter application on CIS account " + Acno + " is approved.Survey Result - " + Metertype + " click to pay https://www.ikejaelectric.com/meterfee Ensure you use the  reference code below:Ref Code: " + payref + " Meter prices Single phase N63, 061.32 Three phase N117, 910.69");
                objectBody.Add("pin_type", "NUMERIC");
                RestRequest restRequest = new RestRequest(Method.POST);

                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", objectBody, ParameterType.RequestBody);
                IRestResponse restResponse = restClient.Execute(restRequest);
                string responsemessage = restResponse.Content;




                MailjetClient client = new MailjetClient("a2aecb3da444f627a5472c374b33cd84", "137c68f561d36cd5e9eb2295260ba108");
                MailjetRequest request = new MailjetRequest
                {
                    Resource = Send.Resource,
                }
                .Property(Send.FromEmail, "map@mojec.com")
                .Property(Send.FromName, "Mojec Map")
                .Property(Send.To, Email)
                .Property(Send.Subject, "Ikeja Map")
                .Property(Send.TextPart, "Dear Sir / Ma,Your meter application on CIS account "+Acno+" is approved.Survey Result - "+Metertype+" click to pay https://www.ikejaelectric.com/meterfee Ensure you use the  reference code below:Ref Code: "+payref+" Meter prices Single phase N63, 061.32 Three phase N117, 910.69");
                MailjetResponse response = await client.PostAsync(request);
                

               


            }



            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
            Econ.Close();
            oda.Fill(ds);
            DataTable dt = ds.Tables[0];
            SqlBulkCopy objbulk = new SqlBulkCopy(con);
            objbulk.DestinationTableName = "Payment";
            objbulk.ColumnMappings.Add("DateShared", "DateShared");
            objbulk.ColumnMappings.Add("Batch", "Batch");
            objbulk.ColumnMappings.Add("MAP", "MAP");
            objbulk.ColumnMappings.Add("ACNo", "Acno");
            objbulk.ColumnMappings.Add("ARN", "ARN");
            objbulk.ColumnMappings.Add("CustomerName", "Customer");
            objbulk.ColumnMappings.Add("Email", "Email");
            objbulk.ColumnMappings.Add("Tel", "Tel");
            objbulk.ColumnMappings.Add("MeterStatus", "Meterstatus");
            objbulk.ColumnMappings.Add("MainStatus", "Mainstatus");
            objbulk.ColumnMappings.Add("InstallationStatusMAP", "InstallationStatus");
            objbulk.ColumnMappings.Add("InstallationStatusNMMP", "InstallationStatusNMMP");
            objbulk.ColumnMappings.Add("SurveyRemark", "SurveyRemark");
            objbulk.ColumnMappings.Add("MAPMeterType", "MAPMeterType");
            objbulk.ColumnMappings.Add("MAPSurveyRemark", "MAPSurveyRemark");
            objbulk.ColumnMappings.Add("MeterType", "MeterType");
            objbulk.ColumnMappings.Add("payref", "payref");
            objbulk.ColumnMappings.Add("newnum", "newnum");
            objbulk.ColumnMappings.Add("currentStatus", "currentStatus");
            objbulk.ColumnMappings.Add("responseStatus", "responseStatus");
            objbulk.ColumnMappings.Add("responseTicketId", "responseTicketId");
            objbulk.ColumnMappings.Add("responseErrorMessage", "responseErrorMessage");
            objbulk.ColumnMappings.Add("responseErrorCode", "responseErrorCode");
            objbulk.ColumnMappings.Add("comment", "comment");
            objbulk.ColumnMappings.Add("lastModifiedDateTime", "lastModifiedDateTime");
            objbulk.ColumnMappings.Add("transactionStatus", "transactionStatus");
            objbulk.ColumnMappings.Add("paymentTransactionReferenceId", "paymentTransactionReferenceId");
            objbulk.ColumnMappings.Add("paymentAdviceDateTime", "paymentAdviceDateTime");
            objbulk.ColumnMappings.Add("BU", "BU");
            objbulk.ColumnMappings.Add("UT", "UT");
            objbulk.ColumnMappings.Add("CISAddress", "CISAddress");
            con.Open();
            objbulk.WriteToServer(dt);
            con.Close();



        }









        }
    }