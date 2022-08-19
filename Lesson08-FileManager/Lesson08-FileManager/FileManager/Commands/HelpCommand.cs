using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Commands.Base;

namespace FileManager.Commands;

public class HelpCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManager;

    public HelpCommand(IUserInterface UserInterface, FileManagerLogic FileManager)
    {
        _UserInterface = UserInterface;
        _FileManager = FileManager;

    }
    public override string Description => "Помощь";
    public override void Execute(string[] args)
    {
        _UserInterface.WriteLine("Файловый менеджер поддерживает следующие команды:");

        int ValueLine = 20;//количество символов включая команду

        foreach (var (name, command) in _FileManager.Commands)
        {

            _UserInterface.Write($"    {name}");
            for (int i = 0; (i + name.Length) != ValueLine; i++)//выравнивание строк
            {
                _UserInterface.Write(" ");
            }
            _UserInterface.WriteLine($"{command.Description}");

        }

    }

}