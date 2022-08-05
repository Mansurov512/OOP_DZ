using Lesson07;
using Lesson07_1;
//using Lesson07_2;

ACoder TT = new ACoder();

TT.Encode("КАК тебя зовут? 0139 №;%:?*");
Console.WriteLine("---------------------------");
string a = TT.Decode("ЛБЛ уёва ипгфу? 0139 №;%:?*");

Console.WriteLine("---------------------------");

Console.WriteLine(a);

Console.WriteLine("---------------------------");

BCoder T = new BCoder();
T.Encode("ВАШ пудель мноПрст абвгдЕЁЖЗ? 578 *?%;№:* ");

Console.WriteLine("---------------------------");

T.Decode(T.Encode("ВАШ пудель мноПрст абвгдЕЁЖЗ? 578 *?%;№:* "));



Console.ReadKey(true);
