using Lesson02;


    BankAccount firstAccount = new BankAccount();

firstAccount.SetNumberOfAccount(3216_5498_7302_2345);
firstAccount.SetBalanceOfAccount(1_000_000);
firstAccount.SetAccountType(BankAccount.AccountType.Crypt);



Console.WriteLine($"Номер вашего счёта: {firstAccount.GetNumberOfAccount()} " +
                $"\nБаланс вашего счёта: {firstAccount.GetBalanceOfAccount()} тугриков" +
                $"\nТип вашего счёта: {firstAccount.GetAccountType()}");



Console.ReadKey(true);



