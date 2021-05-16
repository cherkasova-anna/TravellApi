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
        // GET: api/state
        [HttpGet]
        public IEnumerable<StateDto> Get()
        {
            return StateData.AllStates();
        }

        // GET api/state/5
        [HttpGet("{id}")]
        public ActionResult<StateDto> Get(int id)
        {
            StateDto defaultState = new StateDto();
            List<StateDto> states = StateData.AllStates().Where(el => el.Id == id).ToList();
            if (states.Count > 0)
            {
                return new ObjectResult(states.ElementAt(0));
            }
            else
            {
                return NotFound();
                
            }
        }

        // GET api/state/first
        [HttpGet("first")]
        public ActionResult<StateDto> GetFirst()
        {
            StateDto first = StateData.FirstState();
            if (first == null)
            {
                return NotFound();
            } else
            {
                return new ObjectResult(first);
            }
        }

        // POST api/state
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/state/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/state/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
