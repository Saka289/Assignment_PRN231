using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryAPI.Models;
using RepositoryAPI.Models.Dto;
using ServiceAPI.Service.IService;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePriceListController : ControllerBase
    {
        private readonly IServicePriceListService _servicePriceListService;

        public ServicePriceListController(IServicePriceListService servicePriceListService)
        {
            _servicePriceListService = servicePriceListService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _servicePriceListService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("ExportCSV")]
        public IActionResult ExportCSV()
        {
            var result = _servicePriceListService.GetAll();
            if (result != null)
            {
                var builder = new StringBuilder();
                builder.AppendLine("ServiceId,ServiceLevel,ServiceName,ServicePrice,FacilityId");
                foreach (var item in result)
                {
                    builder.AppendLine(
                        $"{item.ServiceId},{item.ServiceLevel},{item.ServiceName},{item.ServicePrice},{item.FacilityId}");
                }

                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "ServicePrice.csv");
            }

            return NotFound(result);
        }

        [HttpGet("Search/{name}")]
        public IActionResult Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            var result = _servicePriceListService.SearchByName(name);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var result = _servicePriceListService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ServicePriceListDto servicePriceListDto)
        {
            var result = _servicePriceListService.Create(servicePriceListDto);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ServicePriceListDto servicePriceListDto)
        {
            var result = _servicePriceListService.Update(servicePriceListDto);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _servicePriceListService.Delete(id);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}