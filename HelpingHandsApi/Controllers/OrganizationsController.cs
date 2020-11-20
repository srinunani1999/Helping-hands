using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpingHandsApi.Data;
using HelpingHandsApi.Models;
using HelpingHandsApi.Repositories;

namespace HelpingHandsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OrganizationsController));
        private readonly IRepository<Organization> _repository;

        public OrganizationsController(IRepository<Organization> repository)
        {
            _repository = repository;
        }

        // GET: api/Organizations
        [HttpGet]
        public ActionResult<IEnumerable<Organization>> GetOrganization()
        {
            try
            {
                _log4net.Info("Http Get request Initiated");

                var orgs = _repository.Get();
                if (orgs != null)
                {
                    _log4net.Info("successfully got details");
                    return Ok(orgs);


                }

            }
            catch(Exception e)
            {
                _log4net.Error("No result "+e.Message);
                return new NoContentResult();


            }
            return BadRequest();

        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        public ActionResult<Organization> GetOrganization(int id)
        {
            try
            {
                _log4net.Info("Http get request initiated");
                var organization = _repository.GetById(id);

                if (organization == null)
                {
                    _log4net.Info("Organization with that Requested Id not Found");

                    return NotFound();
                }
                _log4net.Info("Found Matching Organization");


                return organization;
            }
            catch (Exception e)
            {

                _log4net.Error("No content Obtained "+e.Message);
                return NotFound();
            }
           
           
            
        }




        [HttpPost]
        public ActionResult<Organization> PostOrganization([FromBody] Organization organization)
        {
            try
            {
                _log4net.Info("HttpPost Request Initiated");

                if (ModelState.IsValid)
                {
                    _log4net.Info("Model state is  valid");


                    var addorganization = _repository.Add(organization);


                    return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);

                }
               

            }
            catch (Exception e)
            {

                _log4net.Error("Model state is not valid"+e.Message);
                return NotFound();
            }
            return BadRequest();
           
        }


        [HttpPut]
        public ActionResult<Organization> UpdateOrganization(Organization organization)
        {
            try
            {
                _log4net.Info("Http Put Request Initiated");
               var org= _repository.Update(organization);
                if (org!=null)
                {
                    return Ok(org);
                }
               

            }
            catch (Exception)
            {
                _log4net.Info("Http Put Request Failed");

                return NotFound();
            }
            return BadRequest();
        }

      
    }
}
