using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Common.Layer
{
	public class Student
	{
		public int Id { get; }
		public string Name { get; }
		public string Surname { get; }
		public DateTime DateOfBirth { get; }
		public Guid Guid { get; set; }

		public Student(int id, string name, string surname, DateTime dateOfBirth)
		{
			Id = id;
			Name = name;
			Surname = surname;
			DateOfBirth = dateOfBirth;
		}

		public override string ToString()
		{
			return "GUID: "+ Guid + ", id: " + Id + ", Name: " + Name + ", Surname: " + Surname + ", Date of birht: " + DateOfBirth.ToString("dd/MM/yyyy"); 
		}
	}
}
