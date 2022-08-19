using FileManager;

var console_ui = new ConsoleUserInterface();

var manager = new FileManagerLogic(console_ui);

manager.Start();//запуск файлового менеджера

Console.WriteLine("Завершено.");
Console.ReadKey(true); 