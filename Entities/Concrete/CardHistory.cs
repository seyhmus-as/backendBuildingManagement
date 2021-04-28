using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class CardHistory : IEntity
	{
		public int Id { get; set; }
		public int CardId { get; set; }
		public int FlatId { get; set; }
		public DateTime? Date { get; set; }
		public int Price{ get; set; }
	}
}
