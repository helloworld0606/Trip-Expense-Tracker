using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.Interfaces;
using Trip_Expense_Tracker.Models.Repositories;
using Trip_Expense_Tracker.Models.Services;

namespace Trip_Expense_Tracker
{
	public partial class FormEditTransaction : Form
	{

		private readonly int _pk;
		public FormEditTransaction(int pk)
		{
			_pk = pk;
			InitializeComponent();
			this.buttonDelete.Click += ButtonDelete_Click;
			this.buttonSave.Click += BtnSave_Click;
			this.Load += FromEditTransaction_Load;
		}

		private void FromEditTransaction_Load(object sender, EventArgs e)
		{
			this.Text = "修改交易項目";
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			BindData();
		}

		private void ButtonDelete_Click(object sender, EventArgs e)
		{
			new TransactionService(GetRepo()).Delete(_pk);

			MessageBox.Show($"交易紀錄已刪除");
			var container = this.Owner as IDataContainer;
			if (container != null)
			{
				container.Display();

			}
			else
			{
				MessageBox.Show("Owner 表單沒有實作IDateContainer介面");
			
			}
			var container1 = this.Owner as IAmountContainer;
			if (container1 != null)
			{
				container1.Amount();
			}
			this.DialogResult = DialogResult.OK;//關閉自己

	}
		private void BtnSave_Click(object sender, EventArgs e)
		{
			var service = new TransactionService(GetRepo());
			TransactionDto dto = new TransactionDto
			{
				Id = _pk,
				Date = DateTime.TryParse(textBox1.Text, out DateTime dateValue) ? dateValue : DateTime.Now,
				Amount = int.TryParse(textBox2.Text, out int value) ? value : 0,
				Remarks = textBox3.Text
			};


			service.Update(dto);
			MessageBox.Show($"交易紀錄已更新");
			var container = this.Owner as IDataContainer;
			if (container != null)
			{
				container.Display();

			}
			else
			{
				MessageBox.Show("Owner 表單沒有實作IDateContainerur介面");
				
			}

			var container1 = this.Owner as IAmountContainer;
			if (container1 != null)
			{
				container1.Amount();
			}
			this.DialogResult = DialogResult.OK;//關閉自己

		}
		private ITransactionRepository GetRepo()
		{
			return new TransactionEFRepo();
		}

		private void BindData()
		{
			TransactionDto model = new TransactionService(GetRepo()).Get(_pk);


			textBox1.Text = model.Date.ToString("yyyy-MM-dd");
			textBox2.Text = model.Amount.ToString();
			textBox3.Text = model.Remarks;
		}

	}
}
