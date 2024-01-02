using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.EFModels;
using Trip_Expense_Tracker.Models.Interfaces;

namespace Trip_Expense_Tracker.Models.Repositories
{
	public class BudgetEFRepo : IBudgetRepository
	{
		public int Create(BudgetDto dto)
		{
			var db = new MyDbContext();
			var model = new budget();

			model.name = dto.Name;
			model.budgno = (int)dto.Budgno;

			db.budgets.Add(model);
			db.SaveChanges();
			return model.budgno;
		}

		public void Delete(int budgno)
		{
			var db = new MyDbContext();
			var model = db.budgets.Find(budgno);

			db.budgets.Remove(model);

			db.SaveChanges();
		}

		public BudgetDto Get(int budgno)
		{
			var db = new MyDbContext();
			BudgetDto data = db.budgets.AsNoTracking().Where(x => x.budgno == budgno).Select(x => new BudgetDto { Name = x.name, Budgno = x.budgno }).FirstOrDefault();
			return data;
		}

		public List<BudgetDto> Search(string name)
		{
			var db = new MyDbContext();

			List<BudgetDto> data = db.budgets.AsNoTracking()
												.Where(x => x.name.Contains(name)).OrderBy(x => x.budgno)
												.Select(x => new BudgetDto { Name = x.name, Budgno = x.budgno }).ToList();
			return data;
		}

		public void Update(BudgetDto dto)
		{
			var db = new MyDbContext();
			var model = db.budgets.Find(dto.Budgno);
			model.name = dto.Name;
			model.budgno = (int)dto.Budgno;

			db.SaveChanges();
		}
	}
}
