using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FileManager.Common.Layer;
using System.Configuration;
using System.IO;

namespace FileManager.DataAccess.Data.Tests
{
	[TestClass()]
	public class XmlFileTests
	{
		public static string path = ConfigurationManager.AppSettings["xmlFile"].ToString();
		public static XmlFile xmlFile;
		public static Student student;

		[TestInitialize]
		public void Setup()
		{
			xmlFile = new XmlFile();
			student = new Student(1, "David", "Jimenez", new DateTime(1992, 6, 24));
		}
		[TestMethod()]
		public void AddTest()
		{
			var spected = xmlFile.Add(student);
			Assert.AreEqual(spected.ToString(), student.ToString());
		}

		[TestMethod()]
		public void DeleteTest()
		{
			xmlFile.Add(student);
			var result = xmlFile.Delete(student);
			Assert.IsTrue(result);
		}

		[TestMethod()]
		public void GetTest()
		{
			xmlFile.Add(student);
			xmlFile.Add(new Student(2, "David", "Jimenez", new DateTime(1992, 6, 24)));
			xmlFile.Add(new Student(3, "David", "Jimenez", new DateTime(1992, 6, 24)));
			var result = xmlFile.Get();
			Assert.IsTrue(result.Count == 3);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Student studentToUpdate = new Student(3, "David", "Prueba", new DateTime(1994, 7, 24));
			xmlFile.Add(student);
			var spected = xmlFile.Update(studentToUpdate);
			Assert.AreEqual(spected.ToString(), studentToUpdate.ToString());
		}
	}
}