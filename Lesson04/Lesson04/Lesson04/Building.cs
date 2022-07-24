namespace Builder

{
    public class Building
    {
        private int _number;
        private int _height;
        private int _amountFloors;
        private int _amountApartments;
        private int _amountEntrance;
        private static int _lastNumber;


        public  int GetLastNumber()
        {
            return ++_lastNumber;
                        
        }
        //public int SetLastNumber()
        //{

        //}


        public void SetNumber(int a) //номер дома, прямая установка желаемого номера "руками"
        {
            _number = a;
        }

        public int GetNumber()
        {
            return _number;
        }
        private void SetHeight(int a)//высота дома
        {
            _height = a;
        }

        public int GetHeight()
        {
            return _height;
        }
        private void SetAmountFloors(int a)//количество этажей
        {
            _amountFloors = a;
        }

        public int GetAmountFloors()
        {
            return _amountFloors;
        }
        private void SetAmountApartments(int a)//количество квартир
        {
            _amountApartments = a;
        }

        public int GetAmountApartments()
        {
            return _amountApartments;
        }
        private void SetAmountEntrance(int a)//количество парадных
        {
            _amountEntrance = a;
        }

        public int GetAmountEntrances()
        {
            return _amountEntrance;
        }

        public double HeightOneFloor()//высота этажа
        {
            double a = _height / _amountFloors;
            return a;

        }

        public int AvarageAmountApartsInEntrance()//среднее число квартир в парадной
        {
            int a = _amountApartments / _amountEntrance;
            return a;
        }
        public int AvarageAmountApartsAtFloor()//среднее число квартир на этаже
        {
            int a = _amountApartments / _amountFloors;
            return a;
        }
    }

}