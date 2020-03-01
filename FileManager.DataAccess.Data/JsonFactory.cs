using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FileManager.Common.Layer;
using Newtonsoft.Json;

namespace FileManager.DataAccess.Data
{

	public class JsonFactory : StudentDao
	{
		private readonly string path = ConfigurationManager.AppSettings.Get("jsonFile");
		public Student Add(Student student)
		{
			List<Student> list = Get();
			if (!File.Exists(path))
			{
				using (StreamWriter streamWriter = new StreamWriter(path, true))
				{
					string JsonResult = JsonConvert.SerializeObject(student);
					streamWriter.WriteLine(JsonResult.ToString());
				}
			}
			return student;
		}

		public bool Delete(Student student)
		{
			throw new NotImplementedException();
		}

		public List<Student> Get()
		{
			List<Student> list = new List<Student>();
			if (File.Exists(path))
			{
				string json = File.ReadAllText(path);
				Student std = JsonConvert.DeserializeObject<Student>(json);
				list.Add(std);

			}
			return list;
		}

		public Student Update(Student student)
		{
			throw new NotImplementedException();
		}
	}
}
