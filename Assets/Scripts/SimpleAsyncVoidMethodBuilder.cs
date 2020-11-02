using Simple.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Simple.Runtime.CompilerServices {
    public class SimpleAsyncVoidMethodBuilder {
        private AsyncMethodTask _task;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SimpleAsyncVoidMethodBuilder Create() {
            return new SimpleAsyncVoidMethodBuilder();
        }

        public AwaitableTask Task => _task;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetException(Exception exception) {
            _task.ExceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetResult() {
            _task.InternalSetComplete();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine {
            if (_task == null) {
                _task = AsyncMethodTask.Create();
            }
            stateMachine.MoveNext();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetStateMachine(IAsyncStateMachine stateMachine) {
        }
    }


    public class SimpleAsyncTaskMethodBuilder<T> {
        private AwaitableMethodTask<T> _task;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SimpleAsyncTaskMethodBuilder<T> Create() {
            return new SimpleAsyncTaskMethodBuilder<T>();
        }

        public AwaitableTask<T> Task => _task;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetException(Exception exception) {
            _task.ExceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetResult(T result) {
            _task.SetResult(result);
            _task.InternalSetComplete();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Start<TStateMachine>(ref TStateMachine stateMachine)
            where TStateMachine : IAsyncStateMachine {
            if (_task == null) {
                _task = AwaitableMethodTask<T>.Create();
            }
            stateMachine.MoveNext();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetStateMachine(IAsyncStateMachine stateMachine) {
        }
    }
}