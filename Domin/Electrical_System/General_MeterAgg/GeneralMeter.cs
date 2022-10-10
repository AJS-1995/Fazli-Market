using _0_Framework.Domain;

namespace Domin.Electrical_System.General_MeterAgg
{
    public class GeneralMeter : EntityBase<int>
    {
        public string Name { get; private set; }
        public string Cod { get; private set; }
        public int Grade { get; private set; }
        public string Date { get; private set; }
        public decimal Rest { get; private set; }

        public GeneralMeter()
        {
        }
        public GeneralMeter(string name, string cod, int grade, string date, int user_id)
        {
            Name = name;
            Cod = cod;
            Grade = grade;
            Date = date;
            User_Id = user_id;
        }
        public void Edit(string name, string cod, int grade, string date, int user_id)
        {
            Name = name;
            Cod = cod;
            Grade = grade;
            Date = date;
            User_Id = user_id;
        }
        public void Edit(decimal rest)
        {
            Rest = rest;
        }
        public void GradeEdit(int grade)
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