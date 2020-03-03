using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using FileManager.Common.Layer;
using Newtonsoft.Json;

namespace FileManager.DataAccess.Data
{

	public class JsonFile : VuelingFile
	{
		private readonly string path = ConfigurationManager.AppSettings.Get("jsonFile");
		public override Student Add(Student student)
		{

			var jsonString = "";
			var studentsList = new List<Student>();
			if (!File.Exists(path))
			{
				studentsList.Add(student);
				jsonString = JsonConvert.SerializeObject(studentsList.ToArray());

				File.WriteAllText(path, jsonString);
			}
			else
			{
				using (var reader = new StreamReader(path))
				{
					jsonString = reader.ReadToEnd();
				}
				studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString) as List<Student>;
				studentsList.Add(student);
				jsonString = JsonConvert.SerializeObject(studentsList);
				foreach (var item in studentsList)
				{
					Debug.WriteLine(item);
				}

				File.WriteAllText(path, jsonString);
			}
			return student;

		}

		public override void CreateFile()
		{
			throw new NotImplementedException();
		}

		public override bool Delete(Student student)
		{
			if (File.Exists(path))
			{
				var jsonString = "";
				using (StreamReader reader = new StreamReader(path))
				{
					jsonString = reader.ReadToEnd();
				}
				List<Student> studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);
				Student studentToRemove = studentsList.Find(x => x.Id == student.Id);
				studentsList.Remove(studentToRemove);

				var json = JsonConvert.SerializeObject(studentsList);
				File.WriteAllText(path, json);

				return true;
			}
			return false;
		}

		public override Student Update(Student student)
		{
			if (File.Exists(path))
			{
				var jsonString = "";
				using (StreamReader reader = new StreamReader(path))
				{
					jsonString = reader.ReadToEnd();
				}
				List<Student> studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);
				Student studentToRemove = studentsList.Find(x => x.Id == student.Id);
				studentsList.Remove(studentToRemove);

				studentsList.Add(student);

				var json = JsonConvert.SerializeObject(studentsList);
				File.WriteAllText(path, json);
			}
			return student;
		}

		public override List<Student> Get()
		{
			if (File.Exists(path))
			{
				var jsonString = "";
				using (var reader = new StreamReader(path))
				{
					jsonString = reader.ReadToEnd();
				}
				var studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);

				return studentsList;
			}
			return null;
		}
	}
}
