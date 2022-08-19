using FileManager.Commands.Base;

namespace FileManager.Commands;

public class CreateNewFolderCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Создание новой директории в текущей. Ввести имя.";

    public CreateNewFolderCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        var FolderName = args[1];//Введённое имя каталога

        var TrimedFolderName = _FileManager.TrimInvalidCharsNewFolderName(FolderName);//обрезаем недопустимое

        if (_FileManager.NotHaveInvalidCharsNewNameFolder(TrimedFolderName))//если нет недопустимых знаков, то двигаемся дальше
        {          
            string fullPathNewFolder = Path.Combine(_FileManager.CurrentDirectory.FullName, TrimedFolderName);

            if (Directory.Exists(fullPathNewFolder))
            {
                _UserInterface.WriteLine($"Данный каталог уже существует - {fullPathNewFolder}");
            }
            else
            {
                Directory.CreateDirectory($"{_FileManager.CurrentDirectory.FullName}/{TrimedFolderName}");//создаём каталог

                _UserInterface.WriteLine($"Создана директория {TrimedFolderName}");
                _UserInterface.WriteLine($"Полный путь: {fullPathNewFolder}");
            }
        }
    }
}