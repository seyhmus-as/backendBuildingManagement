using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string CarAdded = "Ürün eklendi";
		public static string CarNameInvalid = "Ürün ismi geçersiz";
		public static string MaintenanceTime = "Sistem bakımda";
		public static string CarsListed = "Ürünler listelendi";
		public static string CarCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
		public static string CarNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
		public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
		public static string AuthorizationDenied = "Yetkiniz yok.";
		public static string PriceListed = "Price listelendi";
		public static string ParkHistoryAdded = "ParkHistoryAdded";
		public static string ParkHistoryListed = "ParkHistoryListed";
		public static string CustomerAdded= "CustomerAdded";
		public static string CustomersListed = "CustomersListed";
		public static string CarDeleted= "CarDeleted";
		public static string CarUpdate= "CarUpdate";
		public static string CustomerDeleted= "CustomerDeleted";
		public static string CustomerUpdate= "CustomerUpdate";
		public static string parkHistoryDeleted= "parkHistoryDeleted";
		public static string parkHistoryUpdate= "parkHistoryUpdate";
		public static string PriceAdded= "PriceAdded";
		public static string PriceDeleted= "PriceDeleted";
		public static string PriceUpdated= "PriceUpdated";
		public static string CarTakeOut= "CarTakeOut";
		public static string PriceCalculated = "priceCalculated";
		public static string AbonnementPriceCalculated= "AbonnementPriceCalculated";
		public static string cardHistoryDeleted;
		public static string FlatDeleted;
		public static string RenterListed;
	}
}
