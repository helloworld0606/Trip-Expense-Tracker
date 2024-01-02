namespace Trip_Expense_Tracker
{
	partial class FormTransaction
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.buttonReset = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.buttonGO = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonEXPORT = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonReset
			// 
			this.buttonReset.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.buttonReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.buttonReset.Location = new System.Drawing.Point(483, 40);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(75, 41);
			this.buttonReset.TabIndex = 14;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
			this.dataGridView1.Location = new System.Drawing.Point(33, 97);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(710, 332);
			this.dataGridView1.TabIndex = 13;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "Id";
			this.Column5.HeaderText = "Id";
			this.Column5.Name = "Column5";
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1.DataPropertyName = "amount";
			dataGridViewCellStyle1.Format = "C0";
			dataGridViewCellStyle1.NullValue = null;
			this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
			this.Column1.HeaderText = "Amount";
			this.Column1.Name = "Column1";
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column2.DataPropertyName = "Date";
			dataGridViewCellStyle2.Format = "d";
			dataGridViewCellStyle2.NullValue = null;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
			this.Column2.HeaderText = "Date";
			this.Column2.Name = "Column2";
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "budgno";
			this.Column3.HeaderText = "No.";
			this.Column3.Name = "Column3";
			// 
			// Column4
			// 
			this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column4.DataPropertyName = "BudgetName";
			this.Column4.HeaderText = "Name";
			this.Column4.Name = "Column4";
			// 
			// Column6
			// 
			this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column6.DataPropertyName = "Remarks";
			this.Column6.HeaderText = "Remarks";
			this.Column6.Name = "Column6";
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.Location = new System.Drawing.Point(622, 51);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(109, 23);
			this.buttonAdd.TabIndex = 12;
			this.buttonAdd.Text = "Add New...";
			this.buttonAdd.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Expense (Debit)",
            "Budget (Credit)"});
			this.comboBox1.Location = new System.Drawing.Point(215, 51);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(155, 20);
			this.comboBox1.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(28, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "Transaction";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(170, 15);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
			this.dateTimePicker1.TabIndex = 15;
			// 
			// buttonGO
			// 
			this.buttonGO.Location = new System.Drawing.Point(391, 15);
			this.buttonGO.Name = "buttonGO";
			this.buttonGO.Size = new System.Drawing.Size(34, 23);
			this.buttonGO.TabIndex = 16;
			this.buttonGO.Text = "GO";
			this.buttonGO.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Crimson;
			this.label2.Location = new System.Drawing.Point(31, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 12);
			this.label2.TabIndex = 17;
			this.label2.Text = "label2";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Green;
			this.label3.Location = new System.Drawing.Point(31, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 12);
			this.label3.TabIndex = 18;
			this.label3.Text = "label3";
			// 
			// buttonEXPORT
			// 
			this.buttonEXPORT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonEXPORT.Location = new System.Drawing.Point(622, 435);
			this.buttonEXPORT.Name = "buttonEXPORT";
			this.buttonEXPORT.Size = new System.Drawing.Size(64, 23);
			this.buttonEXPORT.TabIndex = 19;
			this.buttonEXPORT.Text = "EXPORT";
			this.buttonEXPORT.UseVisualStyleBackColor = true;
			// 
			// FormTransaction
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 466);
			this.Controls.Add(this.buttonEXPORT);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonGO);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Name = "FormTransaction";
			this.Text = "FormTransaction";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTransaction_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button buttonGO;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.Button buttonEXPORT;
	}
}