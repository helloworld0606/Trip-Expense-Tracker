using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trip_Budget_Tracker;

namespace Trip_Expense_Tracker
{
	public partial class FormMain : Form,IDataContainer
	{
		private readonly string _account;
		private readonly decimal _totalAmount;
		

		public FormMain(string account)
		{
			InitializeComponent();
			label2.Text = $"目前使用者帳號:  {account}";
			label3.Text = "";

		}

		public void Balance(decimal totalAmount)
		{
			//InitializeComponent();
			label3.Text = $"目前餘額:  {totalAmount:C0}";

		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Owner.Show();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			var form = new FormTransaction();
			form.Owner = this;
			form.ShowDialog();
		}

		

		private void button4_Click(object sender, EventArgs e)
		{
			var form = new FormBudget();
			form.ShowDialog();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			var form = new FormExpense();
			form.ShowDialog();
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		public void Display()
		{
			throw new NotImplementedException();
		}


	}
}
