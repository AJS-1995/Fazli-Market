using _0_Framework.Domain;

namespace Domin.Electrical_System.General_MeterAgg
{
    public class Pay : EntityBase<int>
    {
        public int GeneralMeter_Id { get; private set; }
        public int Operation_Id { get; private set; }
        public int PayBox_Id { get; private set; }
        public string Date_Pay { get; private set; }
        public decimal Amount { get; private set; }
        public string Photo { get; private set; }

        public Pay()
        {
        }

        public Pay(int generalmeter_id, int operation_Id, int paybox_Id, string date_Pay, decimal amount, string photo, int userid)
        {
            GeneralMeter_Id = generalmeter_id;
            Operation_Id = operation_Id;
            PayBox_Id = paybox_Id;
            Date_Pay = date_Pay;
            Amount = amount;
            Photo = photo;
            User_Id = userid;
        }
        public void Edit(int generalmeter_id, int operation_Id, int paybox_Id, string date_Pay, decimal amount, string photo, int userid)
        {
            GeneralMeter_Id = generalmeter_id;
            Operation_Id = operation_Id;
            PayBox_Id = paybox_Id;
            Date_Pay = date_Pay;
            Amount = amount;
            Photo = photo;
            User_Id = userid;
        }
        public void Remove()
        {
            Status = false;
        }
        public void Activate()
        {
            Status = true;
        }
    }
}