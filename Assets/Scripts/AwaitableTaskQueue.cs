using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

namespace Simple.Threading.Tasks {
    public class AwaitableTaskQueue : MonoSingleton<AwaitableTaskQueue> {

        private LinkedList<ITask> _tasks = new LinkedList<ITask>();

        public void Add(ITask task) {
            _tasks.AddLast(task);
        }

        public bool Empty => _tasks.Count == 0;

        private void Update() {
            OnUpdate(Time.deltaTime, Time.unscaledDeltaTime);
        }

        public void OnUpdate(float deltaTime, float unscaleDeltaTime) {
            if (_tasks.Count == 0) {
                return;
            }

            var cur = _tasks.First;
            while (cur != null) {
                var next = cur.Next;
                var task = cur.Value;

                try {
                    if (!task.IsStarted) task.Start();

                    if (task.IsCompleted) {
                        _tasks.Remove(cur);
                        task.Complete();
                    }
                    else {
                        task.Update(deltaTime);
                    }
                } catch (Exception ex) {
                    _tasks.Remove(cur);
                    task.ExceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
                    task.Cancel();
                }

                cur = next;
            }
        }
    }

}

