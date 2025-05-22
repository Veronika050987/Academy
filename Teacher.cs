using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Teacher:Human
	{
		public string Speciality { get; set; }
		public double Experience { get; set; }
		public Teacher
			(
				string lastName, string firstName, int age,
				string speciality, double experience
			) : base(lastName, firstName, age)
		{
			Speciality = speciality;
			Experience = experience;
			Console.WriteLine($"TConstructor: {this.GetHashCode()}");
		}
		~Teacher()
		{
			Console.WriteLine($"TDestructor: {this.GetHashCode()}");
		}

		public override void Info()
		{
			base.Info();
			Console.WriteLine($"{Speciality} {Experience}");
		}
		public override string ToString()
		{
			return base.ToString() + $"{Speciality.PadRight(25)}{Experience.ToString().PadRight(8)}";
		}
		public override string ToFileString()
		{
			return base.ToFileString()+$",{Speciality},{Experience}";
		}

		public static Teacher FromFileString(string line)
		{
			string[] parts = line.Split(',');
			if (parts.Length != 5) return null;

			string lastName = parts[1];
			string firstName = parts[2];
			if (!int.TryParse(parts[3], out int age)) return null;
			string speciality = parts[4];
			if (!int.TryParse(parts[5], out int experience)) return null;

			return new Teacher(firstName, lastName, age, speciality, experience);
		}
	}
}
