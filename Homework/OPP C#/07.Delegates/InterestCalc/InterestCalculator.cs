namespace InterestCalc
{
    class InterestCalculator
    {
        public delegate decimal GetInterest(decimal sum, decimal interest, int years);

        private readonly GetInterest _getInterest;

        public InterestCalculator(decimal sum, decimal interest, int years, GetInterest getInterest)
        {
            this.Sum = sum;
            this.Interest = interest;
            this.Years = years;
            this._getInterest = getInterest;
        }

        private decimal Sum { get; set; }
        private decimal Interest { get; set; }
        private int Years { get; set; }
        public decimal TSum {
            get { return this._getInterest(this.Sum, this.Interest, this.Years); }
        }
    }
}
