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

        public int AddStateRecord(StateDto state)
        {
            _context.States.Add(state);
            Console.WriteLine(state.Id);
            _context.SaveChanges();
            return state.Id;
        }

        public void DeleteStateRecord(int id)
        {
            var entity = _context.States.FirstOrDefault(t => t.Id == id);
            _context.States.Remove(entity);
            _context.SaveChanges();

        }

        public List<StateDto> GetStateRecords()
        {
            return _context.States.ToList();
        }

        public StateDto GetStateSingleRecord(int id)
        {
            return _context.States.FirstOrDefault(t => t.Id == id);
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
