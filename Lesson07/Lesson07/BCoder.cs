//using Lesson07_2;

namespace Lesson07_1;



/// <summary>
/// Меняет каждую букву в тексте на русском языке на букву с тем же порядковым номером с конца. 
/// П(п) не меняется, так как располагается в центре алфавита(17-ая). Символы и пробелы без изменений.
/// </summary>
public class BCoder
{
    public string Encode(string text)
    {
        char[] uppercase = new char[] {'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З',
            'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц',
            'Ч', 'Ш', 'Щ','Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'};//прописные(заглавные) буквы

        char[] lowercase = new char[] {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з',
            'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц',
            'ч', 'ш', 'щ','ъ', 'ы', 'ь', 'э', 'ю', 'я'};//строчные буквы


        char[] entredtext = text.ToCharArray();//переводим введённый текст в массив букв
        char[] returnedtext = new char[text.Length];//пустой массив будущего текста такой же длины


        for (int i = 0; i < entredtext.Length; i++)//перебор каждой буквы введённого текста
        {
            if (Char.IsLetter(entredtext[i]))//проверка буква или нет
            {
                int number = 0;//переменная счётчика цикла поиска индекса буквы в массиве 

                if (Char.IsLower(entredtext[i]))//проверка на регистр
                {
                    while (entredtext[i] != lowercase[number])//находим индекс нужной буквы в массиве
                    {
                        number++;//счётчик
                    }
                  
                    returnedtext[i] = lowercase[^(++number)];//номер буквы с конца
                }
                else
                {
                    while (entredtext[i] != uppercase[number])//находим индекс нужной буквы в массиве
                    {
                        number++;
                    }

                    returnedtext[i] = uppercase[^(++number)];//номер буквы с конца
                }
            }
            else
            {
                returnedtext[i] = entredtext[i];//если символ не буква, то оставляем как есть без изменений
            }
        }
        
        string s = new string(returnedtext);


        Console.WriteLine(s);//для проверки работы
        return s;
    }



    public string Decode(string text)
    {
        return(Encode(text));
    }
}


