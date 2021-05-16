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
        // GET: api/answer
        [HttpGet]
        public IEnumerable<AnswerDto> Get()
        {
            return AnswerData.AllAnswers();
        }

        // GET api/answer/5
        [HttpGet("{id}")]
        public IEnumerable<AnswerDto> Get(int id)
        {
            AnswerDto defaultAnswer = new AnswerDto();
            List<AnswerDto> answers = AnswerData.AllAnswers().Where(el => el.IdFrom == id).ToList();
            if (answers.Count > 0)
            {
                return answers;
            }
            else
            {
                return new List<AnswerDto>();
            }
        }

        // POST api/answer
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/answer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/answer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
