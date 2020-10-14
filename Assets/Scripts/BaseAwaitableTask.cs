using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Simple.Threading.Tasks {

    public interface ITask {
        bool IsCompleted { get; }
        bool IsStarted { get; }
        bool IsCancelled { get; }
        void Start();
        void Complete();
        void Cancel();
        void Update(float dt);
        ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }
    }

    public abstract class BaseAwaitableTask : ITask {

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

        public abstract void Update(float dt);


        protected virtual void BeforeRun() {

        }

        public BaseTaskAwaiter GetAwaiter() {

            BeforeRun();
            AwaitableTaskQueue.Instance.Add(this);
            return new BaseTaskAwaiter(this);
        }

        protected virtual void OnComplete() {

        }

        public void Complete() {
            OnComplete();
            Continuation?.Invoke();
        }

        protected virtual void OnCancel() {

        }

        public void Cancel() {
            IsCancelled = true;
            OnCancel();
            Continuation?.Invoke();
        }

        public class BaseTaskAwaiter : INotifyCompletion {
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

    public abstract class BaseAwaitableTask<T> : ITask {
        public bool IsCompleted { get; protected set; }

        public bool IsStarted { get; protected set;}

        public bool IsCancelled { get; protected set; }

        public ExceptionDispatchInfo ExceptionDispatchInfo { get; set; }

        private Action Continuation { get; set; }

        public abstract T GetResult();

        public abstract void Update(float dt);

        protected virtual void BeforeRun() {

        }

        public BaseTaskAwaiter<T> GetAwaiter() {
            BeforeRun();
            AwaitableTaskQueue.Instance.Add(this);
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
        }

        protected virtual void OnCancel() {

        }

        public void Cancel() {
            IsCancelled = true;
            OnCancel();
            Continuation?.Invoke();
        }

        public class BaseTaskAwaiter<T> : INotifyCompletion {
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
