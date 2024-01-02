using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Expense_Tracker.Models
{
	public class ExpenseVm
	{
		public int Expeno { get; private set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return $"Expeno = {this.Expeno}, Name = {this.Name}";
		}
	
	
	}

	public static class ExpenseVmExt
	{
		public static string Show(this ExpenseVm ex)
		{
			return $"Expeno = {ex.Expeno}, Name = {ex.Name}";
		}
	}
}
