using GfKTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfKTask.Core.Interfaces
{
   public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestionsIncludingAnswers();
    }
}
