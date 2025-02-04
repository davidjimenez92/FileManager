﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Layer;
using System.Configuration;
using System.IO;

namespace FileManager.DataAccess.Data.Tests
{
	[TestClass()]
	public class JsonFileTests
	{
		public static string path = ConfigurationManager.AppSettings["jsonFile"].ToString();
		public static JsonFile jsonFile;
		public static Student student;


		[TestInitialize]
		public void Setup() {
			jsonFile = new JsonFile();
			student = new Student(1, "David", "Jimenez", new DateTime(1992, 6, 24));
		}
		[TestCleanup]
		public void TestCleanup()
		{
			File.Delete(path);
		}
		[TestMethod()]
		public void AddTest()
		{
			var spected = jsonFile.Add(student);
			Assert.AreEqual(spected, student);
		}

		[TestMethod()]
		public void DeleteTest()
		{
			jsonFile.Add(student);
			var result = jsonFile.Delete(student);
			Assert.IsTrue(result);
		}

		[TestMethod()]
		public void GetTest()
		{
			jsonFile.Add(student);
			jsonFile.Add(new Student(2, "David", "Jimenez", new DateTime(1992, 6, 24)));
			jsonFile.Add(new Student(3, "David", "Jimenez", new DateTime(1992, 6, 24)));
			var result = jsonFile.GetAll();
			Assert.IsTrue(result.Count == 3);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Student studentToUpdate = new Student(1, "David", "Prueba", new DateTime(1994, 7, 24));
			jsonFile.Add(student);
			var spected = jsonFile.Update(studentToUpdate);
			Assert.AreEqual(spected.ToString(), studentToUpdate.ToString());
		}
	}
}