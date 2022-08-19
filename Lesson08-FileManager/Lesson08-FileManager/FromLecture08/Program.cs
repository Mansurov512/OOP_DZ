using NStack;

using Terminal.Gui;


//var file = new FileInfo("c:\\123");//для получения атрибутов файлов

//file.Attributes |= FileAttributes.Archive;// добавляет атрибут архивный
//file.Attributes &= ~FileAttributes.Archive;//удалить атрибут архивный


//var dir = new DirectoryInfo("c:\\123");//получение файла??
//dir.EnumerateFiles()//
//dir.GetFiles();
//var drives = DriveInfo.GetDrives();

////File.Create()
////Directory.EnumerateFiles("c:\\123", "*.*").ToArray();


//Directory.GetFiles("c:\\123", "*.*")//извлекает все файлы сразу, массив на млн файлов и вам передан этот массив
//Directory.EnumerateFiles("c:\\123", "*.*")// по одному файлу из дирректории. Самый эффективный способ.

//if (Directory.GetFiles("c:\\123", "*.*").Length > 0)
//{

//}

//if (Directory.EnumerateFiles("c:\\123", "*.*").Any())//если есть хоть один файл, будет выделена память под его
//                                                     //хранение, даже если миллион там хранится
//                                                     //Enumerate возвращает перечислитель
//{
//    var total_length = Directory.EnumerateFiles("c:\\123", "*.*", SearchOption.AllDirectories)//ищем любые файлы в любых дирректориях в данной папке
//       .Sum(file => file.Length);//суммирование размеров всех файлов
//}


Application.Init();//запуск специального приложения из Terminal.Gui
var top = Application.Top;//требуется для инициализации

var window = new Window("Файловый менеджер")//создаём окно с названием,
                                            //может быть несколько окон
{
    X = 0,                       //настраеваем положение - указываем координаты
    Y = 0,                       //левого верхнего угла
    Width = Dim.Fill(),     //ширина и высота в единицах пакета Terminal.Gui
    Height = Dim.Fill(),    //во весь экран по ширине и высоте

};

top.Add(window); //добавляем наше окно в наш объект


//верхнее меню окна, взято из https://github.com/gui-cs/Terminal.Gui
var menu = new MenuBar(new MenuBarItem[] { //объект с массивом пунктов меню
    new MenuBarItem ("_File", new MenuItem [] { //пункт верхнего меню
        new MenuItem ("_New", "Creates new file", null), //это и ниже пункты внутреннего меню
        new MenuItem ("_Close", "",null),
        new MenuItem ("_Quit", "", () => { if (Quit()) top.Running = false; })//для взаимодействия с пунктами меню
                                                                              //указывается функция, которая будет выполнена
    }),
    new MenuBarItem ("_Edit", new MenuItem [] {
        new MenuItem ("_Copy", "", null),
        new MenuItem ("C_ut", "", null),
        new MenuItem ("_Paste", "", null)
    })
});


static bool Quit()
{
    var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
    return n == 0;
}
top.Add(menu);

//далее ниже в целом создаём визуальные элементы на экране - поля ввода, текстовые метки


var login = new Label("Login: ") { X = 3, Y = 2 };//текстовая метка и её координаты

var password = new Label("Password: ")//метка
{
    X = Pos.Left(login),
    Y = Pos.Top(login) + 1
};
var loginText = new TextField("")
{
    X = Pos.Right(password),//положение
    Y = Pos.Top(login),
    Width = 40              //размер
};
var passText = new TextField("")
{
    Secret = true,          //закрытие звёздочками
    X = Pos.Left(loginText),
    Y = Pos.Top(password),
    Width = Dim.Width(loginText)
};


window.Add(                                 //добавляем на окно все элементы прописанные выше
    login, password, loginText, passText,

    new CheckBox(3, 6, "Remember me"),
    new RadioGroup(3, 8, new ustring[] { "_Personal", "_Company" }, 0),
    new Button(3, 14, "Ok"),
    new Button(10, 14, "Cancel"),
    new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar")
);


Application.Run();
Application.Shutdown();





//Console.WriteLine("End.");
//Console.ReadLine();