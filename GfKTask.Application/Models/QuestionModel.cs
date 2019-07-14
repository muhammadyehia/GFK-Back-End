using GfKTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GfKTask.Application.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public  List<AnswerModel> Answers { get; set; }
    }
}