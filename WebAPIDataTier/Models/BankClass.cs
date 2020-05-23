using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDataTier.Models
{
    public class BankClass
    {
        private static BankClass BankInstance = null;
        private static BankDB.BankDB _bankDB = null;

        private BankClass()
        {
            if(_bankDB == null)
            {
                _bankDB = new BankDB.BankDB();
                makeUsers();
            }
        }

        public static BankClass Instance
        {
            get
            {
                if (BankInstance == null)
                {
                    return new BankClass();
                }
                return BankInstance;
            }
        }

    

        private void makeUsers()
        {
            for(int i = 0; i < 10; i++)
            {
                _bankDB.GetUserAccess().CreateUser();
            }
        }
    }
}