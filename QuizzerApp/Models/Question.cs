using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace QuizzerApp.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required(ErrorMessage ="Enter Question")]
        public string Text { get; set; }
        public virtual List<Choice> Choice { get; set; }

    }
    public  class Choice
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string value { get; set; }
        public  Boolean is_correct { get; set; }
        public virtual int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}