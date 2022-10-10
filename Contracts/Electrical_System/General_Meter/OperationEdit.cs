namespace AccountManagement.Application.Contracts.Electrical_System.General_Meter
{
    public class OperationEdit : OperationCreate
    {
        public int Id { get; set; }
        public decimal Rest { get; set; }
    }
}
