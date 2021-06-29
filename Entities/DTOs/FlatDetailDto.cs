
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class FlatDetailDto:IDto
	{
		public int Id { get; set; }
		public int FlatNo { get; set; }
		public int PriceOfRent { get; set; }
		public int RenterId { get; set; }
		public string RenterName { get; set; }
		public int ApartmentId { get; set; }
		public string ApartmentName { get; set; }

	}
}
