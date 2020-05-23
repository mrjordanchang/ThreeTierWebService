using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDataTier.Models;

namespace WebAPIDataTier.Controllers
{
    public class UserController : ApiController
    {
        private static BankDB.BankDB myBank = BankClass.bankDB;
        private BankDB.UserAccessInterface user;
        // GET api/<controller>
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        /*public void Post([FromBody]string value)
        {
        }*/

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [Route("api/User/")]
        [HttpGet]
        public List<UserAccount> GetUsers()
        {
            user = myBank.GetUserAccess();

            List<UserAccount> returnList = new List<UserAccount>();
            List<uint> userList = user.GetUsers();

            foreach(uint users in userList)
            {
                user.GetUserName(out string outfname, out string outlname);
                
                returnList.Add(new UserAccount()
                {
                    userId = users,
                    fname = outfname,
                    lname = outlname
                });
            }
            return returnList;
        }

        [Route("api/User/{userID}/{fname}/{lname}")]
        [HttpGet]
        public void SetUserName(uint userID, string fname, string lname)
        {
            user = myBank.GetUserAccess();
            user.SelectUser(userID);
            user.SetUserName(fname, lname);
            myBank.SaveToDisk();
        }

        [Route("api/User/{fname}/{lname}")]
        [HttpGet]
        public uint MakeUser(string fname, string lname)
        {
            user = myBank.GetUserAccess();
            uint userID = user.CreateUser();
            user.SelectUser(userID);
            user.SetUserName(fname, lname);
            myBank.SaveToDisk();

            return userID;
        }
    }
}