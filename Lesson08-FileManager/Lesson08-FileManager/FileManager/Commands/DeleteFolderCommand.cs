using FileManager.Commands.Base;

namespace FileManager.Commands;

public class DeleteFolderCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Удаление указанной директории";

    public DeleteFolderCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        string enteredFolderName = args[1];//Введённый путь каталога

        if (Directory.GetDirectoryRoot(enteredFolderName) != enteredFolderName)//проверка на корневой каталог
        {
            if (Directory.Exists(enteredFolderName))
            {
                DirectoryInfo directory = new DirectoryInfo(enteredFolderName);

                var files_count = 0;
                long total_length = 0;

                foreach (var file in directory.EnumerateFiles())
                {
                    files_count++; //сколько файлов в указанной папке
                    total_length += file.Length;//суммарный размер файлов
                }

                if (files_count > 0 || total_length > 0)
                {
                    _UserInterface.WriteLine($"Папка {enteredFolderName} суммарно содержит {files_count} файл(-ов) " +
                        $"общим размером {total_length / 1024:f3} КилоБайт.");

                    _UserInterface.WriteLine("Вы действительно хотите её удалить? yes/no");

                    string wantToDelete = _UserInterface.ReadLineAnswer();//я не знаю на сколько корректно с точки зрения структуры программы
                                                                          //было  внутри класса/команды делать возможность запрашивать ввод новой
                                                                          //команды в виде ответа yes/no, но очень хотелось реализовать эту возможность

                    if (wantToDelete == "yes")
                    { _FileManager.DeleteAndMassage(enteredFolderName, true); }

                    if (wantToDelete != "yes")
                    {
                        _UserInterface.WriteLine($"Удаление {enteredFolderName} ОТМЕНЕНО.");

                        if (wantToDelete != "no")
                        {
                            _UserInterface.WriteLine($"Введена неверная команда.");
                        }
                    }
                }
                else { _FileManager.DeleteAndMassage(enteredFolderName, true); }
            }
            else { _UserInterface.WriteLine("Каталог не существует или неверная команда"); }
        }
        else { _UserInterface.WriteLine($"Нельзя удалять корневой том ({Directory.GetDirectoryRoot(enteredFolderName)})"); }
    }
}