using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trip_Expense_Tracker
{
	public partial class UserForm : Form
	{
		public UserForm()
		{
			InitializeComponent();
			this.Load += UserForm_Load;
			buttonCreateAC.Click += ButtonCreateAC_Click;
		}

		private void UserForm_Load(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void ButtonCreateAC_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
