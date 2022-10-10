using _0_Framework.Application;
using System;

namespace _0_Framework.Domain
{
    public class EntityBase<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }
        public int User_Id { get; set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
            Status = true;
        }
    }
}