using Castle.DynamicProxy;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception :MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation,System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation) 
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                //var task = invocation.ReturnValue as Task;
                //await task.ConfigureAwait(false);
              

            }
            catch (Exception e)
            {

                isSuccess = false;
                OnException(invocation, e);
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);

        }

        //private async Task MainMethodExceptionControl(Task source)
        //{
        //    try
        //    {
        //        await source;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
