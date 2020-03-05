using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using FileManager.Common.Layer;
using log4net;

namespace FileManager.DataAccess.Data
{
	public class TxtFile : VuelingFile
	{
		public new static readonly string path = Environment.GetEnvironmentVariable("txtFile", EnvironmentVariableTarget.Machine).ToString();
		private static readonly ILog logger = LogManager.GetLogger(typeof(TxtFile));

		private readonly TxtUtil txtUtil = new TxtUtil(path);

		public override Student Add(Student student)
		{
			txtUtil.CreateFile();
			student = txtUtil.AppendStudent(student);

			return student;
		}

		public override bool Delete(Student student)
		{
			txtUtil.FileExists();

			List<Student> lista = GetAll();
			if (txtUtil.GetIds().Contains(student.Id))
			{
				int studentOfList = GetAll().FindIndex(std => std.Id == student.Id);
				lista.RemoveAt(studentOfList);
				File.Delete(path);
				foreach (var item in lista)
				{
					Add(item);
				}
				logger.Info("Student: " + student.Id + " Deleted");
				return true;
			}

			return false;
		}

		public override List<Student> GetAll()
		{
			List<Student> list = new List<Student>();
			if (!File.Exists(path))
				return list;
			using (StreamReader streamReader = new StreamReader(path))
			{
				while (!streamReader.EndOfStream)
				{
					string[] values = streamReader.ReadLine().Split(',');
					Student student = new Student(int.Parse(values[0]), values[1], values[2], DateTime.Parse(values[3]));
					list.Add(student);
					logger.Info("Student: " + student.ToString());
				}
			}

			return list;
		}

		public override Student Update(Student student)
		{
			if (!File.Exists(path))
				return null;
			List<Student> list = GetAll();
			if (txtUtil.GetIds().Contains(student.Id))
			{
				int studentIndex = GetAll().FindIndex(std => std.Id == student.Id);
				list.RemoveAt(studentIndex);
				list.Add(student);
				File.Delete(path);
				foreach (var item in list)
				{
					Add(item);
				}
				logger.Info("Student: " + student.ToString() + " updated");
				return student;
			}

			return null;
		}

	}
}
