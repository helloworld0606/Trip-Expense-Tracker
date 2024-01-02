using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.EFModels;
using Trip_Expense_Tracker.Models.Interfaces;

namespace Trip_Expense_Tracker.Models.Repositories
{
	public class TransactionEFRepo : ITransactionRepository
	{
		public int Create(TransactionDto dto)
		{
			var db = new MyDbContext();
			var model = new transaction();

			//model.id = dto.Id;
			model.amount = dto.Amount;
			model.date = dto.Date;
			model.expeno=dto.Expeno;
			model.budgno = dto.Budgno;
			model.Remarks=dto.Remarks;
			model.expense.name = dto.ExpenseName;
			model.budget.name = dto.BudgetName;
			db.transactions.Add(model);
			db.SaveChanges();
			return model.id;
		}

		public void Delete(int id)
		{
			var db = new MyDbContext();
			var model = db.transactions.Find(id);

			db.transactions.Remove(model);

			db.SaveChanges();
		}

		public TransactionDto Get(int id)
		{
			var db = new MyDbContext();
			var data = db.transactions.Include("expense")
				  .Include("budget").AsNoTracking()
						  .Where(x => x.id == id) // Correct property
						  .Select(x => new TransactionDto
						  {
							  Amount = x.amount,
							  Date = x.date,
							  // You might need to join with the related tables to get names
							  ExpenseName = x.expense.name,
							  BudgetName = x.budget.name,
							  Expeno = x.expeno,
							  Budgno=x.budgno,
							  Remarks = x.Remarks
						  })
						  .FirstOrDefault();

			return data;
		}

		public List<TransactionDto> Search()
		{
			var db = new MyDbContext();

			var data = db.transactions.Include("expense")
				  .Include("budget").AsNoTracking()
						  .Select(t => new TransactionDto
						  {
							  Id = t.id,
							  Amount = t.amount,
							  Date = t.date,
							  ExpenseName = t.expense.name, // Assuming Expense is the related entity
							  Expeno = t.expense.expeno,
							  BudgetName = t.budget.name, // Assuming Expense is the related entity
							  Budgno = t.budget.budgno,
							  Remarks = t.Remarks
						  })
						  .ToList();
			return data;
		}

		public List<TransactionDto> Search(DateTime dt)
		{
			var db = new MyDbContext();

			var data = db.transactions.AsNoTracking()
						  .Select(t => new TransactionDto
						   {
							   Id = t.id,
							   Amount = t.amount,
							   Date = t.date,
							   ExpenseName = t.expense.name, // Assuming Expense is the related entity
							   Expeno = t.expense.expeno,
							   BudgetName = t.budget.name, // Assuming Expense is the related entity
							   Budgno = t.budget.budgno,
							   Remarks=t.Remarks
						   })
						  .ToList();

			var hehe = data.Where(d => d.Date.Date == dt.Date).ToList();

			return hehe;
		}

		//public List<TransactionDto> Search(bool DebitOrCredit)
		//{
		//	var db = new MyDbContext();

		//	if(DebitOrCredit)
		//	{
		//		var data = db.transactions.AsNoTracking()
		//				  .Select(t => new TransactionDto
		//				  {
		//					  Amount = t.amount,
		//					  Date = t.date,
		//					  ExpenseName = t.expense.name, // Assuming Expense is the related entity
		//					  Expeno = t.expense.expeno
		//				  })
		//				  .ToList();
		//		return data;
		//	}
		//	else
		//	{
		//		var data = db.transactions.AsNoTracking()
		//				 .Select(t => new TransactionDto
		//				{
		//					 Amount = t.amount,
		//					 Date = t.date,
		//					 BudgetName = t.budget.name, // Assuming Expense is the related entity
		//					 Budgno = t.budget.budgno
		//				 })
		//				  .ToList();
		//		return data;
		//	}
		//}

		public void Update(TransactionDto dto)
		{
			var db = new MyDbContext();
			var model = db.transactions.Find(dto.Id);
			model.id = dto.Id;
			model.amount = dto.Amount;
			model.date = dto.Date;
			model.expense.name=dto.ExpenseName;
			model.budget.name = dto.BudgetName;
			model.Remarks = dto.Remarks;

			db.SaveChanges();
		}
	}
}
