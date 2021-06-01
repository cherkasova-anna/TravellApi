using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravellApi.Models
{
    public class StateDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsFirst { get; set; }

        public StateDto() {
            this.Id = 0;
            this.Text = "";
            this.IsFirst = false;
        }

        public StateDto(int id,  string text, bool first)
        {
            this.Id = id;
            this.Text = text;
            this.IsFirst = first;
        }
    }
}
