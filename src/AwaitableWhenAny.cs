public class AwaitableWhenAny : BaseAwaitableTask<int> {
    private BaseAwaitableTask[] tasks;
    public AwaitableWhenAny(params BaseAwaitableTask[] tasks) {
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
        return 1;
    }

    public override void Update(float dt) {
        if (IsCompleted) return;
        for (int i = 0; i < tasks.Length; i++) {
            if (tasks[i].IsCompleted) {
                IsCompleted = true;
                return;
            }
        }
    }
}
