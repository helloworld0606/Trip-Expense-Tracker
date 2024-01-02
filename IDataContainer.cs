using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trip_Expense_Tracker
{
	internal interface IDataContainer
	{
		void Display();
		void Balance(decimal totalAmount);
		
	}

}
