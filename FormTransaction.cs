using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.EFModels;
using Trip_Expense_Tracker.Models.Interfaces;
using Trip_Expense_Tracker.Models.Repositories;
using Trip_Expense_Tracker.Models.Services;
using Trip_Transaction_Tracker;
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Trip_Expense_Tracker
{
	public partial class FormTransaction : Form , IDataContainer, IAmountContainer
	{
		public FormTransaction()
		{
			InitializeComponent();
			
			this.Load += FormTransaction_Load;
			this.dataGridView1.CellClick += DataGridView1_CellClick; ;
			this.buttonAdd.Click += ButtonAdd_Click; ;
			this.buttonReset.Click += ButtonReset_Click;
			this.comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
			//this.dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged; ;
			dataGridView1.AutoGenerateColumns = false;
			this.buttonGO.Click += Button1_Click;
			this.buttonEXPORT.Click += ButtonEXPORT_Click;
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


		}

		private void ButtonEXPORT_Click(object sender, EventArgs e)
		{
			ExportToExcel();
		}

		private void ExportToExcel()
		{
			using (ExcelPackage excelPackage = new ExcelPackage())
			{
				ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

				// Add header row
				for (int i = 0; i < dataGridView1.Columns.Count; i++)
				{
					worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
				}

				// Add data rows
				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					for (int j = 0; j < dataGridView1.Columns.Count; j++)
					{
						worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
					}
				}

				// Save the file
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
					saveFileDialog.Title = "Save Excel File";

					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						FileInfo file = new FileInfo(saveFileDialog.FileName);
						excelPackage.SaveAs(file);
						MessageBox.Show("Excel file saved successfully!");
					}
				}
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			var datetime = new TransactionService(GetRepo());
			var selectedDateTime = dateTimePicker1.Value;

			var times = datetime.Search(selectedDateTime).ToList();

			dataGridView1.DataSource = times;
		}

		//private void DateTimePicker1_TextChanged(object sender, EventArgs e)
		//{
		//	var datetime = new TransactionService(GetRepo());
		//	var selectedDateTime = dateTimePicker1.Value;

		//	var times = datetime.Search(selectedDateTime).ToList();

		//	dataGridView1.DataSource = times;
		//}

		private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			var target = (ComboBoxItem)comboBox1.SelectedItem;//控制項
			
			if (target!=null && target.Value > 0)//comboBox選項第二個開始的項目
			{

				

				var service = new TransactionService(GetRepo());
				var value1 = service.Search().Where(x=>x.Budgno > 20 && x.Budgno <31).OrderBy(x => x.Date).ToList();

				
				foreach (var value in value1)
				{
					if (value.Budgno == null)
					{
						value.Budgno = value.Expeno;
					}
					if (value.BudgetName == null)
					{
						value.BudgetName = value.ExpenseName;
					}
				}
				dataGridView1.DataSource = value1;
				//var service = new TransactionService(GetRepo());
				//var items = service.Search().Where(t => t.Budgno != null).Select(t => new
				//{

				//	Id=t.Id,
				//	Amount=t.Amount,
				//	Date=t.Date,
				//	No=t,Budgno,

				//	//BugdgetName = budget.name,

				//}).ToList();
				//dataGridView1.DataSource = items;
			}
			else//comboBox選項第一個的項目
			{

				//var firstItem = new ComboBoxItem { Value = -1, Display = "" };
				//comboBox1.Items.Insert(0, firstItem);

				var service = new TransactionService(GetRepo());
				var value1 = service.Search().Where(x => x.Expeno > 10 && x.Expeno < 20).OrderBy(x => x.Date).ToList();

				
				foreach (var value in value1)
				{
					if (value.Budgno == null)
					{
						value.Budgno = value.Expeno;
					}
					if (value.BudgetName == null)
					{
						value.BudgetName = value.ExpenseName;
					}
				}
				dataGridView1.DataSource = value1;
				//var service = new TransactionService(GetRepo());
				//var items = service.Search().Where(t => t.Expeno != null).Select(t => new
				//{
				//	Amount = t.Amount,
				//	Date = t.Date,
				//	ExpenseName = expense.name

				//}).ToList();
				//dataGridView1.DataSource = items;
			}
		}

		

		//private void DisplayFilteredTransactions(string category, DateTime selectedDate)
		//{
		//	var service = new TransactionService(GetRepo());

		//	// Filter transactions based on category and date
		//	List<TransactionDto> transactions = service.Search(category, selectedDate);

		//	// Update the related names in each transaction
		//	foreach (var transaction in transactions)
		//	{
		//		transaction.Expense.Name = GetExpenseName(transaction.Expeno);
		//		transaction.Budget.Name = GetBudgetName(transaction.Budgno);
		//	}

		//	this.dataGridView1.DataSource = transactions;
		//}
		//private string GetExpenseName(int? expeno)
		//{
		//	if (expeno.HasValue)
		//	{
		//		// Use your logic to retrieve the expense name based on expense number
		//		// For example, you might have a service method to get the expense name
		//		var expenseService = new ExpenseService(GetRepo()); // Create ExpenseService as needed
		//		var expense = expenseService.Get(expeno.Value);

		//		return expense?.Name ?? "N/A";
		//	}

		//	return "N/A";
		//}
		//	// Helper method to get the budget name based on the given budget number
		//private string GetBudgetName(int? budgno)
		//{
		//	if (budgno.HasValue)
		//	{
		//		// Use your logic to retrieve the budget name based on budget number
		//		// For example, you might have a service method to get the budget name
		//		var budgetService = new BudgetService(GetRepo()); // Create BudgetService as needed
		//		var budget = budgetService.Get(budgno.Value);

		//		return budget?.Name ?? "N/A";
		//	}

		//	return "N/A";
		//}

		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = new FormCreateTransaction();
			form.Owner = this;
			form.ShowDialog();
		}

		private void FormTransaction_Load(object sender, EventArgs e)
		{
			this.Text = "旅遊交易費用管理";
			FillComboBox();
			Display();

			CalculateTotalAmount();
			//Amount();
			label2.Text = $"目前花費:   {totalExpenseAmount:C0}";
			label3.Text = $"目前預算:  {totalBudgetAmount:C0}";
		}

		private void ButtonReset_Click(object sender, EventArgs e)
		{

			comboBox1.SelectedItem = null;  // Deselect the item in comboBox1
			dateTimePicker1.Value = DateTime.Now;
			// Display all original data in the DataGridView
			Display();	
			
		}
		private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			var Transactions = dataGridView1.DataSource as List<TransactionDto>;

			int pk = Transactions[e.RowIndex].Id;

			var form = new FormEditTransaction(pk);
			form.Owner = this;
			form.ShowDialog();
		}
		private ITransactionRepository GetRepo()
		{
			return new TransactionService(new TransactionEFRepo());
		}

		

		private void FillComboBox()
		{
			//var service = new TransactionService(GetRepo());
			//List<ComboBoxItem> l = new List<ComboBoxItem>();
			//service.Search().Where(t => t.Expeno != null).Select(t => new ComboBoxItem
			//{
			//	Value = (int)t.Expeno,
			//	Display = t.ExpenseName
			//}).Distinct().ToList().ForEach(n => l.Add(n));

			//service.Search().Where(t => t.Budgno != null).Select(t => new ComboBoxItem
			//{
			//	Value = (int)t.Budgno,
			//	Display = t.BudgetName
			//}).Distinct().ToList().ForEach(n => l.Add(n));
			List<ComboBoxItem> items = new List<ComboBoxItem>
			{
				new ComboBoxItem { Value = -1, Display = "" },
				new ComboBoxItem { Value = 0, Display = "Expense"},
				new ComboBoxItem { Value = 1, Display = "Budget"}
					
			};
			comboBox1.DataSource = items;
		

			comboBox1.DisplayMember = "Display";
			comboBox1.ValueMember = "Value";

			
		}

		private void Display()
		{
			var service = new TransactionService(GetRepo());
			var value1= service.Search().OrderBy(x=>x.Date).ToList();

			foreach (var value in value1) 
			{
				if(value.Budgno == null)
				{
					value.Budgno = value.Expeno;
				}
				if(value.BudgetName == null)
				{
					value.BudgetName = value.ExpenseName;
				}
			}
			dataGridView1.DataSource = value1;

			


		}

		//private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		//{
		//	var datetime = new TransactionService(GetRepo());
		//	var selectedDateTime = dateTimePicker1.Value;

		//	var times = datetime.Search(selectedDateTime).ToList();

		//	dataGridView1.DataSource = times;
		//}

		decimal totalExpenseAmount;
		decimal totalBudgetAmount;
		decimal totalAmount;
		private void CalculateTotalAmount()
		{
			// Calculate the total amount based on your data (replace this with your logic)
			var transactions = new TransactionService(GetRepo());
			totalAmount = transactions.Search().Select(t => t.Amount).Sum();
			totalExpenseAmount = transactions.Search().Where(t => t.Expeno != null).Select(t => t.Amount).Sum();
			totalBudgetAmount = transactions.Search().Where(t => t.Budgno != null).Select(t => t.Amount).Sum();
		}

		private void FormTransaction_FormClosing(object sender, FormClosingEventArgs e)
		{
			CalculateTotalAmount(); // Calculate the total amount before closing

			// Pass the total amount to FormMain

			var container = this.Owner as IDataContainer;

			if (container != null)
			{
				container.Balance(totalAmount);
			}
			else
			{
				//MessageBox.Show("123");
			}
			this.DialogResult = DialogResult.OK;

		}

		public decimal GetTotalExpenseAmount()
		{
			return totalExpenseAmount;
		}

		public decimal GetTotalBudgetAmount()
		{
			return totalBudgetAmount;
		}


		void IDataContainer.Display()
		{
			Display();
		}

		public void Balance()
		{
			
		}

		public void Balance(decimal totalAmount)
		{
			throw new NotImplementedException();
		}

		public void Amount()
		{
			//GetTotalExpenseAmount();
			//GetTotalBudgetAmount();
			CalculateTotalAmount();
			label2.Text = $"目前花費:   {totalExpenseAmount:C0}";
			label3.Text = $"目前預算:  {totalBudgetAmount:C0}";
		}
	}

	class ComboBoxItem
		{
            public int Value { get; set; }
			public string Display { get; set; }
		}

	

			
	
	
}
	
