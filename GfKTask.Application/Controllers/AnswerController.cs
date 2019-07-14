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
    public class AnswerController : ApiController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;

        }
        // POST api/values
        [HttpPost]
        [Route("SaveAnswers")]
        public bool Post([FromBody]List<int> answersIds)
        {
            var answers = _answerService.GetAnswers(answersIds).ToList();
            var result = _answerService.AnswerMultipleChoiceQuestion(answers);
            return result;
        }

    }
}
