
using System.Linq.Expressions;

namespace UsersAPI.Models
{
    public class UsersDataAccess : IUsersDataAccess
    {
        private readonly UsersDBContext dbContext;
        public UsersDataAccess(UsersDBContext dBContext)
        {
            this.dbContext = dBContext;
        }

        public void AddUser(TblUser user)
        {
            //insert record
            dbContext.Add(user);
            dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            //find the record to be deleted
            var user=dbContext.TblUsers.Find(id);
            if(user != null)
            {
                dbContext.TblUsers.Remove(user);
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Record does not exist");
            }
        }

        public TblUser GetUserById(int id)
        {
            //var users = dbContext.TblUsers.Where(u => u.Id == id).ToList();            
            //users = (from u in dbContext.TblUsers
            //        where u.Id == id
            //        select u).ToList();
            //var user = dbContext.TblUsers
            //                    .Where(u => u.Id == id)
            //                    .SingleOrDefault();

            //get record by id
            var user =dbContext.TblUsers.Find(id);  
            return user;
        }

        public List<TblUser> GetUsers()
        {
            //get all the records
            var users=dbContext.TblUsers.ToList();
            return users;
        }

        public void UpdateUser(TblUser user)
        {
            //find the user

            var u = dbContext.TblUsers.Find(user.Id);
            if(u != null)
            {
                u.Uname = user.Uname;
                u.Email = user.Email;
                u.Pin = user.Pin;

                //save changes
                dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Record does not exist");
            }
        }
    }
}
