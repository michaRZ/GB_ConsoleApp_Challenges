using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreetings_Repository
{
    public class Customer
    {
        // CONSTRUCTORS
        public Customer() { }
        public Customer(string firstName, string lastName, Type typeOfCustomer)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
        }


        // PROPERTIES
        public string emailMessage;
        private string _first;
        private string _last;
        public string FirstName 
        {
            get
            {
                return _first;
            }
            set
            {
                _first = value.ToUpper();
            }
        }
        public string LastName 
        {
            get
            {
                return _last;
            }
            set
            {
                _last = value.ToUpper();
            }
        }
        public Type TypeOfCustomer { get; set; }
        public string Email
        {
            get
            {
                switch (TypeOfCustomer)
                {
                    case Type.current:
                        return emailMessage = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";                      
                    case Type.past:
                        return emailMessage = "It's been a long time since we've heard from you, we want you back.";
                    case Type.potential:
                        return emailMessage = "We currently have the lowest rates on Helicopter Insurance!";
                    default:
                        return string.Empty;

                }
            }
        }

    }

}
public enum Type { current = 1, potential, past }

