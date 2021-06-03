using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellApi.Models;

namespace TravellApi.Data
{
    public interface IStateRepository
    {
        void AddStateRecord(StateDto state);
        void UpdateStateRecord(StateDto state);
        void DeleteStateRecord(int id);
        StateDto GetStateSingleRecord(int id);
        StateDto GetFirstState();
        List<StateDto> GetStateRecords();
    }
}
