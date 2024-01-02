using System;
using System.Windows.Forms;
using Trip_Budget_Tracker.Models.Services;
using Trip_Expense_Tracker;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.Interfaces;
using Trip_Expense_Tracker.Models.Repositories;

namespace Trip_Budget_Tracker
{
	public partial class FormCreateBudget : Form,IDataContainer
	{
		public FormCreateBudget()
		{
			InitializeComponent();
			this.Load += FormCreateBudget_Load;
			this.buttonSave.Click += ButtonSave_Click;
		}

		private void FormCreateBudget_Load(object sender, EventArgs e)
		{
			this.Text = "新增預算項目";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
		}

		private IBudgetRepository GetRepo()
		{
			return new BudgetEFRepo();
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{

			BudgetDto dto = new BudgetDto()
			{
				Name = textBox1.Text,
				Budgno = int.TryParse(textBox2.Text, out int value) ? value : 0

			};

			int newData = new BudgetService(GetRepo()).Create(dto);
			MessageBox.Show($"預算項目已更新!");


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

		public void Display()
		{
			throw new NotImplementedException();
		}

		public void Balance(decimal totalAmount)
		{
			throw new NotImplementedException();
		}
	}
}

