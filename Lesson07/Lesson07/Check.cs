using Lesson07;
using Lesson07_1;
using Lesson07_2;

ACoder Shift = new ACoder();//объект кодировщика со сдвигом

Shift.Encode("КАК тебя зовут? 0139 №;%:?*");//обычная строка

Console.WriteLine("---------------------------");

string CheckShift = Shift.Decode("ЛБЛ уёва ипгфу? 0139 №;%:?*");//закодированная строка строка


Console.WriteLine("---------------------------");

Console.WriteLine(CheckShift);//проверка что выдаёт именно расшифрованное значение в конце

Console.WriteLine("---------------------------");



BCoder Reverse = new BCoder();//объект кодировщика с "зеркаливанием" номера буквы

Reverse.Encode("ВАШ пудель мноПрст абвгдЕЁЖЗ? 578 *?%;№:* ");//обычная строка

Console.WriteLine("---------------------------");

Reverse.Decode(Reverse.Encode("ВАШ пудель мноПрст абвгдЕЁЖЗ? 578 *?%;№:* "));//сдвоенная проверка работы



Console.ReadKey(true);