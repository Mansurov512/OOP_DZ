using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lesson02_4
{

    public class BankAccount4
    {

        private int _numberOfAccount;//номер счёта
        private decimal _balanceOfAccount;//баланс
        public enum AccountType//enum не сделать приватным, иначе не работает программа
        {
            Debit, Credit, Brokerage, Crypt
        }
        private AccountType _accType;//потому для типа счёта создаём поле/переменную на базе созданного enum
                                         //и уже она становится приватной

        public int NumberOfAccount
        {
            get { return _numberOfAccount; }
            set { _numberOfAccount = value; }
        }

        public decimal BalanceOfAccount
        {
            get { return _balanceOfAccount; }
            set { _balanceOfAccount = value; }
        }

        public AccountType AccType
        {
            get { return _accType; }
            set { _accType = value; }

        }

        

    }



}








