using _0_Framework.Domain;

namespace Domin.Electrical_System.Box_MeterAgg.MeterAgg
{
    public class MPay : EntityBase<int>
    {
        public int Meter_Id { get; private set; }
        public int MOperation_Id { get; private set; }
        public int PayBox_Id { get; private set; }
        public string Date_Pay { get; private set; }
        public decimal Amount { get; private set; }
        public string Photo { get; private set; }

        public MPay()
        {
        }

        public MPay(int metet_id, int moperation_Id, int paybox_Id, string date_Pay, decimal amount, string photo, int userid)
        {
            Meter_Id = metet_id;
            MOperation_Id = moperation_Id;
            PayBox_Id = paybox_Id;
            Date_Pay = date_Pay;
            Amount = amount;
            Photo = photo;
            User_Id = userid;
        }
        public void Edit(int metet_id, int moperation_Id, int paybox_Id, string date_Pay, decimal amount, string photo, int userid)
        {
            Meter_Id = metet_id;
            MOperation_Id = moperation_Id;
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