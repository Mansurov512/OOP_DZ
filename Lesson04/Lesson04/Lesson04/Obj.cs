using Builder;



Building FirstBuilding = new Building();

FirstBuilding.SetHeight(12);
FirstBuilding.SetAmountEntrance(2);
FirstBuilding.SetAmountApartments(16);
FirstBuilding.SetAmountFloors(4);


Console.WriteLine($"\nНомер дома: {FirstBuilding.GetLastNumber()}");//последовательно ставятся номера здания
Console.WriteLine($"Высота дома: {FirstBuilding.GetHeight()} м");
Console.WriteLine($"Количество подъездов: {FirstBuilding.GetAmountEntrances()}");
Console.WriteLine($"Количество квартир: {FirstBuilding.GetAmountApartments()}");
Console.WriteLine($"Количество этажей: {FirstBuilding.GetAmountFloors()}");
Console.WriteLine($"Высота этажа: {FirstBuilding.HeightOneFloor()} м");
Console.WriteLine($"Среднее число квартир в подъезде: {FirstBuilding.AvarageAmountApartsInEntrance()}");
Console.WriteLine($"Среднее число квартир на этаже: {FirstBuilding.AvarageAmountApartsAtFloor()}");

//Console.WriteLine($"{}");




Building SecondBuilding = new Building();

Console.WriteLine($"\nНомер дома: {SecondBuilding.GetLastNumber()}");//последовательно ставятся номера здания




Building ThirdBuilding = new Building();

Console.WriteLine($"\nНомер дома: {ThirdBuilding.GetLastNumber()}");//последовательно ставятся номера здания



Building FourthBuilding = new Building();

FourthBuilding.SetNumber(636); //Устанавливаем желаемый номер вручную
Console.WriteLine($"\nНомер дома: {FourthBuilding.GetNumber()}");

