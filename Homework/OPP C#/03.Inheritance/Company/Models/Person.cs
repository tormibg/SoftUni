using Company.Interface;
namespace Company.Models
{
    class Person : IPerson
    {
        //private string id;
        //private string firstName;
        //private string lastName;

        public Person(string id, string firsName, string lastName)
        {
            this.Id = id;
            this.FirstName = firsName;
            this.LastName = lastName;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
