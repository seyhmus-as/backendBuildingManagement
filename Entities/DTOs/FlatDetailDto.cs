
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class FlatDetailDto:IDto
	{
		public int FlatId { get; set; }
		public int ApartmentId { get; set; }
		public int PriceOfRent { get; set; }
		public int Renter { get; set; }
		public string ApartmentName { get; set; }

	}
}
