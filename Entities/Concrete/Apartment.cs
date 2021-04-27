using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Apartment:IEntity
	{
		public int ApartmentId { get; set; }
		public string ApartmentName { get; set; }
		public int NumberOfFlat { get; set; }
		public int NumberOfFloor { get; set; }
	}
}
