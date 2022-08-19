using FileManager.Commands;
using FileManager.Commands.Base;

namespace FileManager;

public class FileManagerLogic
{
    private bool _CanWork = true;

    private readonly IUserInterface _UserInterface;

    private readonly static char[] _charsToTrim = { ' ', '*', '\\', '|', '/', '"', ':', '?', '<', '>' };//недопустимые знаки в начале и конце папки

    private readonly static char[] _invalidCharsNameFolder = { '*', '\\', '|', '/', '"', ':', '?', '<', '>' };//недопустимые знаки в названии папки, символ "\" так же недопустим,
                                                                                                              //так как метод используется и в команде переименования
                                                                                                              //существующего каталога
    public DirectoryInfo CurrentDirectory { get; set; } = new("c:\\"); //текущая директория

    public IReadOnlyDictionary<string, FileManagerCommand> Commands { get; }//по ключу будет искать команду,
                                                                            //словарь только для чтения

    public FileManagerLogic(IUserInterface UserInterface)
    {
        _UserInterface = UserInterface;

        var list_dir_command = new PrintDirectoryFilesCommand(UserInterface, this);
        var help_command = new HelpCommand(UserInterface, this);
        var quit_command = new QuitCommand(this);

        Commands = new Dictionary<string, FileManagerCommand>//словарь команд
        {

            { "drives",  new ListDrivesCommand(UserInterface) },//
            { "dir",     list_dir_command },//дублируется команда ListDir
            { "ListDir", list_dir_command },//дублируется команда dir
            { "help",    help_command },
            { "?",       help_command },
            { "quit",    quit_command },
            { "exit",    quit_command },
            { "cd",      new ChangeDirectoryCommand(UserInterface, this) },//смена дирректории
            { "nf",      new CreateNewFolderCommand(UserInterface, this) },//создание новой папки(New Folder)
            { "delf",    new DeleteFolderCommand(UserInterface, this) },//удаление папки(Delete Folder)
            { "renf",    new RenameFolderCommand(UserInterface, this) },//переименование папки(Rename Folder)
            { "ctf",     new CopyFolderCommand(UserInterface, this) },//копирование текущей папки в указанную(Copy To Folder)
            { "mtf",     new MoveDirectoryCommand(UserInterface, this) },//перемещение текущей папки в указанную(Move To Folder)
        };
    }
    // рефлексия - можно использовать для автоматизации добавления команд в словарь

    public string TrimInvalidCharsNewFolderName(string FolderName)//проверка имени каталога на недопустимые символы
    {
        string newFolderName = FolderName.Trim(_charsToTrim);//обрезаем недопустимые знаки начала и конца

        return newFolderName;
    }
    public bool NotHaveInvalidCharsNewNameFolder(string TrimedFolderName)//проверка имени каталога на недопустимые символы
    {
        for (int i = 0; i < TrimedFolderName.Length; i++)
            for (int j = 0; j < _invalidCharsNameFolder.Length; j++)//проверяем наличие недопустимых символов
            {
                if (TrimedFolderName[i] == _invalidCharsNameFolder[j])
                {
                    _UserInterface.WriteLine("Символы * | / \\ \" : ? < > недопустимы в названии. Попробуйте ещё раз.");// конструкция \" обозначает " (одну кавычку), \\ - \ (один слэш)

                    return false;
                }
            }
        return true;
    }

    public void DeleteAndMassage(string FolderName, bool ToDelete)//наверное не имело смысла 2е повторяющиеся строчки в 2ух местах
                                                                  //реализовывать в виде отдельного метода, но решил всё же сделать
    {
        Directory.Delete(FolderName, ToDelete);
        _UserInterface.WriteLine($"Каталог {FolderName} УДАЛЁН.");
    }
    public void CopyDir(string dirFrom, string pathTo)//копирование каталога
    {
        Directory.CreateDirectory(pathTo);
        foreach (string s1 in Directory.GetFiles(dirFrom))
        {
            string s2 = pathTo + "\\" + Path.GetFileName(s1);
            File.Copy(s1, s2);
        }
        foreach (string s in Directory.GetDirectories(dirFrom))
        {
            CopyDir(s, pathTo + "\\" + Path.GetFileName(s));
        }
    }
    public void Start()
    {
        _UserInterface.WriteLine("Файловый менеджер v2.0");

        //var can_work = true;

        do
        {
            var input = _UserInterface.ReadLine("> ", false);

            var args = input.Split(' ');
            var command_name = args[0];



            if (!Commands.TryGetValue(command_name, out var command))
            {
                _UserInterface.WriteLine($"Неизвестная команда {command_name}.");
                _UserInterface.WriteLine("Для справки введите help, для выхода quit");
                continue;//перебрасывает на конец цикла
            }


            try
            {
                command.Execute(args/*[1..]*/);
            }
            catch (Exception error)
            {
                _UserInterface.WriteLine($"При выполнении команды {command_name} произошла ошибка:");
                _UserInterface.WriteLine(error.Message);
            }

        }
        while (_CanWork);


        _UserInterface.WriteLine("Логика файлового менеджера завершена. Всего наилучшего!");

    }

    public void Stop()
    {
        _CanWork = false;
    }

}