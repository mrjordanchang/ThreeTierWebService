using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDataTier.Models;

namespace WebAPIDataTier.Controllers
{
    public class AccountController : ApiController
    {
        private static BankDB.BankDB myBank = BankClass.bankDB;
        private BankDB.AccountAccessInterface acc = myBank.GetAccountInterface();

        [Route("api/Account/Deposit/{accID}/{amount}")]
        [HttpGet]
        public void DepositMoneyy(uint accID, uint amount)
        {
            acc.SelectAccount(accID);
            acc.Deposit(amount);
            myBank.SaveToDisk();
        }

        [Route("api/Account/Withdraw/{accID}/{amount}")]
        [HttpGet]
        public void WithdrawMoney(uint accID, uint amount)
        {
            acc.SelectAccount(accID);
            acc.Withdraw(amount);
            myBank.SaveToDisk();
        }

        [Route("api/Account/Create/{userID}")]
        [HttpGet]
        public void CreateAccount(uint userID)
        {
            uint accID = acc.CreateAccount(userID);
            myBank.SaveToDisk();
        }

        [Route("api/Account/Find/{accountID}")]
        [HttpGet]
        public AccountClass GetAccountDetails(uint accountID)
        {
            acc.SelectAccount(accountID);
            uint userID = acc.GetOwner();
            uint balance = acc.GetBalance();

            return new AccountClass()
            {
                id = accountID,
                userID = userID
            };
        }

        [Route("api/Account/FindAll/{userID}")]
        [HttpGet]
        public List<AccountClass> GetAllAccounts(uint userID)
        {
            List<uint> accList = acc.GetAccountIDsByUser(userID);
            List<AccountClass> returnedList = new List<AccountClass>();

            foreach(uint account in accList)
            {
                acc.SelectAccount(account);
                returnedList.Add(new AccountClass()
                {
                    userID = userID,
                    bal = acc.GetBalance(),
                    id = account
                });
            }
            return returnedList;
        }
    }
}