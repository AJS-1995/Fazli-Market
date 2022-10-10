using _0_Framework.Domain;

namespace Domin.Electrical_System.Box_MeterAgg.MeterAgg
{
    public class MOperation : EntityBase<int>
    {
        public int Meter_Id { get; private set; }
        public string Date_Rrad { get; private set; }
        public string Date_Pay { get; private set; }
        public int Grade_Past { get; private set; }
        public int Grade_Now { get; private set; }
        public int Grade { get; private set; }
        public decimal Price { get; private set; }
        public int Complete { get; private set; }
        public int Other { get; private set; }
        public int Total { get; private set; }
        public int Rest { get; private set; }

        public MOperation()
        {
        }

        public MOperation(int meter_Id, string date_Rrad, string date_Pay, int grade_Past, int grade_Now, int grade,
            decimal price, int complete, int other, int total, int user_id)
        {
            Meter_Id = meter_Id;
            Date_Rrad = date_Rrad;
            Date_Pay = date_Pay;
            Grade_Past = grade_Past;
            Grade_Now = grade_Now;
            Grade = grade;
            Price = price;
            Complete = complete;
            Other = other;
            Total = total;
            Rest = total;
            User_Id = user_id;
        }
        public void Edit(int meter_Id, string date_Rrad, string date_Pay, int grade_Past, int grade_Now, int grade,
            decimal price, int complete, int other, int total, int rest, int user_id)
        {
            Meter_Id = meter_Id;
            Date_Rrad = date_Rrad;
            Date_Pay = date_Pay;
            Grade_Past = grade_Past;
            Grade_Now = grade_Now;
            Grade = grade;
            Price = price;
            Complete = complete;
            Other = other;
            Total = total;
            Rest = rest;
            User_Id = user_id;
        }
        public void Edit(int rest)
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