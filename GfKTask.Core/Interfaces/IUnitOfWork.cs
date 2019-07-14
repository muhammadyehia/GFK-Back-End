using GfKTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GfKTask.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Answer> AnswersRepository { get; }
        IRepository<Question> QuestionsRepository { get; }
        bool AutoDetectChange { set; }
        bool ValidateOnSaveEnabled { set; }
        int Commit();
        void BulkCommit();
    }
}
