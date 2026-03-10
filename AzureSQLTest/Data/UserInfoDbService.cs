using AzureSQLTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureSQLTest.Data
{
    public class UserInfoDbService : IUserInfo
    {
        private UserInfoDbContext Context { get; set; }
        public UserInfoDbService(UserInfoDbContext context)
        {
            Context = context;
        }

        public List<UserInfo> GetUserInfos()
        {
            return Context.UserInfo.ToList();
        }

        public void AddUser(UserInfo user)
        {
            Context.Add(user);
            Context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var existing = Context.UserInfo.Find(id);
            if (existing != null)
            {
                Context.Remove(existing); // ← should be existing, not id
                Context.SaveChanges();
            }
        }

        public void UpdateUser(UserInfo user)
        {
            var existing = Context.UserInfo.Find(user.Id);
            if (existing != null)
            {
                existing.Username = user.Username;
                existing.Password = user.Password;
                existing.Admin = user.Admin;
                Context.SaveChanges();
            }
        }
    }
}
