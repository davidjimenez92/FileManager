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
			MessageBox.Show(cbType.SelectedItem.ToString());
			switch (cbType.SelectedItem.ToString())
			{
				case "TXT":
					TxtFactory txtfactory = new TxtFactory();
					var studentTxt = txtfactory.Add(student);
					if ( studentTxt != null)
						MessageBox.Show(studentTxt + " added");
					else
						MessageBox.Show("Student: " + student.Id + " already exists");
					break;
				case "XML":
					XmlFactory xmlFactory = new XmlFactory();
					var studentXml = xmlFactory.Add(student);
					if(studentXml != null)
						MessageBox.Show(studentXml + " added");
					else
						MessageBox.Show("Student: " + student.Id + " already exists");
					break;
				case "JSON":
					JsonFactory jsonFactory = new JsonFactory();
					MessageBox.Show(jsonFactory.Add(student).ToString() + " added");
					break;
				default:
					break;
			}
			
		}
	}
}
