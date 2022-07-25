using Lesson02_4;

BankAccount Acc1 = new();
Acc1.NumberOfAccount = 1234;
Acc1.BalanceOfAccount = 1_000;
Acc1.AccType = BankAccount.AccountType.Debit;

BankAccount Acc2 = new();
Acc2.NumberOfAccount = 5678;
Acc2.BalanceOfAccount = 2_000;
Acc2.AccType = BankAccount.AccountType.Debit;


Acc1.TransferMoneyFromMeTo(Acc2, 1000);

Console.ReadKey(true);



