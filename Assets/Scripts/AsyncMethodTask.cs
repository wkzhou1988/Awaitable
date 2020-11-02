namespace Simple.Threading.Tasks {
    public class AsyncMethodTask : AwaitableTask {
        public static AsyncMethodTask FromCompleted() {
            var task = new AsyncMethodTask();
            task.Start();
            task.IsCompleted = true;
            return task;
        }

        public static AsyncMethodTask Create() {
            var task = new AsyncMethodTask();
            task.Start();
            return task;
        }

        internal void InternalSetComplete() {
            IsCompleted = true;
        }
    }

    public class AwaitableMethodTask<T> : AwaitableTask<T> {
        private T _result;

        public static AwaitableMethodTask<T> FromCompleted() {
            var task = new AwaitableMethodTask<T>();
            task.Start();
            task.IsCompleted = true;
            return task;
        }

        public static AwaitableMethodTask<T> Create() {
            var task = new AwaitableMethodTask<T>();
            task.Start();
            return task;
        }

        internal void InternalSetComplete() {
            IsCompleted = true;
        }

        public void SetResult(T result) => _result = result;

        public override T GetResult() {
            return _result;
        }
    }
}