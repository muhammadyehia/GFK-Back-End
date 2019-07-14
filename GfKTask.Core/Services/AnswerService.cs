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
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.AutoDetectChange = false;
            _unitOfWork.ValidateOnSaveEnabled = false;
        }
        public IEnumerable<Answer> GetAnswers(List<int> answerIds)
        {
            List<Expression<Func<Answer, bool>>> filters = new List<Expression<Func<Answer, bool>>>
            {
                c => answerIds.Any(d => d == c.Id)
            };
            var result = _unitOfWork.AnswersRepository.Query(filters: filters).AsEnumerable();
            return result;
        }
        public bool AnswerMultipleChoiceQuestion(IList<Answer> answers)
        {
            foreach (var answer in answers)
            {
                answer.Number++;
                _unitOfWork.AnswersRepository.Update(answer);
            }
            var result = _unitOfWork.Commit();
            return result > 0;
        }

        public bool AnswerSingleChoiceQuestion(Answer answer)
        {
            answer.Number++;
            _unitOfWork.AnswersRepository.Update(answer);
            var result = _unitOfWork.Commit();
            return result > 0;
        }
    }
}
