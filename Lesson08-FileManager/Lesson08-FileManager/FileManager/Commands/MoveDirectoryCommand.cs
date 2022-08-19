using FileManager.Commands.Base;

namespace FileManager.Commands;

public class MoveDirectoryCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Перемещение содержимого директории";

    public MoveDirectoryCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)

    {
        string pathTo = args[1];//Введённый путь каталога

        if (Directory.Exists(pathTo))
        {
            CopyFolderCommand Copy = new CopyFolderCommand(_UserInterface, _FileManager);

            Copy.Execute(args);//копируем папку

            DirectoryInfo previousCurrentDirectory = _FileManager.CurrentDirectory;//запоминаем текущую дирректорию

            DirectoryInfo newCurrentDirectory = _FileManager.CurrentDirectory.Parent!;

            _FileManager.CurrentDirectory = newCurrentDirectory;//перед удалением принудительно меняем текущую директорию на папку выше,
                                                                //иначе её не удалить

            Directory.SetCurrentDirectory(newCurrentDirectory.FullName);//смена текущей дирректории

            _FileManager.DeleteAndMassage(previousCurrentDirectory.FullName, true);//удаляем дирректорию в которой находились с содержимым

            _UserInterface.WriteLine($"\nИтог: каталог {previousCurrentDirectory.FullName}\nперемещён в   {pathTo}");

            _UserInterface.WriteLine($"\nТекущая директория изменена на {_FileManager.CurrentDirectory.FullName}");
        }
        else { _UserInterface.WriteLine("Каталог не существует или неверная команда"); }
    }
}