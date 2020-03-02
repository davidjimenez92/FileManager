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
			string json = "";
			List<Student> list = new List<Student>();
			if (!File.Exists(path))
			{
				list.Add(student);
				json = JsonConvert.SerializeObject(list.ToArray());
				File.WriteAllText(path, json);
			}
			else
			{
				using (StreamReader reader = new StreamReader(path))
				{
					json = reader.ReadToEnd();
				}
				list = JsonConvert.DeserializeObject<List<Student>>(json);

				list.Add(student);
				json = JsonConvert.SerializeObject(list);
				File.WriteAllText(path, json);
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
				list = JsonConvert.DeserializeObject<List<Student>>(json);

			}
			return list;
		}

		public Student Update(Student student)
		{
			throw new NotImplementedException();
		}
	}
}
