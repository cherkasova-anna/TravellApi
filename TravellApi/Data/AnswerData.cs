using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellApi.Models;

namespace TravellApi.Data
{
    public class AnswerData
    {

        public static List<AnswerDto> AllAnswers()
        {
            List<AnswerDto> answers = new List<AnswerDto>();
            answers.Add(new AnswerDto(1, "Посмотреть горрода и достопримечательности", 0, 1, false));
            answers.Add(new AnswerDto(1, "Провести время на природе", 0, 2, false));
            answers.Add(new AnswerDto(1, "Отдохнуть и поправить здоровье", 0, 3, false));
            return answers;

        }
    }
}
