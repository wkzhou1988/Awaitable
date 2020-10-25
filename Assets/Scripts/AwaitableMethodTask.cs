namespace Simple.Threading.Tasks {
    public class AwaitableMethodTask : BaseAwaitableTask {
        public static AwaitableMethodTask FromCompleted() {
            var task = new AwaitableMethodTask();
            task.Start();
            task.IsCompleted = true;
            return task;
        }

        public static AwaitableMethodTask Create() {
            var task = new AwaitableMethodTask();
            task.Start();
            return task;
        }

        internal void InternalSetComplete() {
            IsCompleted = true;
        }
    }

    public class AwaitableMethodTask<T> : BaseAwaitableTask<T> {
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