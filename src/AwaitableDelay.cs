public class AwaitableDelay : BaseAwaitableTask<float> {
    private float delay;
    private float timePassed;

    public AwaitableDelay(float delay) => this.delay = delay;

    public override float GetResult() {
        return timePassed;
    }

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
