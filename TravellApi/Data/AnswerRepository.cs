using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellApi.Models;
using TravellApi.Data;

namespace TravellApi.Data
{
    public class AnswerRepository: IAnswerRepository
    {
        private readonly ApplicationContext _context;

        public AnswerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddAnswerRecord(AnswerDto answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public void DeleteAnswerRecord(int id)
        {
            var entities = _context.Answers.Where(t => t.IdFrom == id || t.IdTo == id);
            //_context.Answers.Remove(entity);
            foreach (var entity in entities)
            {
                _context.Answers.Remove(entity);
            }
            _context.SaveChanges();

        }

        public List<AnswerDto> GetAnswerRecords()
        {
            return _context.Answers.ToList();
        }

        public AnswerDto GetAnswerSingleRecord(int id)
        {
            return _context.Answers.FirstOrDefault(t => t.Id == id);
        }

        public List<AnswerDto> GetAnswerFrom(int id)
        {
            return _context.Answers.Where(t => t.IdFrom == id).ToList();
        }

        public List<AnswerDto> GetAnswerTo(int id)
        {
            return _context.Answers.Where(t => t.IdTo == id).ToList();
        }

        public void UpdateAnswerRecord(AnswerDto answer)
        {
            _context.Answers.Update(answer);
            _context.SaveChanges();
        }
    }
}
