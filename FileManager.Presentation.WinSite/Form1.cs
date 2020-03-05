using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FileManager.Business.layer;
using FileManager.Common.Layer;

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
			EnumTypes type = (EnumTypes)cbType.SelectedItem;

			StudentBLL business = new StudentBLL();
			MessageBox.Show(business.SaveStudent(this.ProductName, type, student));
		}

		private void BtnRead_Click(object sender, EventArgs e)
		{
			EnumTypes type = (EnumTypes)cbType.SelectedItem;

			StudentBLL business = new StudentBLL();
			MessageBox.Show(business.GetAllStudents(this.ProductName, type));

		}

		private void BtnUpdate_Click(object sender, EventArgs e)
		{
			Student student = CreateStudent();
			EnumTypes type = (EnumTypes)cbType.SelectedItem;

			StudentBLL business = new StudentBLL();
			MessageBox.Show(business.UpdateStudent(this.ProductName, type, student));

		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			Student student = CreateStudent();
			EnumTypes type = (EnumTypes)cbType.SelectedItem;

			StudentBLL business = new StudentBLL();
			MessageBox.Show(business.DeleteStudent(this.ProductName, type, student));
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

	}
}
