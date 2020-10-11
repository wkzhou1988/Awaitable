using System;
using System.Runtime.CompilerServices;

public enum TaskQueueState {
    All = 1,
    State1 = 2,
    State2 = 4,
}

public abstract class BaseAwaitableTask {
    protected TaskQueueState _targetState = TaskQueueState.All;

    // 可以指定运行在一个逻辑状态机的State上面，也可以是All，就是不属于一个特定状态机。
    public BaseAwaitableTask RunOn(TaskQueueState state) {
        _targetState = state;
        return this;
    }

    public bool CanRunOn(TaskQueueState state) {
        return _targetState == TaskQueueState.All || _targetState == state;
    }

    public bool IsCompleted { get; protected set; }

    public bool IsStarted { get; protected set; }

    public void Start() {
        IsStarted = true;
        OnStart();
    }

    protected virtual void OnStart() {
    }

    public virtual object GetResult() {
        return null;
    }

    protected Action Continuation { get; set; }

    public abstract void Update(float dt);


    protected virtual void BeforeRun() {
    }

    public BaseTaskAwaiter GetAwaiter() {

        BeforeRun();
        // 调用await才加到队列，因此必须调用await才能执行一个Awaitable
        AwaitableTaskQueue.Instance.Add(this);
        return new BaseTaskAwaiter(this);
    }

    protected virtual void OnComplete() {
    }

    public void Complete() {
        OnComplete();
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
            return _awaitableTask.GetResult();
        }
    }
}

public abstract class BaseAwaitableTask<T> : BaseAwaitableTask {
    public abstract T GetResult();

    public abstract override void Update(float dt);

    public BaseTaskAwaiter<T> GetAwaiter() {
        BeforeRun();
        AwaitableTaskQueue.Instance.Add(this);
        return new BaseTaskAwaiter<T>(this);
    }

    public void OnComplete() {
        Continuation?.Invoke();
    }

    public class BaseTaskAwaiter<T> : BaseTaskAwaiter {
        private BaseAwaitableTask<T> _awaitableTask;

        public BaseTaskAwaiter(BaseAwaitableTask<T> awaitableTask) : base(awaitableTask) {
            _awaitableTask = awaitableTask;
        }

        public void OnCompleted(Action continuation) {
            _awaitableTask.Continuation = continuation;
        }

        public bool IsCompleted => _awaitableTask.IsCompleted;

        public T GetResult() {
            return _awaitableTask.GetResult();
        }
    }
}
