class Program
{
    static void Main(string[] args)
    {
        RationalNumber rn = new RationalNumber(11, 121);
        Console.WriteLine("{0}/{1}", rn.Numerator, rn.Denominator);

        RationalNumber r1 = new RationalNumber(2, 5);
        RationalNumber r2 = new RationalNumber(1, 2);

        RationalNumber add = r1 + r2;   
        RationalNumber sub = r1 - r2;  
        RationalNumber mul = r1 * r2;   
        RationalNumber div = r1 / r2;
    }
}

struct RationalNumber
{
    private int _numerator;
    private int _denominator;

    public int Numerator
    {
        get { return _numerator; }
    }

    public int Denominator
    {
        get { return _denominator; }
    }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("The denominator must be non-zero.");

        if (denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }

        _numerator = numerator;
        _denominator = denominator;

        ReduceToLowestTerms();
    }

    private void ReduceToLowestTerms()
    {
        int greatestCommonDivisor = RationalNumber.GetGCD(_numerator, _denominator);
        _numerator /= greatestCommonDivisor;
        _denominator /= greatestCommonDivisor;
    }

    private static int GetGCD(int term1, int term2)
    {
        if (term2 == 0)
            return term1;
        else
            return GetGCD(term2, term1 % term2);
    }

    //оператор сложения
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber((r1.Numerator * r2.Denominator)
            + (r2.Numerator * r1.Denominator), r1.Denominator * r2.Denominator);
    }

    //оператор вычитания
    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber((r1.Numerator * r2.Denominator)
            - (r2.Numerator * r1.Denominator), r1.Denominator * r2.Denominator);
    }

    //оператор умножения
    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
    }

    //оператор деления
    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
    }
}
