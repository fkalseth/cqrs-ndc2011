using System;
using System.Transactions;
using Ninject.Extensions.Interception;

namespace Ndc2011.ServiceHost.Infrastructure
{
    public class CommandTransactionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            using(var scope = new TransactionScope())
            {
                invocation.Proceed();

                var result = invocation.ReturnValue as CommandResult;

                if(null != result && result.Status == CommandStatus.Executed)
                {
                    scope.Complete();
                }
            }
        }
    }
}