namespace UsersAPI.Models
{
    public interface IUsersDataAccess
    {
        List<TblUser> GetUsers();
        TblUser GetUserById(int id);
        void AddUser(TblUser user);
        void DeleteUser(int id);
        void UpdateUser(TblUser user);
    }
}
