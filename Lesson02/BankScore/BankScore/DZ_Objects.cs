using Lesson02;
using Lesson02_2;
using Lesson02_4;


BankAccount firstAccount = new BankAccount();//объект для первого задания

firstAccount.SetNumberOfAccount(3216_5498_7302_2345);
firstAccount.SetBalanceOfAccount(1_000_000);
firstAccount.SetAccountType(BankAccount.AccountType.Crypt);



Console.WriteLine($"Номер вашего счёта: {firstAccount.GetNumberOfAccount()} " +
                $"\nБаланс вашего счёта: {firstAccount.GetBalanceOfAccount()} койнов" +
                $"\nТип вашего счёта: {firstAccount.GetAccountType()}\n");


BankAccount2 secondAccount = new BankAccount2();//объект для второго задания

secondAccount.SetNumberOfAccount();
secondAccount.SetBalanceOfAccount(5_000_000);
secondAccount.SetAccountType(BankAccount2.AccountType.Brokerage);



Console.WriteLine($"Номер вашего счёта: {secondAccount.GetNumberOfAccount()} " +
                $"\nБаланс вашего счёта: {secondAccount.GetBalanceOfAccount()} златых" +
                $"\nТип вашего счёта: {secondAccount.GetAccountType()}\n");



BankAccount4 fourthAccount = new BankAccount4();//объект для четвёртого задания

fourthAccount.NumberOfAccount = 123;
fourthAccount.BalanceOfAccount = 500;
fourthAccount.AccType = BankAccount4.AccountType.Debit;


Console.WriteLine($"Номер вашего счёта: {fourthAccount.NumberOfAccount}" +
                  $"\nБаланс вашего счёта: {fourthAccount.BalanceOfAccount} тугриков" +
                  $"\nТип вашего счёта: {fourthAccount.AccType}\n");


Console.ReadKey(true);



