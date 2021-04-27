using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
			var result = _cardHistoryService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getbyid")]
		public IActionResult GetById(int carId)
		{
			var result = _cardHistoryService.GetById(carId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
