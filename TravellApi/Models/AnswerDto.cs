using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellApi.Models
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int IdFrom { get; set; }
        public int IdTo { get; set; }

        public AnswerDto()
        {
            this.Id = 0;
            this.Text = "";
            this.IdFrom = 0;
            this.IdTo = 0;
        }

        public AnswerDto(int id, string text, int from, int to)
        {
            this.Id = id;
            this.Text = text;
            this.IdFrom = from;
            this.IdTo = to;
        }
    }
}
