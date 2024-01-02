using System;
using System.Windows.Forms;
using Trip_Budget_Tracker.Models.Services;
using Trip_Expense_Tracker;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.Interfaces;
using Trip_Expense_Tracker.Models.Repositories;

namespace Trip_Budget_Tracker
{
	public partial class FormEditBudget : Form
	{
		private readonly int _pk;
		public FormEditBudget(int pk)
		{
			_pk = pk;
			
			InitializeComponent();
			this.buttonSave.Click += ButtonSave_Click;
			this.buttonDelete.Click += ButtonDelete_Click;
			this.Load += FormEditBudget_Load;
		}

		private void FormEditBudget_Load(object sender, EventArgs e)
		{
			this.Text = "修改預算項目";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			BindData();
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			new BudgetService(GetRepo()).Delete(_pk);
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
			var service = new BudgetService(GetRepo());
			BudgetDto dto = new BudgetDto
			{
				Budgno = _pk,
				Name = textBox1.Text,
				//Budgno = int.TryParse(textBox2.Text, out int value) ? value : 0
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

		private void BindData()
		{
			BudgetDto model = new BudgetService(GetRepo()).Get(_pk);


			textBox1.Text = model.Name;
			textBox2.Text = model.Budgno.ToString();
		}


		private IBudgetRepository GetRepo()
		{
			return new BudgetEFRepo();
		}
		
	}
}
