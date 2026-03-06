using AzureSQLTest.Models;

namespace AzureSQLTest.Data
{
    public interface IUserInfo
    {
        public List<UserInfo> GetUserInfos();
        public void AddUser(UserInfo user);
        public void DeleteUser(int id);
        public void UpdateUser(UserInfo user);
    }
}
