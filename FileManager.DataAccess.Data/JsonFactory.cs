using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FileManager.Common.Layer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FileManager.DataAccess.Data
{
	
	public class JsonFactory : IFileFactory
	{
		private readonly string path = ConfigurationManager.AppSettings.Get("jsonFile");
		public Student Add(Student student)
		{
			List<Student> list = new List<Student>();
			if (!File.Exists(path))
			{
				list.Add(student);
				using (StreamWriter streamWriter = new StreamWriter(path, true))
				{
					list.Add(student);
					string JsonResult = JsonConvert.SerializeObject(list);
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
			throw new NotImplementedException();
		}

		public Student Update(Student student)
		{
			throw new NotImplementedException();
		}
	}
}
