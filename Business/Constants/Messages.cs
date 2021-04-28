using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string ApartmentAdded = "ApartmentAdded";
		public static string CardHistoryAdded = "CardHistoryAdded";
		public static string CardAdded = "CardAdded";
		public static string FlatAdded = "FlatAdded";
		public static string RenterAdded = "RenterAdded";
		public static string ApartmentDeleted = "ApartmentDeleted";
		public static string CardHistoryDeleted = "CardHistoryDeleted";
		public static string CardDeleted = "CardDeleted";
		public static string FlatDeleted = "FlatDeleted";
		public static string RenterDeleted = "RenterDeleted";
		public static string ApartmentUpdate = "ApartmentUpdate";
		public static string CardHistoryUpdate = "CardHistoryUpdate";
		public static string FlatUpdated = "FlatUpdated";
		public static string CardUpdated = "CardUpdated";
		public static string RenterUpdated = "RenterUpdated";
		public static string RentersListed = "RenterListed";
		public static string FlatsListed = "FlatListed";
		public static string ApartmentsListed = "ApartmentsListed";
		public static string CardHistoriesListed = "CardHistoriesListed";
		public static string CardsListed = "CardsListed";
		public static string ApartmentViewedById = "ApartmentViewedById";
		public static string CardHistoryViewedById = "CardHistoryViewedById";
		public static string CardHistoryMonthlyMoneyListed = "CardHistoryMonthlyMoneyListed";
		public static string CardHistoryMonthlyMoneyTotalViewed = "CardHistoryMonthlyMoneyTotalViewed";
		public static string CardHistoryMonthlyMoneyTotalViewedById = "CardHistoryMonthlyMoneyTotalViewedById";
		public static string FlatViewedById = "FlatViewedById";
		public static string RenterViewedById = "RenterViewedById";
		public static string CardViewed = "CardViewed";
		public static string RenterNameMustStartA = "RenterNameMustStartA";
		public static string RenterNameNotNull = "RenterNameNotNull";
		public static string AuthorizationDenied = "AuthorizationDenied";
	}
}
