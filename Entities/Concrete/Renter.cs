using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Renter : IEntity
	{
		public int RenterId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}