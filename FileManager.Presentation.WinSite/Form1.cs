using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FileManager.Common.Layer;
using FileManager.DataAccess.Data;

namespace FileManager.Presentation.WinSite
{
	public partial class Form1 : Form
	{
		private const string TITLE = "File Manager";

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
			if (student != null)
			{
				try
				{
					switch (cbType.SelectedItem.ToString())
					{
						case "TXT":
							StudentDao txtfactory = new TxtFactory();
							var studentTxt = txtfactory.Add(student);
							if (studentTxt != null)
								MessageBox.Show(studentTxt + " added", TITLE);
							else
								MessageBox.Show("Student: " + student.Id + " already exists", TITLE);
							break;
						case "XML":
							StudentDao xmlFactory = new XmlFactory();
							var studentXml = xmlFactory.Add(student);
							if (studentXml != null)
								MessageBox.Show(studentXml + " added", TITLE);
							else
								MessageBox.Show("Student: " + student.Id + " already exists", TITLE);
							break;
						case "JSON":
							MessageBox.Show("Not implemented", TITLE);
							break;
						default:
							break;
					}
				}
				catch (NullReferenceException nre)
				{
					cbType.Focus();
					MessageBox.Show("Select someone type", TITLE);
				}
			}
		}

		private void BtnRead_Click(object sender, EventArgs e)
		{
			try
			{
				switch (cbType.SelectedItem.ToString())
				{
					case "TXT":
						StudentDao txtFactory = new TxtFactory();
						ShowStudents(txtFactory.Get());
						break;
					case "XML":
						StudentDao xmlFactory = new XmlFactory();
						ShowStudents(xmlFactory.Get());
						break;
					case "JSON":
						MessageBox.Show("Not implemented", TITLE);
						break;
					default:
						break;
				}
			}
			catch (NullReferenceException nre)
			{
				cbType.Focus();
				MessageBox.Show("Select someone type", TITLE);
			}
		}

		private void BtnUpdate_Click(object sender, EventArgs e)
		{
			Student student = new Student(int.Parse(tbId.Text), tbName.Text, tbSurname.Text, dpDate.Value);
			try
			{
				switch (cbType.SelectedItem.ToString())
				{
					case "TXT":
						StudentDao txtFactory = new TxtFactory();
						var resultTxt = txtFactory.Update(student);
						if (resultTxt != null)
							MessageBox.Show("Student id: " + student.Id + " updated", "File Manager");
						break;
					case "XML":
						StudentDao xmlFactory = new XmlFactory();
						var resultXml = xmlFactory.Update(student);
						if (resultXml != null)
							MessageBox.Show("Student id: " + student.Id + " updated", "File Manager");
						break;
					case "JSON":
						MessageBox.Show("Not implemented", TITLE);
						break;
					default:
						break;
				}
			}
			catch (NullReferenceException nre)
			{
				cbType.Focus();
				MessageBox.Show("Select someone type", TITLE);
			}
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			Student student = new Student(int.Parse(tbId.Text));
			try
			{
				switch (cbType.SelectedItem.ToString())
				{
					case "TXT":
						StudentDao txtFactory = new TxtFactory();
						if (txtFactory.Delete(student))
							MessageBox.Show("Student id: " + student.Id + " deleted", "File Manager");
						else
							MessageBox.Show("Student id: " + student.Id + " can not delete", "File Manager");
						break;
					case "XML":
						StudentDao xmlFactory = new XmlFactory();
						if (xmlFactory.Delete(student))
							MessageBox.Show("Student id: " + student.Id + " deleted", "File Manager");
						else
							MessageBox.Show("Student id: " + student.Id + " can not delete", "File Manager");
						break;
					case "JSON":
						MessageBox.Show("Not implemented", TITLE);
						break;
					default:
						break;
				}
			}
			catch (NullReferenceException nre)
			{
				cbType.Focus();
				MessageBox.Show("Select someone type", TITLE);
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
	}
}
