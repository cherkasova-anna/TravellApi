using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellApi.Models;

namespace TravellApi.Data
{
    public interface IAnswerRepository
    {
        void AddAnswerRecord(AnswerDto answer);
        void UpdateAnswerRecord(AnswerDto answer);
        void DeleteAnswerRecord(int id);
        AnswerDto GetAnswerSingleRecord(int id);
        List<AnswerDto> GetAnswerFrom(int id);
        List<AnswerDto> GetAnswerTo(int id);
        List<AnswerDto> GetAnswerRecords();
    }
}
