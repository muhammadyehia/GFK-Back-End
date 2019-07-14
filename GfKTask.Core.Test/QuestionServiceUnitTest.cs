using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using GfKTask.Core.Entities;
using GfKTask.Core.Interfaces;
using GfKTask.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GfKTask.Core.Test
{
    [TestClass]
    public class QuestionServiceUnitTest
    {
        private QuestionService _questionService;
        private List<Question> _questions;
        [TestInitialize]
        public void TestInitialize()
        {
            var unitOfWorkMoq = new Mock<IUnitOfWork>();
            var questionRepo = new Mock<IRepository<Question>>();
            var question1 = new Question()
            {
                Id = 1,
                Text = "How did you find out about this job opportunity?",
                Type = QuestionType.SingleChoice,

            };
            var question2 = new Question()
            {
                Id = 2,
                Text = "How do you find the company’s location?",
                Type = QuestionType.MultipleChoice

            };
             _questions = new List<Question>() { question1, question2};
          

            unitOfWorkMoq.SetupGet(uf => uf.QuestionsRepository).Returns(questionRepo.Object);
       
            questionRepo.Setup(qq => qq.Query(It.IsAny<List<Expression<Func<Question, bool>>>>(), It.IsAny<Func<IQueryable<Question>, IOrderedQueryable<Question>>>(), It.IsAny< List<Expression<Func<Question, object>>>>())).Returns(_questions.AsQueryable());

            _questionService = new QuestionService(unitOfWorkMoq.Object);

        }
        [TestMethod]
        public void Get_GetAllQuestionsIncludingAnswers_SetupedResult()
        {
            var result = _questionService.GetAllQuestionsIncludingAnswers();
            result.Should().BeEquivalentTo(_questions);
        }
       
    }
}
