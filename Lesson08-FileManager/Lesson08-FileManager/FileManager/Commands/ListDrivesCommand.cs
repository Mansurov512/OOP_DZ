using FileManager.Commands.Base;

namespace FileManager.Commands;

public class ListDrivesCommand : FileManagerCommand//получить список дисков и отобразить их
{
    private readonly IUserInterface _UserInterface;

    public override string Description => "Вывод списка дисков в системе";

    public ListDrivesCommand(IUserInterface UserInterface) => _UserInterface = UserInterface;


    public override void Execute(string[] args)
    {
        var drives = DriveInfo.GetDrives();//получаем диски
        _UserInterface.WriteLine($"В файловой системе существует дисков: {drives.Length}");//кол-во дисков

        foreach (var drive in drives)
        {
            _UserInterface.WriteLine($"    {drive.Name}");//вывод наименований дисков
        }

    }

}