using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Student : Human
	{
		public string Speciality { get; set; }
		public string Group { get; set; }
		public double Rating { get; set; }
		public double Attendance { get; set; }
		public Student
			(
			string last_name, string first_name, int age,
			string speciality, string group, double rating, double attendance
			) : base(last_name, first_name, age)
		{
			Speciality = speciality;
			Group = group;
			Rating = rating;
			Attendance = attendance;
			Console.WriteLine($"SConstructor\t:{this.GetHashCode()}");
		}
		public Student(Human human, string speciality, string group, double rating, double attendance) : base(human)
		{
			Speciality = speciality;
			Group = group;
			Rating = rating;
			Attendance = attendance;
			Console.WriteLine($"SConstructor\t:{this.GetHashCode()}");
		}
		public Student(Student other) : base(other) //здесь нефвно происходит Upcase - преобразование объекта доернего класса в объект базового класса.
		{
			this.Speciality = other.Speciality;
			this.Group = other.Group;
			this.Rating = other.Rating;
			this.Attendance = other.Attendance;
			Console.WriteLine($"SCopyConstructor:{this.GetHashCode()}");
		}
		~Student()
		{
			Console.WriteLine($"SDestructor\t:{this.GetHashCode()}");
		}
		public override void Info()
		{
			base.Info();
			Console.WriteLine($"{Speciality} {Group} {Rating} {Attendance}");
		}
		public override string ToString()
		{
			return base.ToString() +
				$"{Speciality.PadRight(25)}{Group.PadRight(8)}{Rating.ToString().PadRight(8)}{Attendance.ToString().PadRight(8)}";
		}
		public override string ToFileString()
		{
			return base.ToFileString()+$",{Speciality},{Group},{Rating},{Attendance}";
		}

		public static Student FromFileString(string line)
		{
			string[] parts = line.Split(',');
			if (parts.Length != 7) return null;

			string lastName = parts[1];
			string firstName = parts[2];
			if (!int.TryParse(parts[3], out int age)) return null;
			string speciality = parts[4];
			string group = parts[5];
			if (!double.TryParse(parts[6], out double rating)) return null;
			if (!double.TryParse(parts[7], out double attendance)) return null;

			return new Student(firstName, lastName, age, speciality, group, rating, attendance);
		}

	}
}