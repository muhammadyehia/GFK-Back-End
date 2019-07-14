using GfKTask.Core.Entities;
using GfKTask.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GfKTask.Core.Services
{
   public class QuestionService: IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.AutoDetectChange = false;
            _unitOfWork.ValidateOnSaveEnabled = false;
        }

        public IEnumerable<Question> GetAllQuestionsIncludingAnswers()
        {
            var includes = new List<Expression<Func<Question, object>>> 
                {
                    c => c.Answers
                };
            var result = _unitOfWork.QuestionsRepository.Query(includes: includes);

            return result.AsEnumerable();
        }
    }
}
