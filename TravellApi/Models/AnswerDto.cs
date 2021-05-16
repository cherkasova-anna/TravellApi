using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellApi.Models
{
    public class AnswerDto
    {
        public int Id;
        public string Text;
        public int IdFrom;
        public int IdTo;
        public bool IsEnd;

        public AnswerDto()
        {
            this.Id = 0;
            this.Text = "";
            this.IdFrom = 0;
            this.IdTo = 0;
            this.IsEnd = false;
        }

        public AnswerDto(int id, string text, int from, int to, bool end)
        {
            this.Id = id;
            this.Text = text;
            this.IdFrom = from;
            this.IdTo = to;
            this.IsEnd = end;
        }
    }
}
