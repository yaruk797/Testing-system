using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing_system.Models.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRight { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
