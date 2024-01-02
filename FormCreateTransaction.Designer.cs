namespace Trip_Transaction_Tracker
{
	partial class FormCreateTransaction
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.budgetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tripExpenseTrackerDataSet = new Trip_Expense_Tracker.TripExpenseTrackerDataSet();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.budgetTableAdapter = new Trip_Expense_Tracker.TripExpenseTrackerDataSetTableAdapters.budgetTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.budgetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tripExpenseTrackerDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(74, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Amount";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(76, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "Date";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(74, 181);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "Remarks";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(145, 29);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(142, 22);
			this.textBox1.TabIndex = 0;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(145, 69);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(142, 22);
			this.textBox2.TabIndex = 1;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(145, 178);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(142, 22);
			this.textBox3.TabIndex = 4;			// 
			// comboBox2
			// 
			this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.budgetBindingSource, "name", true));
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(364, 125);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(122, 20);
			this.comboBox2.TabIndex = 3;
			// 
			// budgetBindingSource
			// 
			this.budgetBindingSource.DataMember = "budget";
			this.budgetBindingSource.DataSource = this.tripExpenseTrackerDataSet;
			// 
			// tripExpenseTrackerDataSet
			// 
			this.tripExpenseTrackerDataSet.DataSetName = "TripExpenseTrackerDataSet";
			this.tripExpenseTrackerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "11  Transportation",
            "12  Ticket",
            "13  Food",
            "14  Acommodation",
            "15  Purchasing",
            "16  Others"});
			this.comboBox1.Location = new System.Drawing.Point(139, 122);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(122, 20);
			this.comboBox1.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(74, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 13;
			this.label4.Text = "消費項目";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(296, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 13;
			this.label5.Text = "預算項目";
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(246, 232);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			// 
			// budgetTableAdapter
			// 
			this.budgetTableAdapter.ClearBeforeFill = true;
			// 
			// FormCreateTransation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(581, 294);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormCreateTransation";
			this.Text = "FormCreateTransation";
			((System.ComponentModel.ISupportInitialize)(this.budgetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tripExpenseTrackerDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonSave;
		private Trip_Expense_Tracker.TripExpenseTrackerDataSet tripExpenseTrackerDataSet;
		private System.Windows.Forms.BindingSource budgetBindingSource;
		private Trip_Expense_Tracker.TripExpenseTrackerDataSetTableAdapters.budgetTableAdapter budgetTableAdapter;
	}
}