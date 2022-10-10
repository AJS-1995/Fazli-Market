using AccountManagement.Domain.RoleAgg;
using System;

namespace Domin.AccountAgg
{
    public class Account
    {
        public int Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool Status { get; private set; }
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public int User_Id { get; set; }
        public int RoleId { get; private set; }
        public Role Role { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account()
        {
        }

        public Account(string fullname, string username, string password, string mobile, int user_id, int roleId,
            string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            User_Id = user_id;
            RoleId = roleId;

            if (roleId == 0)
                RoleId = 2;

            ProfilePhoto = profilePhoto;
            CreationDate = DateTime.Now;
            Status = true;
        }
        public void Edit(string fullname, string username, string mobile, int user_id, int roleId, string profilePhoto)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            User_Id = user_id;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }
        public void ChangePassword(string password)
        {
            Password = password;
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