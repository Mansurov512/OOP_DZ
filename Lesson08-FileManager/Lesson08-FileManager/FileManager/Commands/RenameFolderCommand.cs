using FileManager.Commands.Base;

namespace FileManager.Commands;

public class RenameFolderCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public override string Description => "Переименование директории. Указать полный путь, а потом на запрос имя.";

    public RenameFolderCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;
    }

    public override void Execute(string[] args)
    {
        var folderPath = args[1];//путь каталога для изменения его имени

        if (Directory.GetDirectoryRoot(folderPath) != folderPath)//проверка на корневой каталог
        {
            if (Directory.Exists(folderPath))
            {
                _UserInterface.WriteLine("Введите новое имя каталога:");

                string newFolderName = _UserInterface.ReadLineAnswer();//я попытался в начале, чтобы менялось имя текущего каталога, но он же получается используется,
                                                                       //потому его нельзя переименовать. Только если принудительно изменять текущий.

                var TrimedFolderName = _FileManager.TrimInvalidCharsNewFolderName(newFolderName);//обрезаем недопустимое

                if (_FileManager.NotHaveInvalidCharsNewNameFolder(TrimedFolderName))//если нет недопустимых знаков, то двигаемся дальше
                {
                    DirectoryInfo directory = new DirectoryInfo(folderPath);

                    string fullPathReNameFolder = Path.Combine(directory.Parent!.FullName, TrimedFolderName);//объединяем путь родительской папки и нового имени

                    if (!Directory.Exists(fullPathReNameFolder))//проверка на существование данной папки
                    {
                        Directory.Move(folderPath, fullPathReNameFolder);//переименование текущего каталога

                        _UserInterface.WriteLine($"Директория {directory.Name} переименована в {TrimedFolderName}");
                        _UserInterface.WriteLine($"Полный путь: {fullPathReNameFolder}");
                    }
                    else { _UserInterface.WriteLine($"Данный каталог уже существует - {fullPathReNameFolder}"); }
                }
            }
            else { _UserInterface.WriteLine("Каталог не существует или неверная команда"); }
        }
        else { _UserInterface.WriteLine($"Нельзя переименовывать корневой том ({Directory.GetDirectoryRoot(folderPath)})"); }
    }
}





