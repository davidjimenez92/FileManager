﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using FileManager.Common.Layer;
using Newtonsoft.Json;

namespace FileManager.DataAccess.Data
{

	public class JsonFile : VuelingFile
	{
		private new readonly string path = Environment.GetEnvironmentVariable("jsonFile", EnvironmentVariableTarget.Machine).ToString();
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

		public override bool Delete(Student student)
		{
			if (!File.Exists(path))
				return false;

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

		public override Student Update(Student student)
		{
			if (!File.Exists(path))
				return null;

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

			return student;
		}

		public override List<Student> GetAll()
		{
			if (!File.Exists(path))
				return new List<Student>();

			var jsonString = "";
			using (var reader = new StreamReader(path))
			{
				jsonString = reader.ReadToEnd();
			}
			var studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonString);

			return studentsList;

		}
	}
}
