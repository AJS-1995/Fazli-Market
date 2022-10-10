using _0_Framework.Domain;

namespace Domin.Locations
{
    public class Location : EntityBase<int>
    {
        public string Name { get; private set; }

        public Location(string name, int user_Id)
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