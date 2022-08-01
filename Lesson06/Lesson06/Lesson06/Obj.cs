using Lesson06;


BankAccount Acc1 = new();
Acc1.NumberOfAccount = 1234;
Acc1.BalanceOfAccount = 1_000;
Acc1.AccType = BankAccount.AccountType.Debit;

BankAccount Acc2 = new();
Acc2.NumberOfAccount = 5678;
Acc2.BalanceOfAccount = 2_000;
Acc2.AccType = BankAccount.AccountType.Debit;

BankAccount Acc3 = new();
Acc3.NumberOfAccount = 5678;
Acc3.BalanceOfAccount = 2_000;
Acc3.AccType = BankAccount.AccountType.Debit;


//Acc1.TransferMoneyFromMeTo(Acc2, 1000);

if (Acc1 == Acc2) //1ый и 2ой
{
    Console.WriteLine("Равны\n");
}
else 
{
    Console.WriteLine("Не равны\n");

}

if (Acc2 == Acc3) // 2ой и 3ий
{
    Console.WriteLine("Равны\n");
}
else
{
    Console.WriteLine("Не равны\n");

}

Console.WriteLine(Acc1.Equals(Acc2)); //1ый и 2ой

Console.WriteLine(String.Empty);//

Console.WriteLine(Acc2.Equals(Acc3));// 2ой и 3ий



Console.ReadKey(true);
