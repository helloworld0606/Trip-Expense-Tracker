using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
	public partial class FormEditExpense : Form
	{
		private readonly int _pk;
		public FormEditExpense(int pk)
		{
			_pk= pk;
			InitializeComponent();
			this.Load += FormEditExpense_Load;
			this.buttonSave.Click += ButtonSave_Click;
			this.buttonDelete.Click += ButtonDelete_Click;
		}

	
		private IExpenseRepository GetRepo()
		{
			return new ExpenseEFRepo();
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{

			new ExpenseService(GetRepo()).Delete(_pk);
			MessageBox.Show($"項目已刪除!");
			{ 
				this.DialogResult = DialogResult.OK;

				var container = this.Owner as IDataContainer;
				if (container != null)
				{
					container.Display();
					this.DialogResult = DialogResult.OK;
				}
				else
				{
					MessageBox.Show("Owner 表單沒有實作IDateContainer介面");
					this.DialogResult = DialogResult.OK;
				}
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			var service = new ExpenseService(GetRepo());
			ExpenseDto dto = new ExpenseDto
			{
				Expeno = _pk,
				Name = textBox1.Text,
				//Expeno = int.TryParse(textBox2.Text, out int value) ? value : 0
			};


			service.Update(dto);
			
			
			MessageBox.Show($"項目已更新");
			var container = this.Owner as IDataContainer;
			if (container != null)
			{
				container.Display();

			}
			else
			{
				MessageBox.Show("Owner 表單沒有實作IDateContainerur介面");
				this.DialogResult = DialogResult.OK;//關閉自己
			}
		}

	
			
		

		private void FormEditExpense_Load(object sender, EventArgs e)
		{
			this.Text = "修改旅費項目";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			BindData();
		}

		private void BindData()
		{
			ExpenseDto model = new ExpenseService(GetRepo()).Get(_pk);


			textBox1.Text = model.Name;
			textBox2.Text = model.Expeno.ToString();
		}

	

	}
}
