namespace Simple.Threading.Tasks {
    public class Delay : AwaitableTask {
        private float delay;
        private float timePassed;

        public Delay(float delay) => this.delay = delay;

        public override void Update(float dt) {
            if (IsCompleted) return;

            if (delay < float.Epsilon) {
                IsCompleted = true;
                return;
            }

            timePassed += dt;
            if (timePassed >= delay) {
                IsCompleted = true;
                return;
            }
        }
    }

}

