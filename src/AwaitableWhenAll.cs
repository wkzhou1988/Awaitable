public class AwaitableWhenAll : BaseAwaitableTask<int> {
    private int taskCount;
    private BaseAwaitableTask[] tasks;
    public AwaitableWhenAll(params BaseAwaitableTask[] tasks) {
        this.tasks = tasks;
    }

    protected override void BeforeRun() {
        base.BeforeRun();
        foreach (var task in tasks) {
            task.RunOn(_targetState);
            task.GetAwaiter();
        }
    }

    public override int GetResult() {
        return taskCount;
    }

    public override void Update(float dt) {
        if (IsCompleted) return;
        for (int i = 0; i < tasks.Length; i++) {
            if (!tasks[i].IsCompleted) return;
        }

        IsCompleted = true;
    }
}
