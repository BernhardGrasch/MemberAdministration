using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MemberAdmin.Core
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Height { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
