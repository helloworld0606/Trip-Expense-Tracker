using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.Interfaces;

namespace Trip_Expense_Tracker.Models.Services
{
	public class ExpenseService:IExpenseRepository
	{
		private readonly IExpenseRepository _repository;
		

		public ExpenseService(IExpenseRepository repository)
		{
			_repository = repository;
		}

		

		public int Create(ExpenseDto dto)
		{
			bool isExists = _repository.Search(dto.Name).Any(x => x.Name == dto.Name);
			if (isExists) { throw new Exception($"名稱重複{dto.Name}"); }
			

			bool isExistsId = _repository.Search(dto.Expeno.ToString()).Any(x => x.Expeno == dto.Expeno);
			if (isExistsId) { throw new Exception($"消費項目編號{dto.Expeno}已重複!"); }
			
			return _repository.Create(dto);
		}

		

		public void Delete(int id)
		{
			_repository.Delete(id);
		}

		public ExpenseDto Get(int expeno)
		{
			return _repository.Get(expeno);
		}

		public List<ExpenseDto> Search(string name)
		{
			return _repository.Search(name);
		}

		public void Update(ExpenseDto dto)
		{
			bool isExists = _repository.Search(dto.Name).Any(x => x.Name == dto.Name);
			if (isExists) throw new Exception($"名稱重複{dto.Name}");
			 

			bool isExistsId = _repository.Search(dto.Expeno.ToString()).Any(x => x.Expeno == dto.Expeno);
			if (isExistsId) throw new Exception($"消費項目編號{dto.Expeno}已重複!");
			 _repository.Update(dto);
		}

		
	}
}
