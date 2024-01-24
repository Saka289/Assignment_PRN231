using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryAPI.Models.Dto;
using ServiceAPI.Service.IService;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class MedicalfacilityController : ControllerBase
    {
        private readonly IMedicalfacilityService _medicalfacilityService;

        public MedicalfacilityController(IMedicalfacilityService medicalfacilityService)
        {
            _medicalfacilityService = medicalfacilityService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _medicalfacilityService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("ExportCSV")]
        public IActionResult ExportCSV()
        {
            var result = _medicalfacilityService.GetAll();
            if (result != null)
            {
                var builder = new StringBuilder();
                builder.AppendLine("FacilityId,FacilityName,NoDoctor,PrivateFacility,Level");
                foreach (var item in result)
                {
                    builder.AppendLine(
                        $"{item.FacilityId},{item.FacilityName},{item.NoDoctor},{item.PrivateFacility},{item.Level}");
                }

                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "Facility.csv");
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

            var result = _medicalfacilityService.SearchByName(name);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var result = _medicalfacilityService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MedicalFacilityDto medicalFacilityDto)
        {
            var result = _medicalfacilityService.Create(medicalFacilityDto);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] MedicalFacilityDto medicalFacilityDto)
        {
            var result = _medicalfacilityService.Update(medicalFacilityDto);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _medicalfacilityService.Delete(id);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}