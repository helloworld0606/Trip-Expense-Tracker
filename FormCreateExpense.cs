
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trip_Expense_Tracker.Models;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.Interfaces;
using Trip_Expense_Tracker.Models.Repositories;
using Trip_Expense_Tracker.Models.Services;

namespace Trip_Expense_Tracker
{
	public partial class FormCreateExpense : Form
	{
		public FormCreateExpense()
		{
			InitializeComponent();
			
			this.Load += FormCreateExpense_Load;
			this.buttonSave.Click += buttonSave_Click;	
		}

		private void FormCreateExpense_Load(object sender, EventArgs e)
		{
			this.Text = "新增消費項目";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
		}


		private IExpenseRepository GetRepo()
		{
			return new ExpenseEFRepo();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{

			ExpenseDto dto = new ExpenseDto()
			{
				Name = textBox1.Text,
				Expeno= int.TryParse(textBox2.Text, out int value) ? value : 0

			};

			int newData = new ExpenseService(GetRepo()).Create(dto);
			MessageBox.Show($"消費項目已更新!");
		

				var container = this.Owner as IDataContainer;
				if (container != null)
				{
					container.Display();
					this.DialogResult = DialogResult.OK;
				}
				else
				{
					MessageBox.Show("Owner 表單沒有實作IDateContainerur介面");
					this.DialogResult = DialogResult.OK;
				}
			}
		
	}
}
