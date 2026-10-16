using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BusinessEntities
{
    public class User : IdObject
    {
        private string _name;
        private readonly List<string> _tags = new List<string>();
        private int _age;
        private string _email;
        private decimal? _monthlySalary;
        //private string _name;
        private UserTypes _type = UserTypes.Employee;

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name was not provided.");
            }
            _name = name;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        //public string Name
        //{
        //    get => _name;
        //    private set => _name = value;
        //}

        public UserTypes Type
        {
            get => _type;
            private set => _type = value;
        }

        public decimal? MonthlySalary
        {
            get => _monthlySalary;
            private set => _monthlySalary = value;
        }

        public int Age
        {
            get => _age;
            private set => _age = value;
        }

        public IEnumerable<string> Tags
        {
            get => _tags;
            private set => _tags.Initialize(value);
        }

        //public void SetName(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        throw new ArgumentNullException("Name was not provided.");
        //    }
        //    _name = name;
        //}

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) //Can add email format validation here if needed
            {
                throw new ArgumentNullException("Email was not provided.");
            }
            _email = email;
        }

        public void SetType(UserTypes type)
        {
            _type = type;
        }

        public void SetAge(int? age)
        {
            if(!age.HasValue || age.Value < 0)
            {
                throw new ArgumentOutOfRangeException("Age is null or less than zero.");
            }
            _age = age.Value;
        }

        public void SetMonthlySalary(decimal? annualSalary)
        {
            if(!annualSalary.HasValue || annualSalary.Value < 0)
            {
                throw new ArgumentOutOfRangeException("Annual salary is null or less than zero.");
            }

            _monthlySalary = annualSalary.Value / 12;
        }

        public void SetTags(IEnumerable<string> tags)
        {
            _tags.Initialize(tags);
        }
    }
}