using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.EFModels;
using Trip_Expense_Tracker.Models.Interfaces;

namespace Trip_Expense_Tracker.Models.Services
{
	public class TransactionService : ITransactionRepository
	{
		private readonly ITransactionRepository _repository;
		public TransactionService(ITransactionRepository repository)
		{
			_repository = repository;
		}
		public int Create(TransactionDto dto)
		{
			return _repository.Create(dto);
		}

		public void Delete(int id)
		{
			_repository.Delete(id);
		}

		public TransactionDto Get(int id)
		{
			return _repository.Get(id);
		}

		public List<TransactionDto> Search(/*bool DebitOrCredit, DateTime date*/)
		{
			return _repository.Search();
			
		}

		public List<TransactionDto> Search(DateTime dt)
		{
			return _repository.Search(dt);

		}

		public void Update(TransactionDto dto)
		{
			_repository.Update(dto);
		}
	}
}
