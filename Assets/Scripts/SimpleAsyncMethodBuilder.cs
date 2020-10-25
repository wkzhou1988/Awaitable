using Simple.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Simple.Runtime.CompilerServices {
    public class SimpleAsyncMethodBuilder {
        private AwaitableEmpty _task;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SimpleAsyncMethodBuilder Create() {
            return new SimpleAsyncMethodBuilder();
        }

        public BaseAwaitableTask Task => _task;

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
                _task = AwaitableEmpty.Create();
            }
            stateMachine.MoveNext();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetStateMachine(IAsyncStateMachine stateMachine) {
        }
    }


    public class SimpleAsyncMethodBuilder<T> {
        private AwaitableEmpty<T> _task;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SimpleAsyncMethodBuilder<T> Create() {
            return new SimpleAsyncMethodBuilder<T>();
        }

        public BaseAwaitableTask<T> Task => _task;

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
                _task = AwaitableEmpty<T>.Create();
            }
            stateMachine.MoveNext();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetStateMachine(IAsyncStateMachine stateMachine) {
        }
    }
}