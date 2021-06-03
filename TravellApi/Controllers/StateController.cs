using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravellApi.Data;
using TravellApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravellApi.Controllers
{
    [Route("api/[controller]")]
    public class StateController : Controller
    {
        private readonly IStateRepository _stateRepository;

        public StateController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        // GET: api/state
        [HttpGet]
        public IEnumerable<StateDto> Get()
        {
            return _stateRepository.GetStateRecords();
        }

        // GET api/state/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var state = _stateRepository.GetStateSingleRecord(id);
            if (state != null)
            {
                return Ok(_stateRepository.GetStateSingleRecord(id));
            } else
            {
                return NotFound();
            }           
        }

        // GET api/state/first
        [HttpGet("first")]
        public StateDto GetFirst()
        {
            return _stateRepository.GetFirstState();
        }

        // POST api/state
        [HttpPost]
        public IActionResult Post([FromBody]StateDto state)
        {
            if (ModelState.IsValid)
            {
                _stateRepository.AddStateRecord(state);
                return Ok(state);
            }
            return BadRequest();
        }

        // PUT api/state/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StateDto state)
        {
            if (ModelState.IsValid)
            {
                _stateRepository.UpdateStateRecord(state);
                return Ok(state);
            }
            return BadRequest();
        }

        // DELETE api/state/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _stateRepository.GetStateSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _stateRepository.DeleteStateRecord(id);
            return Ok();
        }
    }
}
