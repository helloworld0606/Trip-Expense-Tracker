using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Trip_Budget_Tracker.Models.Services;
using Trip_Expense_Tracker;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.Interfaces;
using Trip_Expense_Tracker.Models.Repositories;

namespace Trip_Budget_Tracker
{
	public partial class FormBudget : Form, IDataContainer
	{
		public FormBudget()
		{
			InitializeComponent();
			this.Text = "旅行預算項目清單";
			this.Load += FormBudget_Load;
			this.dataGridView1.CellClick += DataGridView1_CellClick;
			this.buttonAdd.Click += ButtonAdd_Click;
			this.buttonConfirm.Click += ButtonConfirm_Click;
			this.buttonSearch.Click += ButtonSearch_Click;
			this.buttonReset.Click += ButtonReset_Click;

		}

		private void ButtonReset_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";  // Clear the text in textBox1
			comboBox1.SelectedItem = null;  // Deselect the item in comboBox1

			// Display all original data in the DataGridView
			Display();
		}

		private void ButtonSearch_Click(object sender, EventArgs e)
		{
			if (int.TryParse(textBox1.Text, out int Budgno))
			{
				var service = new BudgetService(GetRepo());
				BudgetDto Budget = service.Get(Budgno);

				if (Budget != null)
				{
					this.dataGridView1.DataSource = new List<BudgetDto> { Budget };
				}
				else
				{
					MessageBox.Show("Budget not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show("Please enter a valid Budgno.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonConfirm_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem != null)
			{
				// Split the selected text into ID and description
				string[] parts = comboBox1.Text.Split(' ');

				// Check if the split was successful and there are at least two parts
				if (parts.Length >= 2 && int.TryParse(parts[0], out int selectedBudget))
				{
					// Retrieve the data based on Budgno
					var service = new BudgetService(GetRepo());
					BudgetDto Budget = service.Get(selectedBudget);

					// Display the data in the DataGridView
					if (Budget != null)
					{
						this.dataGridView1.DataSource = new List<BudgetDto> { Budget };
					}
					else
					{
						MessageBox.Show("Budget not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					MessageBox.Show("Invalid selection format in the ComboBox.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Please select an item from the ComboBox.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = new FormCreateBudget();
			form.Owner = this;
			form.ShowDialog();
		}

		private IBudgetRepository GetRepo()
		{
			return new BudgetEFRepo();
		}

		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			var Budgets = dataGridView1.DataSource as List<BudgetDto>;

			int pk = (int)Budgets[e.RowIndex].Budgno;

			var form = new FormEditBudget(pk);
			form.Owner = this;
			form.ShowDialog();
		}

		private void FormBudget_Load(object sender, EventArgs e)
		{
			Display();
		}

		public void Display()
		{
			var service = new BudgetService(GetRepo());
			List<BudgetDto> Budgets = service.Search(textBox1.Text);
			this.dataGridView1.DataSource = Budgets;
		}

		public void Balance(decimal totalAmount)
		{
			throw new NotImplementedException();
		}
	}
}
