using MOJECIEAPP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJECIEAPP.IServices
{
    public interface IKYCExport
    {
        string CreateKYCCSV(IDataReader reader);

        string GetkycCSV();

        string GetKYCCSVQuery(KYCDate date);

        string CreateKYCCSVQuery(IDataReader reader);
    }
}
