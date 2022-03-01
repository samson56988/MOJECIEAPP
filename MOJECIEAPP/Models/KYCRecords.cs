using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOJECIEAPP.Models
{
    public class KYCRecords
    {
        public int SN { get; set; }
        [Display(Name = "Date Shared")]
        public string DateShared { get; set; }
        [Display(Name = "Batch")]
        public string Batch { get; set; }
        [Display(Name = "Account No1")]
        public string ACNo1 { get; set; }
        [Display(Name = "Account No2")]
        public string ACNo2 { get; set; }
        [Display(Name = "SBC Main")]
        public string SBCsMAIN { get; set; }
        [Display(Name = "SBCs")]
        public string SBCs { get; set; }
        [Display(Name = "Operator")]
        public string OPERATOR { get; set; }
        [Display(Name = "ARN")]
        public string ARN { get; set; }
        [Display(Name = "Customer")]
        public string Customer { get; set; }
        [Display(Name = "CIS")]
        public string CIS { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "CIS Address")]
        public string CISAddress { get; set; }
        [Display(Name = "Landmark")]
        public string Landmark { get; set; }
        [Display(Name = "BU")]
        public string BU { get; set; }
        [Display(Name = "UT")]
        public string UT { get; set; }
        [Display(Name = "Feeder")]
        public string Feeder { get; set; }
        [Display(Name = "DT")]
        public string DT { get; set; }
        [Display(Name = "Tariff")]
        public string Tariff { get; set; }
        [Display(Name = "Meter Status")]
        public string MeteredStatus { get; set; }
        [Display(Name = "Ready To Pay")]
        public string ReadyToPay { get; set; }
        [Display(Name = "Occupier Phone")]
        public string OccupierPhone { get; set; }
        [Display(Name = "Type Of Apartment")]
        public string TypeofApartment { get; set; }
        [Display(Name = "Existing Meter Type")]
        public string ExistingMeterType { get; set; }
        [Display(Name = "Existing Meter No")]
        public string ExistingMeterNo { get; set; }
        [Display(Name = "Customer Bill Match")]
        public string Customerbillmatchdataincolumn310 { get; set; }
        [Display(Name = "Est Customer Total Load Amps")]
        public string EstCustomerTotalLoadAmps { get; set; }
        [Display(Name = "Recommended Meter Type")]
        public string RecommendedMeterType { get; set; }
        [Display(Name = "Installation Mode Pole mounted")]
        public string InstallationModePolemounted { get; set; }
        [Display(Name = "Load wire sepration")]
        public string LOADwireseparation { get; set; }
        [Display(Name = "Account Separation")]
        public string AccountSeparation { get; set; }
        [Display(Name = "No of 1 required Acct Seperation")]
        public string numberof1QrequiredforAccountSeparation { get; set; }
        [Display(Name = "No of31 required Acct Seperation")]
        public string numberof3QrequiredforAccountSeparation { get; set; }
        [Display(Name = "Insatllation Survey Company")]
        public string InstallationSurveyCompany { get; set; }
        [Display(Name = "Installer Survey Staff")]
        public string  InstallerSurveystaff { get; set; }
        [Display(Name = "Survey Date")]
        public string SurveyDate { get; set; }
        [Display(Name = "Remark Meter Ready Status")]
        public string RemarkMeterReadyNotMeterReady { get; set; }
        [Display(Name = "MAP")]
        public string MAP { get; set; }
        [Display(Name = "Additional Comment")]
        public string AdditionalComment { get; set; }
    }
}