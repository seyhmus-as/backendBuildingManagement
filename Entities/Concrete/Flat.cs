using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Flat : IEntity
	{
		public int Id { get; set; }
		public int FlatNo { get; set; }
		public int ApartmentId { get; set; }
		public int PriceOfRent { get; set; }
		public int RenterId { get; set; }
	}
}
