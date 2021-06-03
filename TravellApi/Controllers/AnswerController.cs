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
    public class AnswerController : Controller
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
        // GET: api/answer
        public IEnumerable<AnswerDto> Get()
        {
            return _answerRepository.GetAnswerRecords();
        }

        // GET api/answer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var answer = _answerRepository.GetAnswerSingleRecord(id);
            if (answer != null)
            {
                return Ok(answer);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/answer/from/5
        [HttpGet("from/{id}")]
        public IActionResult GetFirst(int id)
        {
            var answer = _answerRepository.GetAnswerFrom(id);
            if (answer != null)
            {
                return Ok(answer);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/answer
        [HttpPost]
        public IActionResult Post([FromBody]AnswerDto answer)
        {
            if (ModelState.IsValid)
            {
                _answerRepository.AddAnswerRecord(answer);
                return Ok(answer);
            }
            return BadRequest();
        }

        // PUT api/answer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AnswerDto answer)
        {
            if (ModelState.IsValid)
            {
                _answerRepository.UpdateAnswerRecord(answer);
                return Ok(answer);
            }
            return BadRequest();
        }

        // DELETE api/answer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _answerRepository.GetAnswerSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _answerRepository.DeleteAnswerRecord(id);
            return Ok();
        }
    }
}
