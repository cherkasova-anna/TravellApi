using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellApi.Models;

namespace TravellApi.Data
{
    public class StateRepository: IStateRepository
    {
        private readonly ApplicationContext _context;

        public StateRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddStateRecord(StateDto state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
        }

        public void DeleteStateRecord(string id)
        {
            var entity = _context.States.FirstOrDefault(t => t.Id.ToString() == id);
            _context.States.Remove(entity);
            _context.SaveChanges();

        }

        public List<StateDto> GetStateRecords()
        {
            return _context.States.ToList();
        }

        public StateDto GetStateSingleRecord(string id)
        {
            return _context.States.FirstOrDefault(t => t.Id.ToString() == id);
        }

        public void UpdateStateRecord(StateDto state)
        {
            _context.States.Update(state);
            _context.SaveChanges();
        }

        public StateDto GetFirstState()
        {
            return _context.States.FirstOrDefault(t => t.IsFirst == true);
        }
    }
}
