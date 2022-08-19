namespace FileManager;

public interface IUserInterface
{
    //void Write(string str);

    void WriteLine(string str);
    void Write(string str);

    string ReadLine(string? Prompt, bool PromptNewLine = true); //пользователю будет выведена строка если она указана
                                                                //и дальше чтение строки с экрана(интерфейса пользователя)
    string ReadLineAnswer(); //ожидание ответа на вопрос
      
    int ReadInt(string? Prompt, bool PromptNewLine = true);

    double ReadDouble(string? Prompt, bool PromptNewLine = true);


}