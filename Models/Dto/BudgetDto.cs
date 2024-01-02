using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Expense_Tracker.Models.Dto
{
	public class BudgetDto
	{
		public int? Budgno { get; set; }
		public string Name { get; set; }

		public string ComboBoxDisplay => Budgno +" "+ Name;
	}
}
