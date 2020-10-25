namespace Simple.Threading.Tasks {
    public class AwaitableEmpty : BaseAwaitableTask {
        public static AwaitableEmpty FromCompleted() {
            var task = new AwaitableEmpty();
            task.Start();
            task.IsCompleted = true;
            return task;
        }

        public static AwaitableEmpty Create() {
            var task = new AwaitableEmpty();
            task.Start();
            return task;
        }

        public void InternalSetComplete() {
            IsCompleted = true;
        }
    }

    public class AwaitableEmpty<T> : BaseAwaitableTask<T> {
        private T _result;

        public static AwaitableEmpty<T> FromCompleted() {
            var task = new AwaitableEmpty<T>();
            task.Start();
            task.IsCompleted = true;
            return task;
        }

        public static AwaitableEmpty<T> Create() {
            var task = new AwaitableEmpty<T>();
            task.Start();
            return task;
        }

        public void InternalSetComplete() {
            IsCompleted = true;
        }

        public void SetResult(T result) => _result = result;

        public override T GetResult() {
            return _result;
        }
    }
}