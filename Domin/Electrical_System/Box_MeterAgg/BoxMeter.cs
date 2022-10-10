using _0_Framework.Domain;

namespace Domin.Electrical_System.Box_MeterAgg
{
    public class BoxMeter : EntityBase<int>
    {
        public string Name { get; private set; }

        public BoxMeter()
        {
        }

        public BoxMeter(string name, int user_Id)
        {
            Name = name;
            User_Id = user_Id;
        }
        public void Edit(string name, int user_Id)
        {
            Name = name;
            User_Id = user_Id;
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