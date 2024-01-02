using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trip_Expense_Tracker
{
	public partial class FormLogin : Form
	{
		public FormLogin()
		{
			InitializeComponent();
			this.Load += FormLogin_Load;
			
		}

		private void FormLogin_Load(object sender, EventArgs e)
		{
			this.Text = "使用者登入^__^";
			
		}
		
		private void buttonLogin_Click(object sender, EventArgs e)
		{
			string account = (string)textBox1.Text;
			string password = (string)textBox2.Text;

			if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("一定要輸入帳號+密碼!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					 
				return; // Exit the method if input is empty
			}

			var form = new FormMain(account);
			form.Owner = this;
			form.Show();

			textBox1.Text = "";
			textBox2.Text = "";

			this.Hide();//不能close自己，否則會整個關掉，隱藏就好
		}
	}

	
}
