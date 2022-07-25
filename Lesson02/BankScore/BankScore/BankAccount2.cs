using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lesson02_2
{

    public class BankAccount2
    {

        private int _numberOfAccount;//номер счёта
        private decimal _balanceOfAccount;//баланс
        public enum AccountType//enum не сделать приватным, иначе не работает программа
        {
            Debit, Credit, Brokerage, Crypt
        }
        private AccountType _accountType;//потому для типа счёта создаём поле/переменную на базе созданного enum
                                         //и уже она становится приватной
        public void SetAccountType(AccountType accountType)//сеттер типа счёта, устанавливает значения из enum
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
                    //так как вводим значения в сами методы в коде, если я верно понял задание,
                    //то при неверном вводе программа просто не скомпелируется, потому нет смысла в default
            }

        }

        public AccountType GetAccountType()//геттер типа банковского счёта
        {
            return _accountType;

        }
        public void SetNumberOfAccount()//сеттер номера  счёта
        {
            const int acc = 1_000_000_000;
            Random rndnbr = new Random();//объект для генератора (псевдо)случайных чисел
            int a = rndnbr.Next(0, int.MaxValue - acc);
            _numberOfAccount = acc + a;
            //данный генератор создаёт псевдослучайные числа, которые могут повторяться. На сколько понимаю
            //для уникальности чисел нужно было бы создать к примеру какой-то массив/стрингбилдер, в который 
            //записывались все новые номера и перед этим сравнивались с ранее записанными. 
            //Или реализовать какую-то сериализацию номеров в файл. К сожалению не успеваю.

        }

        public long GetNumberOfAccount()//геттер номера  счёта
        {
            return _numberOfAccount;
        }

        public void SetBalanceOfAccount(decimal b) //сеттер баланса
        {
            _balanceOfAccount = b;
        }
        public decimal GetBalanceOfAccount() //геттер баланса
        {
            return _balanceOfAccount;
        }





    }



}








