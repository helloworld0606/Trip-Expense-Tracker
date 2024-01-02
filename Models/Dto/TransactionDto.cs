using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Expense_Tracker.Models.Dto
{
	public class TransactionDto
	{
		public int Id { get; set; }

		public int Amount { get; set; }

		public bool CreditOrDebit()
		{
			if (Expeno.HasValue && Expeno >= 11 && Expeno <= 19)
			{
				// Expense from 11 to 19, considered as Debit
				return false;
			}
			else if (Budgno.HasValue && Budgno >= 21 && Budgno <= 29)
			{
				// Budget from 21 to 29, considered as Credit
				return true;
			}
			else
			{
				// Default to Debit if no matching range is found
				return false;
			}
		}

		public DateTime Date { get; set; }
		public int? Expeno { get; set; }

		public int? Budgno { get; set; }
		public string ExpenseName { get; set; }

		public string BudgetName { get; set; }
		public string Remarks { get; set; }

	}

	
	
}
