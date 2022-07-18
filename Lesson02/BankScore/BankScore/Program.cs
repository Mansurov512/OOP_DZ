using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BankScore;


namespace Lesson02
{

    public class BankAccount
    {

        private long _numberOfAccount;
        private decimal _balanceOfAccount;
        public enum AccountType//enum не сделать приватным, иначе не работает программа
        {
            Debit, Credit, Brokerage, Crypt
        }
        private AccountType _accountType;//потому создаём поле/переменную на базе созданного enum
                                         //и уже она становится преватной
        public void SetAccountType(AccountType accountType)//выводит значения из enum
            //можно было бы добавить сообщения о типе счёта на русском
        {

            switch (accountType)
            {
                case AccountType.Debit:
                    _accountType = AccountType.Debit;
                    break;

                case AccountType.Credit:
                    _accountType = AccountType.Credit;
                    break;

                case AccountType.Brokerage:
                    _accountType = AccountType.Brokerage;
                    break;

                case AccountType.Crypt:
                    _accountType = AccountType.Crypt;
                    break;

                    //default:
                    //throw new ArgumentException("нет такого типа");

            }


        }

        public AccountType GetAccountType()
        {
            return _accountType;

        }
        public void SetNumberOfAccount(long a)
        {
            _numberOfAccount = a;

        }

        public long GetNumberOfAccount()
        {
            return _numberOfAccount;
        }

        public void SetBalanceOfAccount(decimal b)
        {
            _balanceOfAccount = b;
        }
        public decimal GetBalanceOfAccount()
        {
            return _balanceOfAccount;
        }





    }



}








