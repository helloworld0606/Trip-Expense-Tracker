using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Trip_Expense_Tracker.Models.EFModels;

namespace Trip_Expense_Tracker.Models.Dto
{
	public class ExpenseDto
	{

		public int? Expeno { get; set; }
		public string Name { get; set; }
		public override string ToString()
		{
			return $"Expeno = {this.Expeno}, Name = {this.Name}";
		}

		public string ComboBoxDisplay => Expeno + " " + Name;
	}
	

	public static class ExpenseDtoExt
	{
		public static string Show(this ExpenseDto ex)
		{
			return $"Expeno = {ex.Expeno}, Name = {ex.Name}";
		}
	}
}
