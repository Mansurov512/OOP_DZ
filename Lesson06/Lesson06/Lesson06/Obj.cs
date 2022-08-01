using Lesson06;


BankAccount Acc1 = new();
Acc1.NumberOfAccount = 1234;
Acc1.BalanceOfAccount = 1_000;
Acc1.AccType = BankAccount.AccountType.Crypt;

BankAccount Acc2 = new();
Acc2.NumberOfAccount = 5678;
Acc2.BalanceOfAccount = 2_000;
Acc2.AccType = BankAccount.AccountType.Debit;

BankAccount Acc3 = new();
Acc3.NumberOfAccount = 5678;
Acc3.BalanceOfAccount = 2_000;
Acc3.AccType = BankAccount.AccountType.Debit;


Console.WriteLine(Acc1 == Acc2);//1ый и 2ой 

Console.WriteLine(Acc2 != Acc3);//2ой и 3ий

Console.WriteLine(String.Empty);//пустая строка


Console.WriteLine(Acc1.Equals(Acc2));//1ый и 2ой

Console.WriteLine(Acc2.Equals(Acc3));//2ой и 3ий

Console.WriteLine(String.Empty);


int a = 1;
int b = 1;

Console.WriteLine(Equals(a, b));//стандартный Equals продолжает работать

Console.WriteLine(String.Empty);

Console.WriteLine(Acc1.GetHashCode());//проверка перегрузки GetHashCode
Console.WriteLine(Acc2.GetHashCode());
Console.WriteLine(Acc3.GetHashCode());

Console.WriteLine(String.Empty);

Console.WriteLine(Acc1.ToString());//проверка перегрузки ToString
Console.WriteLine(Acc2.ToString());
Console.WriteLine(Acc3.ToString());


Console.ReadKey(true);