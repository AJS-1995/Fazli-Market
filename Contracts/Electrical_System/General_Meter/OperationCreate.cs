using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public class OperationCreate
    {
        public int GeneralMeter_Id { get; set; }
        public string GeneralMeter { get; set; }
        public string Date_Rrad { get; set; }
        public string Date_Pay { get; set; }
        public int Grade_Past { get; set; }
        public int Grade_Now { get; set; }
        public decimal Amount { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Photo { get; set; }
        public List<GeneralMeterViewModel> GeneralMeters { get; set; }
    }
}
