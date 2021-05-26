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
	public class FlatsController : ControllerBase
	{
		IFlatService _flatService;
		public FlatsController(IFlatService flatService)
		{
			_flatService = flatService; 
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _flatService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);

		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int flatId)
		{
			var result = _flatService.GetById(flatId);
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(Flat flat)
		{
			var result = _flatService.Add(flat);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Flat flat)
		{
			var result = _flatService.Update(flat);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(int id)
		{
			var result = _flatService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getdetails")]
		public IActionResult Details()
		{
			var result = _flatService.GetFlatDetails();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

	}
}
