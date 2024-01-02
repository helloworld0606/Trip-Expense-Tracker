
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
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.EFModels;
using Trip_Expense_Tracker.Models.Interfaces;
using Trip_Expense_Tracker.Models;
using System.Drawing.Text;
using Trip_Expense_Tracker.Models.Repositories;
using Trip_Expense_Tracker.Models.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trip_Expense_Tracker
{
	public partial class FormExpense : Form, IDataContainer
	{
		public FormExpense()
		{
			InitializeComponent();
			this.Text = "旅行消費項目清單";
			this.Load += FormExpense_Load;
			this.dataGridView1.CellClick += dataGridView1_CellContentClick;
				

		}

		private IExpenseRepository GetRepo()
		{
			return new ExpenseEFRepo();
		}


		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			var expenses = dataGridView1.DataSource as List<ExpenseDto>;

			int pk = (int)expenses[e.RowIndex].Expeno;

			var form = new FormEditExpense(pk);
			form.Owner = this;
			form.ShowDialog();


		}
		private void FormExpense_Load(object sender, EventArgs e)
		{

			Display();

		}

		public void Display()
		{
			//string name = textBox1.Text;
			//var db = new MyDbContext();
			//var expenses = db.expenses.Where(x => x.name.Contains(name)).OrderBy(x => x.expeno).ToList();


			//this.dataGridView1.DataSource = expenses;
			//-------------------------------------------------
			//string connStr = @"Data Source=.\SQLEXPRESS;Database=TripExpenseTracker;User ID=sa6;Password=sa6;MultipleActiveResultSets=true";
			//string name = textBox1.Text;
			//string sql = @"SELECT expeno, name FROM expense ORDER BY expeno";

			//using (var conn = new SqlConnection(connStr))
			//{
			//	List<ExpenseVm> data = conn.Query<ExpenseVm>(sql, new { Name = name }).ToList();
			//	this.dataGridView1.DataSource = data;
			//}
			//---------------------------------------------------
			var service = new ExpenseService(GetRepo());
			List<ExpenseDto> expenses = service.Search(textBox1.Text);
			this.dataGridView1.DataSource = expenses;


		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			if (int.TryParse(textBox1.Text, out int expeno))
			{
				var service = new ExpenseService(GetRepo());
				ExpenseDto expense = service.Get(expeno);

				if (expense != null)
				{
					this.dataGridView1.DataSource = new List<ExpenseDto> { expense };
				}
				else
				{
					MessageBox.Show("Expense not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show("Please enter a valid expeno.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			var form = new FormCreateExpense();
			form.Owner = this;
			form.ShowDialog();
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem != null)
			{
				// Split the selected text into ID and description
				string[] parts = comboBox1.Text.Split(' ');

				// Check if the split was successful and there are at least two parts
				if (parts.Length >= 2 && int.TryParse(parts[0], out int selectedExpense))
				{
					// Retrieve the data based on expeno
					var service = new ExpenseService(GetRepo());
					ExpenseDto expense = service.Get(selectedExpense);

					// Display the data in the DataGridView
					if (expense != null)
					{
						this.dataGridView1.DataSource = new List<ExpenseDto> { expense };
					}
					else
					{
						MessageBox.Show("Expense not found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

		private void buttonReset_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";  // Clear the text in textBox1
			comboBox1.SelectedItem = null;  // Deselect the item in comboBox1

			// Display all original data in the DataGridView
			Display();
		}

		public void Balance(decimal totalAmount)
		{
			throw new NotImplementedException();
		}
	}

	
	
}

