using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public async override void Intercept(IInvocation invocation)
        {
            TransactionScope transactionScope = new(TransactionScopeAsyncFlowOption.Enabled);
            
                try
                {
                    invocation.Proceed();
                var task = invocation.ReturnValue as Task;
                if (task is Task)
                {
                    await task;
                }
                    transactionScope.Complete();
                }
                catch (System.Exception)
                {
                    transactionScope.Dispose();
                    throw;
                }
            transactionScope?.Dispose();   
        }
    }
}
