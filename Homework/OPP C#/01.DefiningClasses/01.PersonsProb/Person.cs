using System;

namespace PersonsProb
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name, int age, string email)
            : this(name, age)
        {
            this.Email = email;
        }

        public string Name {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public int Age {
            get { return this.age; }
            set
            {
                if (value <= 0|| value > 100)
                {
                    throw new ArgumentOutOfRangeException("Invalid age! Only [1..100]");
                }
                this.age = value;

            } 
        }

        public string Email {
            get { return this.email; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email cannot be empty!");
                }
                if (!value.Contains("@"))
                {
                    throw new FormatException("This is not valid email!");
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Name : {0}, Age : {1}, Email : {2}",this.Name, this.Age, this.Email);
        }
    }
}
