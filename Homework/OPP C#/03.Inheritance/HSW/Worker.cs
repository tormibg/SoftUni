namespace HSW
{
    class Worker : Human
    {
        private float weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, float weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public float MoneyPerHour()
        {
            return (this.WeekSalary / (this.WorkHoursPerDay*5));
        }
    }
}
