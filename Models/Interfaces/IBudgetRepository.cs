using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Expense_Tracker.Models.Dto;

namespace Trip_Expense_Tracker.Models.Interfaces
{
	public interface IBudgetRepository
	{
		int Create(BudgetDto dto);
		void Update(BudgetDto dto);
		void Delete(int id);

		List<BudgetDto> Search(string name);
		BudgetDto Get(int expeno);
	}
}
