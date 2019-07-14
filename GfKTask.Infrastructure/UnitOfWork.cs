using GfKTask.Core.Entities;
using GfKTask.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace GfKTask.Infrastructure
{
 public    class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context, IRepository<Answer> answersRepository, IRepository<Question> questionsRepository)
        {
            _context = context;
            AnswersRepository = answersRepository;
            QuestionsRepository = questionsRepository;
        }

        public bool AutoDetectChange
        {
            set { _context.Configuration.AutoDetectChangesEnabled = value; }
        }



        public bool ValidateOnSaveEnabled
        {
            set { _context.Configuration.ValidateOnSaveEnabled = value; }
        }

        public IRepository<Answer> AnswersRepository { get; }

        public IRepository<Question> QuestionsRepository { get; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void BulkCommit()
        {
            _context.BulkSaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
