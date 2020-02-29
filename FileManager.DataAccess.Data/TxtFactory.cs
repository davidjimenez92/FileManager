using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
	public class TxtFactory : IFileFactory
	{
		public string path = ConfigurationManager.AppSettings.Get("txtFile");

		public Student Add(Student student)
		{
			string cadena = student.Id + ", " + student.Name + ", " + student.Surname + ", " + student.DateOfBirth.ToString("dd/MM/yyyy");

			if (!File.Exists(path))
			{
				using (StreamWriter streamWriter = File.CreateText(path))
				{
					streamWriter.WriteLine(cadena);
				}
			}
			else
			{
				student = AppendStudent(student, cadena);
			}
			return student;
		}

		public bool Delete(Student student)
		{
			throw new NotImplementedException();
		}

		public List<Student> Get()
		{
			throw new NotImplementedException();
		}

		public Student Update(Student student)
		{
			throw new NotImplementedException();
		}

		private Student AppendStudent(Student student, string cadena)
		{
			if (!GetIds().Contains(student.Id))
			{
				using (StreamWriter streamWriter = File.AppendText(path))
				{
					streamWriter.WriteLine(cadena);
				}
			}
			else
			{
				return null;
			}
			return student;
		}

		private List<int> GetIds()
		{
			string[] array = File.ReadAllLines(path);
			List<int> list = new List<int>();
			foreach (var line in array)
			{
				string[] values = line.Trim().Split(',');
				list.Add(int.Parse(values[0]));
			}
			return list;
		}


	}
}
