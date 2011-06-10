using System;
using Ninject.Extensions.Interception;

namespace Ndc2011.ServiceHost.Infrastructure
{
    public class ExceptionToCommandResultInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch(Exception ex)
            {
                ex = Unwrap(ex);

                var result = new CommandResult {Status = CommandStatus.Failed, Message = ex.Message};
                invocation.ReturnValue = result;
            }
        }

        private Exception Unwrap(Exception ex)
        {
            while (null != ex.InnerException)
            {
                ex = ex.InnerException;
            }

            return ex;
        }
    }
}