using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersAPI
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("clients-allowed")]
    public class UsersController : ControllerBase
    {

        private readonly IUsersDataAccess dal;
        public UsersController(IUsersDataAccess dal)
        {   
            this.dal = dal;
        }


        // GET: api/<UsersController>
        [HttpGet]
        [Route("getusers")]
        public IEnumerable<TblUser> Get()
        {       
            var lstUsers=dal.GetUsers();
            return lstUsers;
        }

        /// <summary>
        /// Gets a specific user by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The requested user.</returns>
        // GET api/<UsersController>/5
        [HttpGet]
        [Route("getuserbyid/{id}")]
        public TblUser Get(int id)
        {
            var user=dal.GetUserById(id);
            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        [Route("adduser")]
        public void Post([FromBody] TblUser user)
        {
            dal.AddUser(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        [Route("updateuser/{id}")]
        public void Put(int id, [FromBody] TblUser user)
        {
            dal.UpdateUser(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete]
        [Route("deleteuser/{id}")]
        public void Delete(int id)
        {
            dal.DeleteUser(id);
        }
    }
}
