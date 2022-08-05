using Lesson07_2;

namespace Lesson07;

/// <summary>
/// Меняет каждую букву в тексте на русском языке на следующую в алфавите. 
/// Я(я) меняет на А(а). Символы и пробелы без изменений.
/// </summary>
public class ACoder : ICoder
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

                    if (entredtext[i] == lowercase[^1])//если последняя буква массива ('я')
                    { returnedtext[i] = lowercase[0]; }//то устанавливается 1-я буква массива ('а')
                    else { returnedtext[i] = lowercase[++number]; }//устанавливается индекс на 1 больше
                                                                  //использую именно префикс
                }
                else
                {
                    while (entredtext[i] != uppercase[number])//находим индекс нужной буквы в массиве
                    {
                        number++;
                    }

                    if (entredtext[i] == uppercase[^1])//если последняя буква массива ('Я')
                    { returnedtext[i] = uppercase[0]; }//то устанавливается 1-я буква массива ('А')
                    else { returnedtext[i] = uppercase[++number]; }//устанавливается индекс на 1 больше
                                                                   //использую именно префикс
                }
            }
            else
            {
                returnedtext[i] = entredtext[i];//если символ не буква, то оставляем как есть без изменений
            }
        }

        string returnedstring = new string(returnedtext);//преобразование массива char в строку типа string

        Console.WriteLine(returnedstring);//для проверки работы
        return returnedstring;
    }
    public string Decode(string text)//декодер можно было скопипастить с кодера и чуть изменить пару значений
                                     //в обратную сторону, но так не интересно - чисто для демонстрации можно
                                     //же строчку по кругу прогнать по алфавиту, используя сам кодер, и получить
                                     //требуемый результат с исходным текстом=)
    {
        for (int i = 01; i < 33; i++)
        {
            Console.Write($"{i} ");
             text = Encode(text);
        }

         return text;
    }
}