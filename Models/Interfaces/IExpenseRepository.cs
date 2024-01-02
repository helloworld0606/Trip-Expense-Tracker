using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trip_Expense_Tracker.Models.Dto;

namespace Trip_Expense_Tracker.Models.Interfaces
{
	public interface IExpenseRepository
	{
		int Create(ExpenseDto dto);
		void Update(ExpenseDto dto);
		void Delete(int id);

		List<ExpenseDto> Search(string name);
		ExpenseDto Get(int expeno);
	}
}
