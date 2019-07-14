using GfKTask.Application.Models;
using GfKTask.Core.Entities;
using GfKTask.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GfKTask.Application.Controllers
{
    public class QuestionController : ApiController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
            
        }
        [HttpGet]
        [Route("GetAllQuestions")]
        public IEnumerable<QuestionModel> GetAllQuestions()
        {
            var allQestion=_questionService.GetAllQuestionsIncludingAnswers();
            var result = allQestion.Select(c => new QuestionModel() { Id = c.Id, Text = c.Text, Type = c.Type, Answers = c.Answers.Select(a => new AnswerModel() { Id = a.Id, Number = a.Number, Text = a.Text }).ToList() });
            return result;
        }

    }
}
