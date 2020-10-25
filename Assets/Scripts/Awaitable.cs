namespace Simple.Threading.Tasks {
    public static class Awaitable {
        public static AwaitableWhenAll WhenAll(params BaseAwaitableTask[] tasks) {
            return new AwaitableWhenAll(tasks);
        }

        public static AwaitableWhenAny WhenAny(params BaseAwaitableTask[] tasks) {
            return new AwaitableWhenAny(tasks);
        }

        public static AwaitableDelay Delay(float seconds) {
            return new AwaitableDelay(seconds);
        }
    }

}
