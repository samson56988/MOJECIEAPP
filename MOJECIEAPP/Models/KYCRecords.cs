using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOJECIEAPP.Models
{
    public class KYCRecords
    {
       public int SN { get; set; }
       public string DateShared { get; set; }
       public string Batch { get; set; }
       public string ACNo1 { get; set; }    
       public string ACNo2 { get; set; }
       public string SBCsMAIN { get; set; }
       public string SBCs { get; set; } 
       public string OPERATOR { get; set; }
       public string ARN { get; set; }
       public string Customer { get; set; }
       public string CIS { get; set; }
       public string Email { get; set; }
       public string PhoneNumber { get; set; }
       public string Address { get; set; }
       public string CISAddress { get; set; }
       public string Landmark { get; set; }
       public string BU { get; set; }
       public string UT { get; set; }
       public string Feeder { get; set; }
       public string DT { get; set; }
       public string Tariff { get; set; }
       public string MeteredStatus { get; set; }
       public string ReadyToPay { get; set; }
       public string OccupierPhone { get; set; }
       public string TypeofApartment { get; set; }
       public string ExistingMeterType { get; set; }
       public string ExistingMeterNo { get; set; }
       public string Customerbillmatchdataincolumn310 { get; set; }
       public string EstCustomerTotalLoadAmps { get; set; }
       public string RecommendedMeterType { get; set; }
       public string InstallationModePolemounted { get; set; }
       public string LOADwireseparation { get; set; }
       public string AccountSeparation { get; set; }
       public string numberof1QrequiredforAccountSeparation { get; set; }
       public string numberof3QrequiredforAccountSeparation { get; set; }
       public string InstallationSurveyCompany { get; set; }
       public string  InstallerSurveystaff { get; set; }
       public string SurveyDate { get; set; }
       public string RemarkMeterReadyNotMeterReady { get; set; }
       public string MAP { get; set; }
       public string AdditionalComment { get; set; }
    }
}