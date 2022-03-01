using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOJECIEAPP.Models
{
    public class PaymentRecords
    {
       public string DateShared { get; set; }

      public string Batch { get; set; }
      public string MAP { get; set; }
      public string Acno { get; set; }
      public string ARN { get; set; }
      public string Customer { get; set; }
      public string Email { get; set; }
      public string Tel { get; set; }
      public string Meterstatus { get; set; }
      public string Mainstatus { get; set; }
      public string InstallationStatus { get; set; }
      public string InstallationStatusNMMP { get; set; }
      public string SurveyRemark { get; set; }
      public string MAPMeterType { get; set; }
      public string MAPSurveyRemark { get; set; }
      public string MeterType { get; set; }
      public string payref { get; set; }
      public string newnum { get; set; }
      public string currentStatus { get; set; }
      public string responseStatus { get; set; }
      public string responseTicketId { get; set; }
      public string responseErrorMessage { get; set; }
      public string responseErrorCode { get; set; }
      public string comment { get; set; }
      public string lastModifiedDateTime { get; set; }
      public string transactionStatus { get; set; }
      public string paymentTransactionReferenceId { get; set; }
      public string paymentAdviceDateTime { get; set; }
      public string BU { get; set; }
      public string UT { get; set; }
      public string CISAddress { get; set; }
    }
}