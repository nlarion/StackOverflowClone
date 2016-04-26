using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StackOverflowClone.Models
{
    [Table("Answers")]
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Votes { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
