using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private void btnSave_Click(object sender, EventArgs e)
		{
			Student student = new Student(int.Parse(tbId.Text), tbName.Text, tbSurname.Text, dpDate.Value);

			try
			{
				switch (cbType.SelectedItem.ToString())
				{
					case "TXT":
						TxtFactory txtfactory = new TxtFactory();
						var studentTxt = txtfactory.Add(student);
						if (studentTxt != null)
							MessageBox.Show(studentTxt + " added", TITLE);
						else
							MessageBox.Show("Student: " + student.Id + " already exists", TITLE);
						break;
					case "XML":
						XmlFactory xmlFactory = new XmlFactory();
						var studentXml = xmlFactory.Add(student);
						if (studentXml != null)
							MessageBox.Show(studentXml + " added", TITLE);
						else
							MessageBox.Show("Student: " + student.Id + " already exists", TITLE);
						break;
					case "JSON":
						JsonFactory jsonFactory = new JsonFactory();
						MessageBox.Show(jsonFactory.Add(student).ToString() + " added", TITLE);
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

		private void btnRead_Click(object sender, EventArgs e)
		{
			try
			{
				switch (cbType.SelectedItem.ToString())
				{
					case "TXT":
						TxtFactory txtFactory = new TxtFactory();
						ShowStudents(txtFactory.Get());
						break;
					case "XML":
						XmlFactory xmlFactory = new XmlFactory();
						ShowStudents(xmlFactory.Get());
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
			string message = "";
			foreach (var item in list)
			{
				message += item + "\n";
			}
			MessageBox.Show(message, TITLE);
		}
	}
}
