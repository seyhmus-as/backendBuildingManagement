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
	public class ApartmentsController : ControllerBase
	{
		IApartmentService _customerService;
		public ApartmentsController(IApartmentService apartmentService)
		{
			_customerService = apartmentService;
		}
		[HttpPost("add")]
		public IActionResult Add(Apartment apartment)
		{
			var result = _customerService.Add(apartment);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpPost("update")]
		public IActionResult Update(Apartment apartment)
		{
			var result = _customerService.Update(apartment);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("delete")]
		public IActionResult Delete(int id)
		{
			var result = _customerService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			Thread.Sleep(1500);
			var result = _customerService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _customerService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

	}
}
