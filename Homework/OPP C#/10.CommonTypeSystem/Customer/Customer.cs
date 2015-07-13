using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {

        //first name, middle name and last name, ID (EGN), permanent address, mobile phone, e-mail, list of payments and customer type. 
        //private string firstName;
        //private string middleName;
        //private string lastName;
        //private string id;
        //private string permAddress;
        //private string mobPhone;
        //private string eMail;
        //private List<Payment> paymantsList;
        //private CustomerType cusType;

        public Customer(string firstName, string middleName, string lastName, string id, string permAddress, string mobPhone, string eMail, CustomerType cusType, List<Payment> list)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.PermAddress = permAddress;
            this.MobPhone = mobPhone;
            this.EMail = eMail;
            this.CusType = cusType;
            this.PaymantsList = list;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public string PermAddress { get; set; }
        public string MobPhone { get; set; }
        public string EMail { get; set; }
        public List<Payment> PaymantsList { get; set; }
        public CustomerType CusType { get; set; }

        public override bool Equals(object obj)
        {
            Customer tmpCustomer = obj as Customer;
            if (tmpCustomer == null)
            {
                return false;
            }
            if (tmpCustomer.ID == this.ID)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }

        public object Clone()
        {
            var newPaymantsList = new List<Payment>();
            newPaymantsList = this.PaymantsList.Select(x => x.Clone()).Cast<Payment>().ToList();
            return new Customer(this.FirstName, this.MiddleName, this.LastName, this.ID, this.PermAddress, this.MobPhone,
                this.EMail, this.CusType, newPaymantsList);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(String.Format("Customer ID:{0}(Name: {1} {2} {3}, Address: {4}, Mobile phone: {5}, Email: {6}, Type: {7}", this.ID, this.FirstName, this.MiddleName, this.LastName, this.PermAddress, this.MobPhone, this.EMail, this.CusType));
            output.AppendLine(new string('-', 5) + "Payments:");
            foreach (var payment in this.PaymantsList)
            {
                output.AppendLine(new string('-', 2) + payment.ProdName + ":" + payment.ProdPrice);
            }
            return output.ToString();
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return Equals(c1, c2);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !Equals(c1, c2);
        }

        public int CompareTo(Customer other)
        {
            if (other == null)
            {
                throw new ArgumentException("Customer is null");
            }
            int compar = String.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal);
            if (compar == 0)
            {
                compar = String.Compare(this.MiddleName, other.MiddleName, StringComparison.Ordinal);
                if (compar == 0)
                {
                    compar = String.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
                    if (compar == 0)
                    {
                        return String.Compare(this.ID, other.ID, StringComparison.Ordinal);
                    }
                    return compar;
                }
                return compar;
            }
            return compar;
        }
    }
}