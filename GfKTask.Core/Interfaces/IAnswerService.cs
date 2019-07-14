using GfKTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfKTask.Core.Interfaces
{
    public interface IAnswerService
    {
        bool AnswerSingleChoiceQuestion(Answer answer);
        bool AnswerMultipleChoiceQuestion(IList<Answer> answers);
        IEnumerable<Answer> GetAnswers(List<int> answerIds);
    }
}
