using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FileManager.Common.Layer;
using System.IO;

namespace FileManager.DataAccess.Data.Tests
{
	[TestClass()]
	public class TxtFileTests
	{
		public static string path = ConfigurationManager.AppSettings["txtFile"].ToString();
		public static TxtFile txtFile;
		public static Student student;

		[TestInitialize]
		public void Setup()
		{
			txtFile = new TxtFile();
			student = new Student(1, "David", "Jimenez", new DateTime(1992, 6, 24));
		}
		[TestCleanup]
		public void TearDown()
		{
			File.Delete(path);
		}
		[TestMethod()]
		public void AddTest()
		{
			var spected = txtFile.Add(student);
			Assert.AreEqual(spected.ToString(), student.ToString());
		}

		[TestMethod()]
		public void DeleteTest()
		{
			txtFile.Add(student);
			var result = txtFile.Delete(student);
			Assert.IsTrue(result);
		}

		[TestMethod()]
		public void GetTest()
		{
			txtFile.Add(student);
			txtFile.Add(new Student(2, "David", "Jimenez", new DateTime(1992, 6, 24)));
			txtFile.Add(new Student(3, "David", "Jimenez", new DateTime(1992, 6, 24)));
			var result = txtFile.GetAll();
			Assert.IsTrue(result.Count == 3);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Student studentToUpdate = new Student(1, "David", "Prueba", new DateTime(1994, 7, 24));
			txtFile.Add(student);
			var spected = txtFile.Update(studentToUpdate);
			Assert.AreEqual(spected.ToString(), studentToUpdate.ToString());
		}
	}
}