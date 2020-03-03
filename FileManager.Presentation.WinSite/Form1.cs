using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using FileManager.Common.Layer;
using FileManager.DataAccess.Data;

namespace FileManager.Presentation.WinSite
{
	public partial class Form1 : Form
	{
		private const string TITLE = "FILE MANAGER";

		public Form1()
		{

			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (var item in Enum.GetValues(typeof(EnumTypes)))
			{
				cbType.Items.Add(item);
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			Student student = CreateStudent();
			EnumTypes ty = (EnumTypes)cbType.SelectedItem;

			IAbstractFactory factory = FactoryProvider.GetFactory(this.ProductName);
			VuelingFile file = factory.Create(ty);
			if (file.Add(student) != null)
			{
				MessageBox.Show("Student: " + student.Id + " added", TITLE);
			}
			else
			{
				MessageBox.Show("Student: " + student.Id + " can not added", TITLE);
			}
		}

		private void BtnRead_Click(object sender, EventArgs e)
		{
			EnumTypes ty = (EnumTypes)cbType.SelectedItem;

			IAbstractFactory factory = FactoryProvider.GetFactory(this.ProductName);
			VuelingFile file = factory.Create(ty);
			ShowStudents(file.GetAll());

		}

		private void BtnUpdate_Click(object sender, EventArgs e)
		{
			Student student = CreateStudent();
			EnumTypes ty = (EnumTypes)cbType.SelectedItem;

			IAbstractFactory factory = FactoryProvider.GetFactory(this.ProductName);
			VuelingFile file = factory.Create(ty);
			if (file.Update(student) != null)
			{
				MessageBox.Show("Student: " + student.Id + " updated", TITLE);
			}
			else
			{
				MessageBox.Show("Student: " + student.Id + " can not update", TITLE);
			}

		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			Student student = CreateStudent();
			EnumTypes ty = (EnumTypes)cbType.SelectedItem;

			IAbstractFactory factory = FactoryProvider.GetFactory(this.ProductName);
			VuelingFile file = factory.Create(ty);
			if (file.Delete(student))
			{
				MessageBox.Show("Student: " + student.Id + " deleted", TITLE);
			}
			else
			{
				MessageBox.Show("Student: " + student.Id + " can not delete", TITLE);
			}

		}

		private void ShowStudents(List<Student> list)
		{
			StringBuilder message = new StringBuilder();
			foreach (var item in list)
			{
				message.Append(item + "\n");
			}
			MessageBox.Show(message.ToString(), TITLE);
		}

		private Student CreateStudent()
		{
			try
			{
				Student student = new Student(int.Parse(tbId.Text), tbName.Text, tbSurname.Text, dpDate.Value);
				return student;

			}
			catch (FormatException fe)
			{
				MessageBox.Show(tbId.Text + " is a invalid id, try with another id", "File Manager");
				return null;
			}
		}

		private void SelectFile()
		{
			Student student = CreateStudent();
			EnumTypes ty = (EnumTypes)cbType.SelectedItem;

			IAbstractFactory factory = FactoryProvider.GetFactory(this.ProductName);
			VuelingFile file = factory.Create(ty);
		}
	}
}
