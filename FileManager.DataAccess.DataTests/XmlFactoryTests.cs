﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data.Tests
{
	[TestClass()]
	public class XmlFactoryTests
	{
		[TestMethod()]
		public void AddTest(TestContext context)
		{
			Student student = new Student(1, "David", "Jimenez", new DateTime(1992, 6, 24));
			Student result = new XmlFile().Add(student);
			Assert.IsTrue(student.Id.Equals(result.Id));
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Assert.Fail();
		}
	}
}