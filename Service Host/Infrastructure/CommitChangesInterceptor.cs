using System.Data.Objects;
using Ninject;
using Ninject.Extensions.Interception;

namespace Ndc2011.ServiceHost.Infrastructure
{
    public class CommitChangesInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            invocation.Request.Kernel.Get<ObjectContext>().SaveChanges();
        }
    }
}