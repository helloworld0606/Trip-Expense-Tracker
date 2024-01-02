using System;
using System.Linq;
using System.Windows.Forms;
using Trip_Budget_Tracker.Models.Services;
using Trip_Expense_Tracker;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.EFModels;
using Trip_Expense_Tracker.Models.Interfaces;
using Trip_Expense_Tracker.Models.Repositories;
using Trip_Expense_Tracker.Models.Services;

namespace Trip_Transaction_Tracker
{
	public partial class FormCreateTransaction : Form,IDataContainer
	{
		private object dataGridView1;

		public FormCreateTransaction()
		{
			InitializeComponent();
			this.Load += FormCreateTransation_Load1;
			this.buttonSave.Click += ButtonSave_Click;

			InitializeComboBoxData();
		

		}

		private void InitializeComboBoxData()
		{
			var budgets = new BudgetService(new BudgetEFRepo());
			var budgetList = budgets.Search("") 
									.ToList();
			budgetList.Insert(0, new BudgetDto{ Budgno = null, Name = "" });
			comboBox2.DataSource = budgetList;
			comboBox2.DisplayMember = "ComboBoxDisplay";
			comboBox2.ValueMember = "Budgno";


			var expenses= new ExpenseService(new ExpenseEFRepo());
			var expenseList =  expenses.Search("")
								  .ToList();
			expenseList.Insert(0, new ExpenseDto{Expeno = null, Name="" });

			comboBox1.DataSource = expenseList;
			comboBox1.DisplayMember = "ComboboxDisplay";
			comboBox1.ValueMember = "Expeno";

		}

	

		private ITransactionRepository GetRepo()
		{
			return new TransactionEFRepo();
		}
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text))
			{
				MessageBox.Show("必須選擇一個消費項目或預算項目!");
				return; // Don't proceed with saving if the validation fails
			}
			TransactionDto dto = new TransactionDto()
			{
				Amount = int.TryParse(textBox1.Text, out int value) ? value : 0,

				ExpenseName = comboBox1.Text,
				BudgetName = comboBox2.Text,
				Remarks = textBox3.Text

			};
			if (DateTime.TryParse(textBox2.Text, out DateTime dateValue))
			{
				dto.Date = dateValue;
			}
			else
			{
				// Handle the case where parsing the date fails, e.g., provide a default value or show an error message.
				// For now, I'll set it to DateTime.MinValue.
				dto.Date = DateTime.Now;
			}
			
			dto.Expeno = MapExpenseNameToExpeno(comboBox1.Text);
			dto.Budgno = MapBudgetNameToBudgno(comboBox2.Text);

			int newData = new TransactionService(GetRepo()).Create(dto);
			MessageBox.Show($"交易項目已更新!");
		
			var container = this.Owner as IDataContainer;
			if (container != null)
			{
				container.Display();
					
			}
			else
			{
				//MessageBox.Show("Owner 表單沒有實作IDateContainerur介面");
				
			}

			
			var container1 = this.Owner as IAmountContainer;
			if (container1 != null)
			{
				container1.Amount();

			}


			this.DialogResult = DialogResult.OK;

			
		}

		private int? MapBudgetNameToBudgno(string text)
		{
			string[] parts = comboBox2.Text.Split(' ');
			{
				if (parts.Length >= 2 && int.TryParse(parts[0], out int selectedBudget))
				{
					return selectedBudget;

				}
				return null;
			}
		}

		private int? MapExpenseNameToExpeno(string text)
		{
			string[] parts = comboBox1.Text.Split(' ');
			{
				if (parts.Length >= 2 && int.TryParse(parts[0], out int selectedExpeno))
				{
					return selectedExpeno;

				}
				return null;
			}
		}


			
		private void FormCreateTransation_Load1(object sender, EventArgs e)
		{
			this.Text = "新增交易項目";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;

			InitializeComboBoxData();

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
