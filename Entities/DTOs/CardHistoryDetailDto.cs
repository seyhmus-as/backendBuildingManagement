
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CardHistoryDetailDto:IDto
	{
		public int Id { get; set; }
		public int CardId { get; set; }
		public int FlatId { get; set; }
		public DateTime? Date { get; set; }
		public int Price { get; set; }
		public string Name { get; set; }
		public bool IsIncome { get; set; }
	}
}
