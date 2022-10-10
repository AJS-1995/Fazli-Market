using _0_Framework.Domain;

namespace Domin.InventoryAgg
{
    public class Inventory:EntityBase<int>
    {
        public string Name { get; private set; }
        public string Location { get; private set; }
        public Inventory(string name, string location,int user_Id)
        {
            Name = name;
            Location = location;
            User_Id = user_Id;
        }
        public void Edit(string name, string location, int user_Id)
        {
            Name = name;
            Location = location;
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