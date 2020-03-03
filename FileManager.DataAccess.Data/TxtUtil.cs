using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FileManager.Common.Layer;
using log4net;

namespace FileManager.DataAccess.Data
{
	class TxtUtil
	{
		public readonly string path = ConfigurationManager.AppSettings.Get("txtFile");
		private static readonly ILog logger = LogManager.GetLogger(typeof(TxtFile));

		public void CreateFile()
		{
			if (IsFileExist())
				using (File.Create(path)) ;
		}

		public bool IsFileExist()
		{
			return File.Exists(path);
		}

		public Student AppendStudent(Student student, string cadena)
		{
			if (!GetIds().Contains(student.Id))
			{
				using (StreamWriter streamWriter = File.AppendText(path))
				{
					streamWriter.WriteLine(cadena);
					return student;
				}
			}
			logger.Error(student);
			return null;
		}
		public List<int> GetIds()
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
