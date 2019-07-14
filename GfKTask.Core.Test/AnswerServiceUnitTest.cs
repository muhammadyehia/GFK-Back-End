using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FizzWare.NBuilder;
using FluentAssertions;
using GfKTask.Core.Entities;
using GfKTask.Core.Interfaces;
using GfKTask.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GfKTask.Core.Test
{
    [TestClass]
    public class AnswerServiceUnitTest
    {
        private AnswerService _answerService;
        private Mock<IUnitOfWork> _unitOfWorkMoq;
        [TestInitialize]
        public void TestInitialize()
        {
         
            var answerRepo = new Mock<IRepository<Answer>>();
            _unitOfWorkMoq = new Mock<IUnitOfWork>();
            _unitOfWorkMoq.SetupGet(uf => uf.AnswersRepository).Returns(answerRepo.Object);
         
            _answerService = new AnswerService(_unitOfWorkMoq.Object);

        }
        [TestMethod]
        public void AnswerMultipleChoiceQuestion_CallUpdateAsSameAsNumberOfAnsers()
        {
            var answers = Builder<Answer>.CreateListOfSize(100).Build();
            _unitOfWorkMoq.Setup(uf => uf.Commit()).Returns(answers.Count);
            var result = _answerService.AnswerMultipleChoiceQuestion(answers);
            result.Should().BeTrue();
            _unitOfWorkMoq.Verify(uf => uf.AnswersRepository.Update(It.IsAny<Answer>()), Times.Exactly(answers.Count));
        }
       
    }
}
