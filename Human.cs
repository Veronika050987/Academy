using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Human
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public int Age { get; set; }
		public Human(string lastName, string firstName, int age)
		{
			LastName = lastName;
			FirstName = firstName;
			Age = age;
			Console.WriteLine($"HConstructor:\t{this.GetHashCode()}");
			//snake_case_style - змеиный_стиль_именования_переменных
			//PascalCaseStyle
			//CamelCaseStyle
			//BigCamel
			//smallCamelCaseStyle
		}
		public Human(Human other)
		{
			this.LastName = other.LastName;
			this.FirstName = other.FirstName;
			this.Age = other.Age;

			Console.WriteLine($"HCopyConstructor:\t{this.GetHashCode()}");
		}
		~Human()
		{
			Console.WriteLine($"HDestructor:\t{this.GetHashCode()}");
		}
		public virtual void Info()
		{
			Console.WriteLine($"{LastName} {FirstName} {Age}");
		}

		public override string ToString()
		{
			return (base.ToString()+":").Split('.').Last().PadRight(12)
				+ $"{LastName.PadRight(15)}{FirstName.PadRight(15)}{Age.ToString().PadRight(5)}";
		}

		public virtual string ToFileString()
		{
			return $"{GetType().ToString().Split('.').Last()}:{LastName},{FirstName},{Age}";
		}

		public static Human FromFileString(string line)
		{
			string[] parts = line.Split(',');
			if (parts.Length != 2) return null; // or throw an exception

			string lastName = parts[0];
			string firstName = parts[1];
			if (!int.TryParse(parts[2], out int age)) return null;

			return new Human(lastName, firstName, age);
		}
	}
}
