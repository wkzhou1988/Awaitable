using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

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
