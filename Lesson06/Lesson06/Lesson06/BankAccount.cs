
/*
ЗАДАНИЕ:
Для класса банковский счет переопределить операторы == и != для
сравнения информации в двух счетах. Переопределить метод Equals
аналогично оператору ==, не забыть переопределить метод
GetHashCode(). Переопределить метод ToString() для печати
информации о счете. Протестировать функционирование
переопределенных методов и операторов на простом примере.
*/

/*
КОММЕНТАРИЙ-ВОПРОС:
Я вначале переопределил Equals кодом указанным в самом низу, по примеру из методички ООП урока номер 6 на 21(22) странице.
Там написано "В данном случае это именно перегрузка, потому что ни один из вариантов метода Equals () не принимал 
объект класса Car." При использовании слова "override" компилятор ругался, потому сделал как в методичке, и всё работало.
Тем более в задании написано "Переопределить метод Equals аналогично оператору ==".
Компилятор даже говорил, что есть перегрузка метода.
Но потом я заметил что он подчёркивает зелёным само название моего класа и пишет что мой класс "определяет
операторы "==" и "!=", но не определяет Object.Equals(object o)". Я в итоге разобрался, и сделал как просит компилятор.
А в методичке ошибка получается? Или всё же оба способа имеют право на существование?
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
        /// Сравнение счетов соответственно по значениям всех полей.
        /// </summary>
        /// <param name="Number1">Первый счёт</param>
        /// <param name="Number2">Второй счёт</param>
        /// <returns>Если значения всех полей соответственно равны - true, если нет - false.</returns>
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
        /// <summary>
        /// Сравнение счетов соответственно по значениям всех полей.
        /// </summary>
        /// <param name="Number1">Первый счёт</param>
        /// <param name="Number2">Второй счёт</param>
        /// <returns>Если значения всех полей соответственно НЕ равны - true, если равны - false.</returns>
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
            { return false; }
        }

        /// <summary>
        ///Сравнение эквивалентности двух счетов по всем полям.
        /// </summary>
        /// <param name="obj">Счёт(объект) с которым сравниваем.</param>
        /// <returns>Если значения всех полей соответственно равны - true, если нет - false.</returns>
        public override bool Equals(object obj)//объясните пожалуйста, как исправить чтобы не подчёркивало зелёным. Что-то не верно?
        {
        
            if (obj is not BankAccount Acc)
            {
                return false;

            }
            else
            {
                return (Acc.AccType == this.AccType)
                &&
               (Acc.BalanceOfAccount == this.BalanceOfAccount)
                &&
               (Acc.NumberOfAccount == this.NumberOfAccount);
            }
        }

        /// <summary>
        /// Хэш-код счетов. Для счетов с соответственно одинаковыми значениями полей хэш-код будет одинаковый.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.AccType, this.BalanceOfAccount, this.NumberOfAccount);
        }
        /// <summary>
        /// Возвращает данные по банковскому счёту (объекту)
        /// </summary>
        /// <returns>Номер счёта, тип счёта, баланс счёта, хэш-код счёта</returns>
        public override string ToString()
        {
            return $"{this.NumberOfAccount}, {this.AccType}, {this.BalanceOfAccount}, {this.GetHashCode()}";
        }

        //Первая версия переопределения Equals:
        /*
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
            { return false; }
        */
    }
}









