using System;
using System.Collections.Generic;
using System.Linq;
using Trip_Expense_Tracker.Models.Dto;
using Trip_Expense_Tracker.Models.Interfaces;

namespace Trip_Budget_Tracker.Models.Services
{
	public class BudgetService : IBudgetRepository
	{
		private readonly IBudgetRepository _repository;
		public BudgetService(IBudgetRepository repository)
		{
			_repository = repository;
		}
		public int Create(BudgetDto dto)
		{
			bool isExists = _repository.Search(dto.Name).Any(x => x.Name == dto.Name);
			if (isExists) throw new Exception($"名稱重複{dto.Name}");
			

			bool isExistsId = _repository.Search(dto.Budgno.ToString()).Any(x => x.Budgno == dto.Budgno);
			if (isExistsId) throw new Exception($"消費項目編號{dto.Budgno}已重複!");
			return _repository.Create(dto);
		}

		public void Delete(int id)
		{
			_repository.Delete(id);
		}

		public BudgetDto Get(int Budgno)
		{
			return _repository.Get(Budgno);
		}

		public List<BudgetDto> Search(string name)
		{
			return _repository.Search(name);
		}

		public void Update(BudgetDto dto)
		{
			bool isExists = _repository.Search(dto.Name).Any(x => x.Name == dto.Name);
			if (isExists) throw new Exception($"不可更改預算項目編號!");
			

			bool isExistsId = _repository.Search(dto.Budgno.ToString()).Any(x => x.Budgno == dto.Budgno);
			if (isExistsId) throw new Exception($"消費項目編號{dto.Budgno}已重複!");
			_repository.Update(dto);
		}
	}
}
