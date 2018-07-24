using Coad.GenericCrud.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.ActionResultTools
{
    public class OpenDbContextInViewAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //DbContextFactory.CriarTodosOsDbContexts();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            DbContextFactory.FecharTodosOsDbContexts();
        }
    }
}
