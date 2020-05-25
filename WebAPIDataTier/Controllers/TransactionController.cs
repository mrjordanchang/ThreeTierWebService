using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDataTier.Models;

namespace WebAPIDataTier.Controllers
{
    public class TransactionController : ApiController
    {
        // GET api/<controller>

        private static BankDB.BankDB myBank = BankClass.bankDB;
        private BankDB.TransactionAccessInterface trans = myBank.GetTransactionInterface();

        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        /*public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [Route("api/Transaction/{sID}/{rID}/{amount}")]
        [HttpGet] 
        public void MakeTransaction(uint sID,uint rID, uint amount)
        {
            trans = myBank.GetTransactionInterface();
            uint transID = trans.CreateTransaction();
            trans.SelectTransaction(transID);
            trans.SetSendr(sID);
            trans.SetRecvr(rID);
            trans.SetAmount(amount);
            myBank.ProcessAllTransactions();
            myBank.SaveToDisk();
        }
    }
}