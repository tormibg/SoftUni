using System.Numerics;

namespace FractionCalculator
{
    using System;

    public struct Fraction
    {
        private BigInteger denominator;

        public Fraction(BigInteger numerator, BigInteger denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public BigInteger Numerator { get; set; }

        public BigInteger Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator can not be zero!");
                }
                if (value < 0)
                {
                    value *= -1;
                    this.Numerator *= -1;
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction fract1, Fraction fract2)
        {

            BigInteger numerator = fract1.Numerator*fract2.Denominator + fract2.Numerator*fract1.Denominator;
            BigInteger denominator = fract1.Denominator*fract2.Denominator;

            return new Fraction(numerator, denominator);

        }

        public static Fraction operator -(Fraction fract1, Fraction fract2)
        {

            BigInteger numerator = fract1.Numerator*fract2.Denominator - fract2.Numerator*fract1.Denominator;
            BigInteger denominator = fract1.Denominator*fract2.Denominator;

            return new Fraction(numerator, denominator);

        }

        public override string ToString()
        {
            return string.Format("{0}", (double)this.Numerator / (double)this.Denominator);
        }
    }
}