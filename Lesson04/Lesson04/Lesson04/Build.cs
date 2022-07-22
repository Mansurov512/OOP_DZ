namespace Builder 

{
    public class Building
    {
        private int _number;
        private int _height;
        private int _amountFloors;
        private int _amountApartments;
        private int _amountEntrance;

        private void SetNumber(int a)
        {
            _number = a;
        }

        public int GetNumber()
        {
            return _number;
        }
        private void SetHeight(int a)
        {
            _height = a;
        }

        public int GetHeight()
        {
            return _height;
        }
        private void SetAmountFloors(int a)
        {
            _amountFloors = a;
        }

        public int GetAmountFloors()
        {
            return _amountFloors;
        }
        private void SetAmountApartments(int a)
        {
            _amountApartments = a;
        }

        public int GetAmountApartments()
        {
            return _amountApartments;
        }
        private void SetAmountEntrance(int a)
        {
            _amountEntrance = a;
        }

        public int GetAmountEntrances()
        {
            return _amountEntrance;
        }

        public double HeightOneFloor()
        {
            double a = _height / _amountFloors;
            return a;

        }

        public int AvarageAmountApartsInEntrance()
        {
            int a = _amountApartments / _amountEntrance;
            return a;
        }
        public int AvarageAmountApartsAtFloor()
        {
            int a = _amountApartments / _amountFloors;
            return a;
        }
    }

}