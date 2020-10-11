using System.Collections.Generic;

public class AwaitableTaskQueue : MonoSingleton<AwaitableTaskQueue> {
    private TaskQueueState _runState = TaskQueueState.All;

    public TaskQueueState CurrentRunState {
        get { return _runState; }
        set { _runState = value; }
    }

    private LinkedList<BaseAwaitableTask> _tasks = new LinkedList<BaseAwaitableTask>();

    public void Add(BaseAwaitableTask task) {
        _tasks.AddLast(task);
    }

    public bool Empty => _tasks.Count == 0;

    Dictionary<TaskQueueState, int> taskCounters = new Dictionary<TaskQueueState, int>();

    public int TaskCount(TaskQueueState state) {
        int count = 0;
        if (!taskCounters.TryGetValue(state, out count)) {
            taskCounters.Add(state, 0);
        }

        return count;
    }

    public override void OnUpdate(float deltaTime, float unscaleDeltaTime) {
        var cur = _tasks.First;
        while (cur != null) {
            var next = cur.Next;
            var task = cur.Value;

            if (task.CanRunOn(CurrentRunState)) {
                if (!task.IsStarted) task.Start();

                if (task.IsCompleted) {
                    task.Complete();
                    _tasks.Remove(cur);
                }
                else {
                    task.Update(deltaTime);
                }
            }

            cur = next;
        }
    }
}
