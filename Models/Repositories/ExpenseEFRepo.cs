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
	public class ExpenseEFRepo : IExpenseRepository
	{
		public int Create(ExpenseDto dto)
		{
			var db = new MyDbContext();
			var model = new expense();

			model.name = dto.Name;
			model.expeno = (int)dto.Expeno;

			db.expenses.Add(model);
			db.SaveChanges();
			return model.expeno;
		}

		public void Delete(int expeno)
		{
			var db = new MyDbContext();
			var model = db.expenses.Find(expeno);

			db.expenses.Remove(model);

			db.SaveChanges();
		}

		public ExpenseDto Get(int expeno)
		{
			var db = new MyDbContext();
			ExpenseDto data = db.expenses.AsNoTracking().Where(x => x.expeno == expeno).Select(x => new ExpenseDto { Name = x.name, Expeno = x.expeno }).FirstOrDefault();
			return data;
		}

		public List<ExpenseDto> Search(string name)
		{
			var db = new MyDbContext();

			List<ExpenseDto> data = db.expenses.AsNoTracking()
												.Where(x => x.name.Contains(name)).OrderBy(x => x.expeno)
												.Select(x => new ExpenseDto { Name = x.name, Expeno = x.expeno }).ToList();
			return data;
		}



		public List<ExpenseDto> Search(int expeno)
		{
			var db = new MyDbContext();

			List<ExpenseDto> data = db.expenses.AsNoTracking()
												.Where(x => x.expeno.ToString().Contains(expeno.ToString())).OrderBy(x => x.expeno)
												.Select(x => new ExpenseDto { Name = x.name, Expeno = x.expeno }).ToList();

			return data;
		}

		public void Update(ExpenseDto dto)
		{
			
				var db = new MyDbContext();
				var model = db.expenses.Find(dto.Expeno);
				model.name = dto.Name;
				model.expeno = (int)dto.Expeno;

			db.SaveChanges();	
			
		}
	}
}
