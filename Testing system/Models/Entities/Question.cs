using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Testing_system.Models.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string UserAnswer { get; set; }
        public Test Test { get; set; }
        public int TestId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
