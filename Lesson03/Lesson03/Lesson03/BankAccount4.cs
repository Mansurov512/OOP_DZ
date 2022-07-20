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
        /// <summary>
        /// Перевод средств со счёта на счёт
        /// </summary>
        /// <param name="AccTo">Счёт(объект) НА который будет перевод</param>
        /// <param name="Amount">Сумма перевода</param>
        /// <returns></returns>
        public bool TransferMoneyFromMeTo(BankAccount4 AccTo, decimal Amount)
        {
            if ((this.AccType == AccTo.AccType) && (this.BalanceOfAccount >= Amount))
            {
                this.BalanceOfAccount -= Amount;
                AccTo.BalanceOfAccount += Amount;
                Console.WriteLine($"Со счёта {this} списано {Amount} у.е." +
                    $"\nБаланс {this} составляет {this.BalanceOfAccount}." +
                    $"\nБаланс {AccTo} составляет {AccTo.BalanceOfAccount}.");

                return true;
            }
            else
            {
                Console.WriteLine("Баланс недостаточен или типы счетов не совпадают.");
                return false;
            }



        }


    }



}








