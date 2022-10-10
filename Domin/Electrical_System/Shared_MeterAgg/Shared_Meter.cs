using _0_Framework.Domain;

namespace Domin.Electrical_System.Shared_MeterAgg
{
    public class Shared_Meter : EntityBase<int>
    {
        public int BoxMeter_Id { get; private set; }
        public string Name { get; private set; }
        public string Cod { get; private set; }
        public bool Use { get; private set; }
        public decimal Rest { get; private set; }
        public decimal Grade { get; private set; }

        public Shared_Meter()
        {
        }

        public Shared_Meter(int boxMeter_Id, string name, string cod, bool use, decimal grade, int user_Id)
        {
            BoxMeter_Id = boxMeter_Id;
            Name = name;
            Cod = cod;
            Use = use;
            Grade = grade;
            User_Id = user_Id;
        }
        public void Edit(int boxMeter_Id, string name, string cod, bool use, decimal grade, int user_Id)
        {
            BoxMeter_Id = boxMeter_Id;
            Name = name;
            Cod = cod;
            Use = use;
            Grade = grade;
            User_Id = user_Id;
        }
        public void Edit(decimal rest)
        {
            Rest = rest;
        }
        public void GradeEdit(decimal grade)
        {
            Grade = grade;
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