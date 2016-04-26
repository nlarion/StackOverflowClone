using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace StackOverflowClone.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
