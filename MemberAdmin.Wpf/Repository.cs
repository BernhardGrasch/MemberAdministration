using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utils;

namespace MemberAdmin.Core
{
    public class Repository
    {
        private const string _fileName = "members.csv";

        private static Repository _instance;

        List<Person> _members;

        private Repository()
        {
            _members = new List<Person>();
            LoadFromCsv();
        }

        public static Repository GetInstance()
        {
            if (_instance == null)
                _instance = new Repository();

            return _instance;
        }

        private void LoadFromCsv()
        {
            string filePath = MyString.GetFullNameInApplicationTree(_fileName);
            string[] lines = File.ReadAllLines(filePath);
            if (lines != null)
            {
                foreach (var item in lines)
                {
                    string[] parts = item.Split(";");
                    Person member = new Person
                    {
                        FirstName = parts[0],
                        LastName = parts[1],
                        BirthDate = Convert.ToDateTime(parts[2]),
                        Height = Convert.ToInt32(parts[3])
                    };
                    _members.Add(member);
                }
            }
        }

        public void Add(Person member)
        {
            _members.Add(member);
        }

        public void Remove(Person member)
        {
            _members.Remove(member);
        }

        public IEnumerable<Person> GetAll() => _members.ToArray();
    }
}
