using System;

namespace Simple.Threading.Tasks
{
    public static class Awaitable
    {
        public static WhenAll WhenAll(params ITask[] tasks)
        {
            return new WhenAll(tasks);
        }

        public static WhenAny WhenAny(params AwaitableTask[] tasks)
        {
            return new WhenAny(tasks);
        }

        public static Delay Delay(float seconds)
        {
            return new Delay(seconds);
        }

        #region CallbackWrapper
        public static Action WaitCallback(out CallbackTask task)
        {
            task = new CallbackTask();
            return task.GetWrapper();
        }

        public static Action<TResult> WaitCallback<TResult>(out CallbackTask<TResult> task)
        {
            task = new CallbackTask<TResult>();
            return task.GetWrapper();
        }

        public static Action<TResult1, TResult2> WaitCallback<TResult1, TResult2>(
            out CallbackTask<TResult1, TResult2> task)
        {
            task = new CallbackTask<TResult1, TResult2>();
            return task.GetWrapper();
        }

        public static Action<TResult1, TResult2, TResult3> WaitCallback<TResult1, TResult2, TResult3>(
            out CallbackTask<TResult1, TResult2, TResult3> task)
        {
            task = new CallbackTask<TResult1, TResult2, TResult3>();
            return task.GetWrapper();
        }

        public static Action<TResult1, TResult2, TResult3, TResult4> WaitCallback<TResult1, TResult2,
            TResult3, TResult4>(
            out CallbackTask<TResult1, TResult2, TResult3, TResult4> task)
        {
            task = new CallbackTask<TResult1, TResult2, TResult3, TResult4>();
            return task.GetWrapper();
        }

        public static Action<TResult1, TResult2, TResult3, TResult4, TResult5> WaitCallback<TResult1,
            TResult2, TResult3, TResult4, TResult5>(
            out CallbackTask<TResult1, TResult2, TResult3, TResult4, TResult5> task)
        {
            task = new CallbackTask<TResult1, TResult2, TResult3, TResult4, TResult5>();
            return task.GetWrapper();
        }
        #endregion
    }
}