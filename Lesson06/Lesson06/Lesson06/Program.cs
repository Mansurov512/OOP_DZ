
/*
Для класса банковский счет переопределить операторы == и != для
сравнения информации в двух счетах. Переопределить метод Equals
аналогично оператору ==, не забыть переопределить метод
GetHashCode(). Переопределить метод ToString() для печати
информации о счете. Протестировать функционирование
переопределенных методов и операторов на простом примере.
*/

namespace Lesson06
{

    public class BankAccount
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
        /// <param name="AccTo">Счёт(объект) НА который будет осуществлён перевод</param>
        /// <param name="Amount">Сумма перевода</param>
        /// <returns></returns>
        public bool TransferMoneyFromMeTo(BankAccount AccTo, decimal Amount)
        {

            if ((this.AccType == AccTo.AccType) && (this.BalanceOfAccount >= Amount))
            {
                this.BalanceOfAccount -= Amount;
                AccTo.BalanceOfAccount += Amount;
                Console.WriteLine($"Со счёта номер {this.NumberOfAccount} списано {Amount} у.е." +
                    $"\nБаланс счёта номер {this.NumberOfAccount} составляет {this.BalanceOfAccount}." +
                    $"\nБаланс счёта номер {AccTo.NumberOfAccount} составляет {AccTo.BalanceOfAccount}.");

                return true;

            }
            else
            {
                Console.WriteLine("Баланс недостаточен или типы счетов не совпадают."); //я так и не понял почему нельзя так использовать консоль

                return false;
            }

        }

        public static bool operator ==(BankAccount Number1, BankAccount Number2)
        {
            if ((Number1.AccType == Number2.AccType)
                &&
                (Number1.BalanceOfAccount == Number2.BalanceOfAccount)
                 &&
                (Number1.NumberOfAccount == Number2.NumberOfAccount))
            {
                return true;
            }
            else
            { return false; }

        }
        public static bool operator !=(BankAccount Number1, BankAccount Number2)
        {
            if ((Number1.AccType != Number2.AccType)
                ||
               (Number1.BalanceOfAccount != Number2.BalanceOfAccount)
                ||
               (Number1.NumberOfAccount != Number2.NumberOfAccount))
            {
                return true;
            }
            else
            { return false;}
        }

     /// <summary>
     ///Сравнение эквивалентности двух счетов
     /// </summary>
     /// <param name="obj">Счёт(объект) с которым сравниваем</param>
     /// <returns></returns>
        public bool Equals(BankAccount obj)
        {
            if ((obj.AccType == this.AccType)
                &&
               (obj.BalanceOfAccount == this.BalanceOfAccount)
                &&
               (obj.NumberOfAccount == this.NumberOfAccount))
            {
                return true;
            }
            else
            { return false;}


        }
    }

    //return Equals(Acc1, Acc2);

}








