using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	class Graduate : Student
	{
		public string Subject { get; set; }
		public Graduate
			(
			string last_name, string first_name, int age,
			string speciality, string group, double rating, double attendance,
			string subject
			) : base(last_name, first_name, age, speciality, group, rating, attendance)
		{
			Subject = subject;
			Console.WriteLine($"GConstructor:{this.GetHashCode()}");
		}
		public Graduate(Student student, string subject) : base(student)
		{
			Subject = subject;
			Console.WriteLine($"GConstructor:{this.GetHashCode()}");
		}
		~Graduate()
		{
			Console.WriteLine($"GDestructor:{this.GetHashCode()}");
		}
		public override void Info()
		{
			base.Info();
			Console.WriteLine($"\t{Subject}");
		}

		public override string ToString()
		{
			return base.ToString() + Subject;
		}
		public override string ToFileString()
		{
			return base.ToFileString() + $",{Subject}";
		}

		public static Graduate FromFileString(string line)
		{
			string[] parts = line.Split(',');
			if (parts.Length != 8) return null;

			string lastName = parts[1];
			string firstName = parts[2];
			if (!int.TryParse(parts[3], out int age)) return null;
			string speciality = parts[4];
			string group = parts[5];
			if (!double.TryParse(parts[6], out double rating)) return null;
			if (!double.TryParse(parts[7], out double attendance)) return null;
			string subject = parts[8];

			return new Graduate(firstName, lastName, age, speciality, group, rating, attendance, subject);
		}
	}
}
