using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAdmin.Domain
{
    public class Person(int id, string firstName, string lastName, DateTime dateOfBirth)
    {
        public int Id { get; set; } = id;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public DateTime DateOfBirth {
            get; set;
        } = dateOfBirth;

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} ({DateOfBirth})";
        }
    }
}
