using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Expense_Tracker.Models.Dto;

namespace Trip_Expense_Tracker.Models.Interfaces
{
	public interface ITransactionRepository
	{

			int Create(TransactionDto dto);
			void Update(TransactionDto dto);
			void Delete(int id);

			List<TransactionDto> Search(/*bool DebitOrCredit, DateTime date*/);
			TransactionDto Get(int id);

			List<TransactionDto> Search(DateTime dt);


	}
}
