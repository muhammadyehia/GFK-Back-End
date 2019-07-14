using GfKTask.Core.Entities;
using GfKTask.Core.Interfaces;
using GfKTask.Core.Services;
using GfKTask.Infrastructure;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GfKTask.Application.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<DbContext, GfkContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IRepository<Question>, Repository<Question>>(Lifestyle.Scoped);
            container.Register<IRepository<Answer>, Repository<Answer>>(Lifestyle.Scoped);
            container.Register<IQuestionService, QuestionService>(Lifestyle.Transient);
            container.Register<IAnswerService, AnswerService>(Lifestyle.Transient);
            container.Verify(VerificationOption.VerifyAndDiagnose);
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}