using _0_Framework.Application;
using AccountManagement.Application.Contracts.PayBox;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Electrical_System.Box_Meter.Meter
{
    public class MPayCreate
    {
        public int Meter_Id { get; set; }
        public string Meter { get; set; }
        public string Cod { get; set; }
        public int MOperation_Id { get; set; }
        public int PayBox_Id { get; set; }
        public string Date_Pay { get; set; }
        public decimal Amount { get; set; }

        [MaxFileSize(1 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Photo { get; set; }
        public List<MOperationViewModel> MOperations { get; set; }
        public List<ViewModel_PayBox> PayBoxes { get; set; }
    }
}