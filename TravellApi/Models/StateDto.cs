using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace TravellApi.Models
{
    public class StateDto
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsFirst { get; set; }
        public bool IsEnd { get; set; }
        public string Explanation { get; set; }

        public StateDto() {
            this.Id = 0;
            this.Text = "";
            this.IsFirst = false;
            this.IsEnd = false;
            this.Explanation = "";
        }

        public StateDto(int id,  string text, bool first, bool end, string explanation)
        {
            this.Id = id;
            this.Text = text;
            this.IsFirst = first;
            this.IsEnd = end;
            this.Explanation = explanation;
        }
    }
}
