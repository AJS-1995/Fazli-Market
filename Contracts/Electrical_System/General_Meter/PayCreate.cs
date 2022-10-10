using _0_Framework.Application;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public class PayCreate
    {
        public int GeneralMeter_Id { get; set; }
        public string GeneralMeter { get; set; }
        public int Operation_Id { get; set; }
        public int PayBox_Id { get; set; }
        public string Date_Pay { get; set; }
        public decimal Amount { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Photo { get; set; }
        public List<GeneralMeterViewModel> Generals { get; set; }
        public List<OperationViewModel> Operations { get; set; }
        public List<ViewModel_PayBox> PayBoxes { get; set; }
    }
}