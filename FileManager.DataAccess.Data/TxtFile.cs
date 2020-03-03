using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FileManager.Common.Layer;
using log4net;

namespace FileManager.DataAccess.Data
{
	public class TxtFile : VuelingFile
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof(TxtFile));
		private readonly TxtUtil txtUtil = new TxtUtil();

		public override Student Add(Student student)
		{
			string cadena = student.Id + ", " + student.Name.Trim() + ", " + student.Surname.Trim() + ", " + student.DateOfBirth.ToString("dd/MM/yyyy");

			txtUtil.CreateFile();
			student = txtUtil.AppendStudent(student, cadena);

			logger.Info(student);
			return student;
		}

		public override bool Delete(Student student)
		{
			if (File.Exists(path))
			{
				List<Student> lista = Get();
				if (txtUtil.GetIds().Contains(student.Id))
				{
					int studentOfList = Get().FindIndex(std => std.Id == student.Id);
					lista.RemoveAt(studentOfList);
					System.IO.File.Delete(path);
					foreach (var item in lista)
					{
						Add(item);
					}
					logger.Info("Student: " + student.Id + " Deleted");
					return true;
				}
			}

			return false;
		}

		public override List<Student> Get()
		{
			List<Student> list = new List<Student>();
			if (txtUtil.IsFileExist())
			{
				using (StreamReader streamReader = new StreamReader(path))
				{
					while (!streamReader.EndOfStream)
					{
						string[] values = streamReader.ReadLine().Split(',');
						Student student = new Student(int.Parse(values[0]), values[1], values[2], DateTime.Parse(values[3]));
						list.Add(student);
						logger.Info(student);
					}
				}
			}

			return list;
		}

		public override Student Update(Student student)
		{
			if (File.Exists(path))
			{
				List<Student> lista = Get();
				if (txtUtil.GetIds().Contains(student.Id))
				{
					int studentOfList = Get().FindIndex(std => std.Id == student.Id);
					lista.RemoveAt(studentOfList);
					lista.Add(student);
					File.Delete(path);
					foreach (var item in lista)
					{
						Add(item);
					}
					logger.Info(student);
					return student;
				}
			}

			return null;
		}


		
	}
}
