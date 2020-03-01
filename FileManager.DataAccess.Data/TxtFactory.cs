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
			string cadena = student.Id + ", " + student.Name.Trim() + ", " + student.Surname.Trim() + ", " + student.DateOfBirth.ToString("dd/MM/yyyy");

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
			if(File.Exists(path))
			{
				List<Student> lista = Get();
				if (GetIds().Contains(student.Id))
				{
					int studentOfList = Get().FindIndex(std => std.Id == student.Id);
					lista.RemoveAt(studentOfList);
					File.Delete(path);
					foreach (var item in lista)
					{
						Add(item);
					}
					return true;
				}
			}

			return false;
		}

		public List<Student> Get()
		{
			List<Student> list = new List<Student>();
			if (File.Exists(path))
			{
				using (StreamReader streamReader = new StreamReader(path))
				{
					while (!streamReader.EndOfStream)
					{
						string[] values = streamReader.ReadLine().Split(',');
						list.Add(new Student(int.Parse(values[0]), values[1], values[2], DateTime.Parse(values[3])));
					}
				}
			}

			return list;
		}

		public Student Update(Student student)
		{
			if (File.Exists(path))
			{
				List<Student> lista = Get();
				if (GetIds().Contains(student.Id))
				{
					int studentOfList = Get().FindIndex(std => std.Id == student.Id);
					lista.RemoveAt(studentOfList);
					lista.Add(student);
					File.Delete(path);
					foreach (var item in lista)
					{
						Add(item);
					}
				}
				else
				{
					return null;
				}
			}

			return student;
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
