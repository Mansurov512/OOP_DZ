namespace OOP
{
    public struct RationalNumber
    {

        public int _numerator;// Числитель
        public int _denominator;// Знаменатель
        public double Rational => (double)_numerator / (double)_denominator;

        public int Numerator { get => _numerator; }
        public int Denominator { get => _denominator; }

        public RationalNumber(int Numerator, int Denominator)
        {
            if (Denominator == 0)
                throw new ArgumentException("Нельзя делить на ноль");

            if (Denominator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }

            _numerator = Numerator;
            _denominator = Denominator;

            // ReduceToLowestTerms();

        }

        public static implicit operator double(RationalNumber r1) => r1.Rational;
        public static implicit operator RationalNumber(int r1) => new RationalNumber(r1, 1);

        //public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        //{

        //    return new RationalNumber((r1.Numerator * r2.Denominator)
        //    + (r2.Numerator * r1.Denominator), r1.Denominator * r2.Denominator);
        //}


        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }
    }
}