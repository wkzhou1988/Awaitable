using Boo.Lang;
using System.Diagnostics;
using System.Linq;

namespace Simple.Threading.Tasks {
    public class WhenAll : AwaitableTask {
        private ITask[] tasks;

        public WhenAll(params ITask[] tasks) {
            this.tasks = tasks;
        }

        protected override void BeforeRun() {
            base.BeforeRun();
            foreach (var task in tasks) {
                task.InternalGetAwaiter();
            }
        }

        public override void Update(float dt) {
            if (IsCompleted) return;
            for (int i = 0; i < tasks.Length; i++) {
                if (!tasks[i].IsCompleted) {
                    return;
                }
            }

            IsCompleted = true;
        }
    }
}
