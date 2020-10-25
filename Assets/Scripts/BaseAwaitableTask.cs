using Simple.Runtime.CompilerServices;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Simple.Threading.Tasks {

    public interface ITask {
        bool IsDestroyed { get; }
        bool IsCompleted { get; }
        bool IsStarted { get; }
        bool IsCancelled { get; }
        void Start();
        void Complete();
        void Cancel();
        void Update(float dt);
        ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }
    }

    [AsyncMethodBuilder(typeof(SimpleAsyncVoidMethodBuilder))]
    public class BaseAwaitableTask : ITask {
        protected bool _isInQueue = false;

        public bool IsDestroyed { get; protected set; }

        public bool IsCompleted { get; protected set; }

        public bool IsStarted { get; protected set; }

        private Action Continuation { get; set; }

        public ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }

        public bool IsCancelled { get; private set; }

        protected virtual void OnStart() {
        }

        public void Start() {
            IsStarted = true;
            OnStart();
        }

        public virtual object GetResult() {
            return null;
        }

        public virtual void Update(float dt) {

        }


        protected virtual void BeforeRun() {

        }

        public BaseTaskAwaiter GetAwaiter() {
            if (!_isInQueue) {
                BeforeRun();
                _isInQueue = true;
                AwaitableTaskQueue.Instance.Add(this);
            }

            return new BaseTaskAwaiter(this);
        }

        protected virtual void OnComplete() {

        }

        public void Complete() {
            OnComplete();
            Continuation?.Invoke();
            IsDestroyed = true;
        }

        protected virtual void OnCancel() {

        }

        public void Cancel() {
            IsCancelled = true;
            OnCancel();
            Continuation?.Invoke();
            IsDestroyed = true;
        }

        public struct BaseTaskAwaiter : INotifyCompletion {
            private BaseAwaitableTask _awaitableTask;

            public BaseTaskAwaiter(BaseAwaitableTask awaitableTask) {
                _awaitableTask = awaitableTask;
            }

            public void OnCompleted(Action continuation) {
                _awaitableTask.Continuation = continuation;
            }

            public bool IsCompleted => _awaitableTask.IsCompleted;

            public object GetResult() {
                if (_awaitableTask.ExceptionDispatchInfo != null) {
                    _awaitableTask.ExceptionDispatchInfo.Throw();
                }
                return _awaitableTask.GetResult();
            }
        }
    }

    [AsyncMethodBuilder(typeof(SimpleAsyncTaskMethodBuilder<>))]
    public abstract class BaseAwaitableTask<T> : ITask {
        protected bool _isInQueue = false;

        public bool IsDestroyed { get; protected set; }

        public bool IsCompleted { get; protected set; }

        public bool IsStarted { get; protected set; }

        public bool IsCancelled { get; protected set; }

        public ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }

        private Action Continuation { get; set; }

        public abstract T GetResult();

        public virtual void Update(float dt) {

        }

        protected virtual void BeforeRun() {

        }

        public BaseTaskAwaiter<T> GetAwaiter() {
            if (!_isInQueue) {
                BeforeRun();
                _isInQueue = true;
                AwaitableTaskQueue.Instance.Add(this);
            }
            return new BaseTaskAwaiter<T>(this);
        }

        protected virtual void OnStart() {

        }

        public void Start() {
            IsStarted = true;
            OnStart();
        }

        protected virtual void OnComplete() {

        }

        public void Complete() {
            OnComplete();
            Continuation?.Invoke();
            IsDestroyed = true;
        }

        protected virtual void OnCancel() {

        }

        public void Cancel() {
            IsCancelled = true;
            OnCancel();
            Continuation?.Invoke();
            IsDestroyed = true;
        }
        #pragma warning disable CS0693
        public struct BaseTaskAwaiter<T> : INotifyCompletion {
            private BaseAwaitableTask<T> _awaitableTask;

            public BaseTaskAwaiter(BaseAwaitableTask<T> awaitableTask) {
                _awaitableTask = awaitableTask;
            }

            public void OnCompleted(Action continuation) {
                _awaitableTask.Continuation = continuation;
            }

            public bool IsCompleted => _awaitableTask.IsCompleted;

            public T GetResult() {
                if (_awaitableTask.ExceptionDispatchInfo != null) {
                    _awaitableTask.ExceptionDispatchInfo.Throw();
                }
                return _awaitableTask.GetResult();
            }
        }
    }


}
