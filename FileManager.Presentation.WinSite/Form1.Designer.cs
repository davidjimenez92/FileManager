using FileManager.Common.Layer;

namespace FileManager.Presentation.WinSite
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblStudent = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblSurname = new System.Windows.Forms.Label();
			this.lblDateOfBirth = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.tbId = new System.Windows.Forms.TextBox();
			this.tbSurname = new System.Windows.Forms.TextBox();
			this.tbName = new System.Windows.Forms.TextBox();
			this.cbType = new System.Windows.Forms.ComboBox();
			this.dpDate = new System.Windows.Forms.DateTimePicker();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnRead = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblStudent
			// 
			this.lblStudent.AutoSize = true;
			this.lblStudent.Location = new System.Drawing.Point(12, 97);
			this.lblStudent.Name = "lblStudent";
			this.lblStudent.Size = new System.Drawing.Size(76, 17);
			this.lblStudent.TabIndex = 0;
			this.lblStudent.Text = "Student Id:";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(12, 152);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(45, 17);
			this.lblName.TabIndex = 1;
			this.lblName.Text = "Name";
			// 
			// lblSurname
			// 
			this.lblSurname.AutoSize = true;
			this.lblSurname.Location = new System.Drawing.Point(12, 207);
			this.lblSurname.Name = "lblSurname";
			this.lblSurname.Size = new System.Drawing.Size(69, 17);
			this.lblSurname.TabIndex = 2;
			this.lblSurname.Text = "Surname:";
			// 
			// lblDateOfBirth
			// 
			this.lblDateOfBirth.AutoSize = true;
			this.lblDateOfBirth.Location = new System.Drawing.Point(12, 263);
			this.lblDateOfBirth.Name = "lblDateOfBirth";
			this.lblDateOfBirth.Size = new System.Drawing.Size(90, 17);
			this.lblDateOfBirth.TabIndex = 3;
			this.lblDateOfBirth.Text = "Date of birth:";
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Location = new System.Drawing.Point(404, 97);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(86, 17);
			this.lblType.TabIndex = 4;
			this.lblType.Text = "Output type:";
			// 
			// tbId
			// 
			this.tbId.Location = new System.Drawing.Point(113, 94);
			this.tbId.Name = "tbId";
			this.tbId.Size = new System.Drawing.Size(270, 22);
			this.tbId.TabIndex = 5;
			// 
			// tbSurname
			// 
			this.tbSurname.Location = new System.Drawing.Point(113, 204);
			this.tbSurname.Name = "tbSurname";
			this.tbSurname.Size = new System.Drawing.Size(270, 22);
			this.tbSurname.TabIndex = 6;
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(113, 149);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(270, 22);
			this.tbName.TabIndex = 7;
			// 
			// cbType
			// 
			this.cbType.FormattingEnabled = true;
			this.cbType.Location = new System.Drawing.Point(496, 94);
			this.cbType.Name = "cbType";
			this.cbType.Size = new System.Drawing.Size(270, 24);
			this.cbType.TabIndex = 8;
			// 
			// dpDate
			// 
			this.dpDate.Location = new System.Drawing.Point(113, 258);
			this.dpDate.Name = "dpDate";
			this.dpDate.Size = new System.Drawing.Size(270, 22);
			this.dpDate.TabIndex = 9;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(227, 406);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(308, 406);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(75, 23);
			this.btnRead.TabIndex = 11;
			this.btnRead.Text = "Read";
			this.btnRead.UseVisualStyleBackColor = true;
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(389, 406);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 23);
			this.btnUpdate.TabIndex = 12;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(470, 406);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 13;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dpDate);
			this.Controls.Add(this.cbType);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.tbSurname);
			this.Controls.Add(this.tbId);
			this.Controls.Add(this.lblType);
			this.Controls.Add(this.lblDateOfBirth);
			this.Controls.Add(this.lblSurname);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.lblStudent);
			this.Name = "Form1";
			this.Text = "File Manager";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblStudent;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblSurname;
		private System.Windows.Forms.Label lblDateOfBirth;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.TextBox tbId;
		private System.Windows.Forms.TextBox tbSurname;
		private System.Windows.Forms.TextBox tbName;
		private System.Windows.Forms.ComboBox cbType;
		private System.Windows.Forms.DateTimePicker dpDate;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnDelete;
	}
}

