using System;
using DefaultNamespace;

namespace Simple.Threading.Tasks
{
    public static class Awaitable
    {
        public static AwaitableWhenAll WhenAll(params BaseAwaitableTask[] tasks)
        {
            return new AwaitableWhenAll(tasks);
        }

        public static AwaitableWhenAny WhenAny(params BaseAwaitableTask[] tasks)
        {
            return new AwaitableWhenAny(tasks);
        }

        public static AwaitableDelay Delay(float seconds)
        {
            return new AwaitableDelay(seconds);
        }

        #region CallbackWrapper
        public static AwaitableCallbackWrapper WaitCallback(out Action callbackWrapper)
        {
            var task = new AwaitableCallbackWrapper();
            callbackWrapper = task.GetWrapper();
            return task;
        }

        public static AwaitableCallbackWrapper<TResult> WaitCallback<TResult>(out Action<TResult> callbackWrapper)
        {
            var task = new AwaitableCallbackWrapper<TResult>();
            callbackWrapper = task.GetWrapper();
            return task;
        }

        public static AwaitableCallbackWrapper<TResult1, TResult2> WaitCallback<TResult1, TResult2>(
            out Action<TResult1, TResult2> callbackWrapper)
        {
            var task = new AwaitableCallbackWrapper<TResult1, TResult2>();
            callbackWrapper = task.GetWrapper();
            return task;
        }

        public static AwaitableCallbackWrapper<TResult1, TResult2, TResult3> WaitCallback<TResult1, TResult2, TResult3>(
            out Action<TResult1, TResult2, TResult3> callbackWrapper)
        {
            var task = new AwaitableCallbackWrapper<TResult1, TResult2, TResult3>();
            callbackWrapper = task.GetWrapper();
            return task;
        }

        public static AwaitableCallbackWrapper<TResult1, TResult2, TResult3, TResult4> WaitCallback<TResult1, TResult2,
            TResult3, TResult4>(
            out Action<TResult1, TResult2, TResult3, TResult4> callbackWrapper)
        {
            var task = new AwaitableCallbackWrapper<TResult1, TResult2, TResult3, TResult4>();
            callbackWrapper = task.GetWrapper();
            return task;
        }

        public static AwaitableCallbackWrapper<TResult1, TResult2, TResult3, TResult4, TResult5> WaitCallback<TResult1,
            TResult2, TResult3, TResult4, TResult5>(
            out Action<TResult1, TResult2, TResult3, TResult4, TResult5> callbackWrapper)
        {
            var task = new AwaitableCallbackWrapper<TResult1, TResult2, TResult3, TResult4, TResult5>();
            callbackWrapper = task.GetWrapper();
            return task;
        }
        #endregion
    }
}