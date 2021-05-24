using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardHistoriesController : ControllerBase
	{
		ICardHistoryService _cardHistoryService;

		public CardHistoriesController(ICardHistoryService parkHistoryService)
		{
			_cardHistoryService = parkHistoryService;
		}

		[HttpPost("add")]
		public IActionResult Add(CardHistory cardHistory)
		{
			var result = _cardHistoryService.Add(cardHistory);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(CardHistory cardHistory)
		{
			var result = _cardHistoryService.Update(cardHistory);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(int id)
		{
			var result = _cardHistoryService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			Thread.Sleep(1000);
			var result = _cardHistoryService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int cardId)
		{
			var result = _cardHistoryService.GetById(cardId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getmonthlymoneybyid")]
		public IActionResult GetMonthIncomeById(int flatId, int secondBegin, int secondFinal, bool isIncome)
		{
			var result = _cardHistoryService.GetMonthlyMoneyById(flatId, secondBegin, secondFinal, isIncome);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getmonthlytotalmoneybyid")]
		public IActionResult GetMonthIncomeByIdtotal(int flatId, int secondBegin, int secondFinal, bool isIncome)
		{
			var result = _cardHistoryService.GetMonthlyMoneyTotalById(flatId, secondBegin, secondFinal, isIncome);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getmonthlymoney")]
		public IActionResult GetMonthIncome(int secondBegin, int secondFinal, bool isIncome)
		{
			var result = _cardHistoryService.GetMonthlyMoney(secondBegin, secondFinal,isIncome);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("details")]
		public IActionResult Details()
		{
			var result = _cardHistoryService.GetCardHistoryDetails();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
