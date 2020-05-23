using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDataTier.Models
{
    public static class BankClass
    {
        public static BankDB.BankDB bankDB = new BankDB.BankDB();

        /*public static void MakeTransaction(uint senderAccID, uint receiverAccID, uint amount)
        {
            try
            {
                //Create and then select the transaction
                bankDB.GetTransactionInterface().SelectTransaction(bankDB.GetTransactionInterface().CreateTransaction());
                bankDB.GetTransactionInterface().SetRecvr(senderAccID);
                bankDB.GetTransactionInterface().SetSendr(receiverAccID);
                bankDB.GetTransactionInterface().SetAmount(amount);
                bankDB.ProcessAllTransactions();
                bankDB.SaveToDisk();

                bankDB.GetAccountInterface().SelectAccount(senderAccID);
                System.Diagnostics.Debug.WriteLine(bankDB.GetAccountInterface().GetBalance());
            }
            catch(Exception)
            {

            }
        }*/
    

        /*public static void makeUsers()
        {
            bankDB.GetAccountInterface().SelectAccount(687351891);
            bankDB.GetAccountInterface().Deposit(100);
        }*/

        /*if(_bankDB.GetUserAccess().GetUsers().Count <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                //Making user
                var userId = _bankDB.GetUserAccess().CreateUser();
                _bankDB.GetUserAccess().SelectUser(userId);
                _bankDB.SaveToDisk();

                //Making account
                var accId = _bankDB.GetAccountInterface().CreateAccount(userId);
                _bankDB.GetAccountInterface().SelectAccount(accId);
                _bankDB.SaveToDisk();

                _bankDB.GetAccountInterface().Deposit(100);

                //Save to disk
                _bankDB.SaveToDisk();
                System.Diagnostics.Debug.WriteLine("User ID:" + userId + " Account ID: " + accId);
            }
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("existing records already");
            foreach(uint user in _bankDB.GetUserAccess().GetUsers())
            {
                System.Diagnostics.Debug.WriteLine("User ID:" + user);
                var accId = _bankDB.GetAccountInterface().CreateAccount(user);
                _bankDB.SaveToDisk();
                _bankDB.GetAccountInterface().SelectAccount(accId);
                _bankDB.GetAccountInterface().Deposit(100);
                _bankDB.SaveToDisk();
            }
        }*/
    }
}