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
        private readonly IAnswerRepository _answerRepository;

        public StateController(IStateRepository stateRepository, IAnswerRepository answerRepository)
        {
            _stateRepository = stateRepository;
            _answerRepository = answerRepository;
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
        public IActionResult Post([FromBody]StateAnswersDto state)
        {
            if (ModelState.IsValid)
            {
                var id = _stateRepository.AddStateRecord(state);
                foreach (AnswerDto answer in state.answers)
                {
                    answer.IdFrom = id;
                    _answerRepository.AddAnswerRecord(answer);
                }
                return Ok(state);
            }
            return BadRequest();
        }

        // PUT api/state/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StateAnswersDto state)
        {
            if (ModelState.IsValid)
            {
                _stateRepository.UpdateStateRecord(state);
                var old = _answerRepository.GetAnswerFrom(state.Id);

                foreach(AnswerDto answer in state.answers)
                {
                    var res = _answerRepository.GetAnswerFromTo(answer.IdFrom, answer.IdTo);
                    if (res != null)
                    {
                        _answerRepository.UpdateAnswerRecord(res);
                    } else
                    {
                        _answerRepository.AddAnswerRecord(answer);
                    }
                }
                foreach(AnswerDto answer in old)
                {
                    if (!state.answers.Contains(answer))
                    {
                        _answerRepository.DeleteAnswerRecord(answer.Id);
                    }
                }
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
            _answerRepository.DeleteAnswerRecord(id);

            return Ok();
        }
    }
}
