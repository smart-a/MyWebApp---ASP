using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppData.Interfaces;
using MyAppData.Models;
using MyAppData.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppAPI.Controllers
{
    [EnableCors("AllowOrigin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnumerationController : ControllerBase
    {
        private readonly IApplicant _appl;
        private readonly ITrail _tr;
        private readonly IGeneral _gen;
        private readonly IMapper _map;
        public EnumerationController(IApplicant appl, IGeneral gen,   ITrail tr, IMapper map)
        {
        
            _appl = appl;
            _tr = tr;
            _gen = gen;
            _map = map;
        }


        [HttpGet]
        public async Task<ActionResult> GetApplicants()
        {
            try
            {
                return Ok(await _appl.GetApplicants());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Applicants>> GetApplicant(long id)
        {
            try
            {
                var result = await _appl.GetApplicant(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

 
        [HttpPost]
        public async Task<ActionResult<Applicants>> CreateApplicant(ApplicantsVM appl)
        {
            var email = "XYZ"; //User.FindFirst("Email")?.Value;
            var applicant = _map.Map<Applicants>(appl);
            var fn = String.IsNullOrEmpty(applicant.MiddleName) ? applicant.FirstName.ToUpper() + " " + applicant.LastName.ToUpper() : applicant.FirstName.ToUpper() + " " + applicant.MiddleName.ToUpper() + " " + applicant.LastName.ToUpper();
            applicant.FullName = fn;
            if (ModelState.IsValid)
            {
                try
                {
                    if (appl == null)
                        return BadRequest();

                    var createdApplicant = await _appl.AddApplicant(applicant, email);

                    return CreatedAtAction(nameof(GetApplicant),
                        new { id = createdApplicant.Id }, createdApplicant);
                }
                catch (Exception ex)
                {
                    string messages = string.Join("; ", ModelState.Values
                                              .SelectMany(x => x.Errors)
                                              .Select(x => x.ErrorMessage));
                    return BadRequest($"Exception {ex.Message}");
                }
            }
            else
            {
                string messages = string.Join("; ", ModelState.Values
                                         .SelectMany(x => x.Errors)
                                         .Select(x => x.ErrorMessage));
                return BadRequest($"Exception {messages}");
            }
        }





 
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<Applicants>> DeleteApplicant(long id)
        {
            try
            {
                var applicantToDelete = await _appl.GetApplicant(id);

                if (applicantToDelete == null)
                {
                    return NotFound($"Applicant with Id = {id} not found");
                }

                return await _appl.DeleteApplicant(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<Applicants>> UpdateApplicant(int id, ApplicantsVM appl)
        {
            var applicant = _map.Map<Applicants>(appl);
            applicant.ModifiedBy = "Mobile";//User.FindFirst("Email")?.Value;
            applicant.FullName = String.IsNullOrEmpty(applicant.MiddleName) ? applicant.FirstName.ToUpper() + " " + applicant.LastName.ToUpper() : applicant.FirstName.ToUpper() + " " + applicant.MiddleName.ToUpper() + " " + applicant.LastName.ToUpper();
            try
            {
                if (id != applicant.Id)
                    return BadRequest("Applicant ID mismatch");

                var applicantToUpdate = await _appl.GetApplicant(id);

                if (applicantToUpdate == null)
                    return NotFound($"Applicant with Id = {id} not found");

                return await _appl.UpdateApplicant(applicant);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}

