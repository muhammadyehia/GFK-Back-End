namespace GfKTask.Infrastructure.Migrations
{
    using GfKTask.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GfKTask.Infrastructure.GfkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GfKTask.Infrastructure.GfkContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

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
            var question3 = new Question()
            {
                Id = 3,
                Text = "What was your impression of the office where you had the interview?",
                Type = QuestionType.SingleChoice

            };
            var question4 = new Question()
            {
                Id = 4,
                Text = "How technically challenging was the interview?",
                Type = QuestionType.SingleChoice,

            };
            var question5 = new Question()
            {
                Id = 5,
                Text = "How can you describe the manager that interviewed you?",
                Type = QuestionType.MultipleChoice
            };
            var answers = new List<Answer>()
               {
                   new Answer()
                   {
                       Id=1,
                       Number=0,
                       Text="StackOverflow",
                       Question=question1
                   },
                    new Answer()
                   {
                       Id=2,
                       Number=0,
                       Text="Indeed",
                       Question=question1
                   },
                     new Answer()
                   {
                       Id=3,
                       Number=0,
                       Text="Other",
                       Question=question1
                   },
                     new Answer()
                   {
                       Id=4,
                       Number=0,
                       Text="Easy to access by public transport",
                       Question=question2
                   },
                    new Answer()
                   {
                       Id=5,
                       Number=0,
                       Text="Easy to access by car",
                       Question=question2
                   },
                     new Answer()
                   {
                       Id=6,
                       Number=0,
                       Text="In a pleasant area",
                       Question=question2
                   } ,
                     new Answer()
                   {
                       Id=7,
                       Number=0,
                       Text="None of the above",
                       Question=question2
                   },
                      new Answer()
                   {
                       Id=8,
                       Number=0,
                       Text="Tidy",
                       Question=question3
                   },
                    new Answer()
                   {
                       Id=9,
                       Number=0,
                       Text="Sloppy",
                       Question=question3
                   },
                     new Answer()
                   {
                       Id=10,
                       Number=0,
                       Text="Did not notice",
                        Question=question3
                   },
                      new Answer()
                   {
                       Id=11,
                       Number=0,
                       Text="Very difficult",
                        Question=question4
                   },
                    new Answer()
                   {
                       Id=12,
                       Number=0,
                       Text="Difficult",
                        Question=question4
                   },
                     new Answer()
                   {
                       Id=13,
                       Number=0,
                       Text="Moderate",
                        Question=question4
                   },
                     new Answer()
                   {
                       Id=14,
                       Number=0,
                       Text="Easy",
                        Question=question4
                   },
                      new Answer()
                   {
                       Id=15,
                       Number=0,
                       Text="Enthusiastic",
                        Question=question5
                   },
                    new Answer()
                   {
                       Id=16,
                       Number=0,
                       Text="Polite",
                        Question=question5
                   },
                     new Answer()
                   {
                       Id=17,
                       Number=0,
                       Text="Organized",
                        Question=question5
                   },
                     new Answer()
                   {
                       Id=18,
                       Number=0,
                       Text="Could not tell",
                        Question=question5
                   }
               };
            var questions = new List<Question>() { question1, question2, question3, question4, question5 };
            context.Questions.AddRange(questions);
            context.Answers.AddRange(answers);
        }
    }
}
