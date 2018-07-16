using System;

namespace Persistence
{
    public class User
    {
        public int? User_ID {set;get;}
        public string Name {set;get;}
        public int? Age {set;get;}
        public string Address {set;get;}
        public string Email {set;get;}
        public string Phone {set;get;}
        public string AccountType {set;get;}
        public string Job {set;get;}
        public string User_Name {set;get;}
        public string Password {set;get;}

        public User() { }

        public User(int? User_ID, string Name, int? Age, string Address, string Email, string Phone, string AccountType,
        string User_Name, string Password)
        {
            this.User_ID = User_ID;
            this.Name = Name;
            this.Age = Age;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.AccountType = AccountType;
            this.User_Name = User_Name;
            this.Password = Password;
        }

        
    }
}