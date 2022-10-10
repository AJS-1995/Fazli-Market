using _0_Framework.Domain;

namespace Domin.Electrical_System.General_MeterAgg
{
    public class Operation : EntityBase<int>
    {
        public int GeneralMeter_Id { get; private set; }
        public string Date_Rrad { get; private set; }
        public string Date_Pay { get; private set; }
        public int Grade_Past { get; private set; }
        public int Grade_Now { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Rest { get; private set; }
        public string Photo { get; private set; }

        public Operation()
        {
        }

        public Operation(int generalMeter_Id, string date_Rrad, string date_Pay, int grade_Past, int grade_Now,
            decimal amount, string photo, int user_id)
        {
            GeneralMeter_Id = generalMeter_Id;
            Date_Rrad = date_Rrad;
            Date_Pay = date_Pay;
            Grade_Past = grade_Past;
            Grade_Now = grade_Now;
            Amount = amount;
            Rest = amount;
            Photo = photo;
            User_Id = user_id;
        }
        public void Edit(int generalMeter_Id, string date_Rrad, string date_Pay, int grade_Past, int grade_Now, 
            decimal amount, decimal rest, string photo, int user_id)
        {
            GeneralMeter_Id = generalMeter_Id;
            Date_Rrad = date_Rrad;
            Date_Pay = date_Pay;
            Grade_Past = grade_Past;
            Grade_Now = grade_Now;
            Amount = amount;
            Rest = rest;
            if (!string.IsNullOrWhiteSpace(photo))
                Photo = photo;
            User_Id = user_id;
        }
        public void Edit(decimal rest)
        {
            Rest = rest;
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