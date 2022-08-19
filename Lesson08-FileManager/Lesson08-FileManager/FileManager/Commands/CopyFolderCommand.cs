using FileManager.Commands.Base;

namespace FileManager.Commands;

public class CopyFolderCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Копирование директории по указанному пути";

    public CopyFolderCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        string pathTo = args[1];//Введённый путь каталога

        if (Directory.Exists(pathTo))
        {
            string fullPathNewFolder = Path.Combine(pathTo, _FileManager.CurrentDirectory.Name);

            Directory.CreateDirectory(fullPathNewFolder);//создаём папку в папке назначения с тем же именем что и у текущей

            _FileManager.CopyDir(_FileManager.CurrentDirectory.FullName, fullPathNewFolder);//копируем в неё содержимое текущей
                        
            _UserInterface.WriteLine($"Папка         {_FileManager.CurrentDirectory.FullName}\nскопирована в {pathTo}");
        }
        else { _UserInterface.WriteLine("Каталог не существует или неверная команда"); }
    }
}