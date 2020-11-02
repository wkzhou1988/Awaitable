namespace Simple.Threading.Tasks {
    public class WhenAny : AwaitableTask {
        private AwaitableTask[] tasks;
        public WhenAny(params AwaitableTask[] tasks) {
            this.tasks = tasks;
        }

        protected override void BeforeRun() {
            base.BeforeRun();
            foreach (var task in tasks) {
                task.GetAwaiter();
            }
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
}


