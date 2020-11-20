using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonarService.Models;
using DonarService.Repositories;
using HelpingHandsApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DonarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonarController : ControllerBase
    {
        //single line comment
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DonarController));

        private readonly IRepository<Donar> _repository;

        public DonarController(IRepository<Donar> repository)
        {
            _repository = repository;
        }

        // GET: api/Donars
        [HttpGet]
        public ActionResult<IEnumerable<Donar>> GetDonar()
        {
            try
            {
                _log4net.Info("Http get request initiated");
               

                var DonarsList = _repository.Get();
                if (DonarsList != null)
                {
                _log4net.Info("All the donars were displayed");

                    return Ok(DonarsList);


                }

            }
            catch(Exception e) {
                _log4net.Error("Http get Request Failed Due to " + e.Message);

                return NoContent();
            }
           
            return BadRequest();

        }

        [HttpGet("{id}")]
        public ActionResult<Donar> GetDonar(int id)
        {
            try
            {
                _log4net.Info("Http get request initiated");


                var donar = _repository.GetById(id);
                if (donar!=null)
                {
                    _log4net.Info("Object Found");
                    return Ok(donar);
                }


            }
            catch (Exception e)
            {
                _log4net.Error("Http get Request Failed Due to " + e.Message);


                return NoContent();
            }
            return BadRequest();
        }
        [HttpPost]
        public ActionResult<Donar> PostDonar([FromBody] Donar donar)
        {
            try
            {
                _log4net.Info("Http Ppost Request Initiated");
                if (ModelState.IsValid)
                {
                    _log4net.Info("Obtained Valid Model");

                    var donaradded = _repository.Add(donar);

                    if (donaradded>0)
                    {
                        return CreatedAtAction("GetDonar", new { id = donar.DonorId }, donar);


                    }
                    else
                    {
                        return BadRequest("Donate for valid Organization");
                    }


                }

            }
            catch (Exception e)
            {
                _log4net.Error("Http post Request Failed Due to " + e.Message);


                return NotFound();
            }
            return BadRequest();
        }
    }
}
